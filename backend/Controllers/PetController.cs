using AutoMapper;
using backend.AppDbContext;
using backend.DTOS;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PetController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetAllAsync()
        {
            var pets = await _context.Pet.AsNoTracking().ToListAsync();
            return Ok(pets);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pet>> GetByIdAsync(int id)
        {
            var pet = await _context.Pet.FindAsync(id);
            return Ok(pet);
        }

        [HttpPost]
        public async Task<ActionResult<Pet>> CreateAsync(Pet newPet)
        {
            try
            {
                await _context.Pet.AddAsync(newPet);
                await _context.SaveChangesAsync();
                return Ok(newPet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<Pet>> UpdateAsync(int id, JObject myObject)
        {
            try
            {
                var pet = await _context.Pet.FirstOrDefaultAsync(x => x.Id == id);
                if (pet is null)
                    return NotFound();

                var petDTO = _mapper.Map<PetUpdateDTO>(pet);

                foreach (var property in myObject.Properties())
                {
                    var patchDoc = new JsonPatchDocument();
                    patchDoc.Replace($"/{property.Name}", property.Value);
                    patchDoc.ApplyTo(petDTO);
                }
                pet.AtualizaDataHoraUltimaAtualizacao();

                var myPet = _mapper.Map<Pet>(petDTO);
                _context.Pet.Entry(myPet).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(myPet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
