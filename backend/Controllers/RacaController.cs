using backend.AppDbContext;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RacaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Raca>>> GetAllAsync()
        {
            var racas = await _context.Raca.AsNoTracking().ToListAsync();
            return Ok(racas);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Raca>> GetByIdAsync(int id)
        {
            try
            {
                var raca = await _context.Raca.FirstOrDefaultAsync(x => x.Id == id);
                if (raca is null)
                    return BadRequest("Raca não localizada");
                return Ok(raca);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<Raca>> CreateAsync(Raca raca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                raca.InsertDataHoraCadastro();
                await _context.Raca.AddAsync(raca);
                await _context.SaveChangesAsync();
                return Ok(raca);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Raca>> DeleteAsync(int id)
        {
            var racaParaDeletar = await _context.Raca.FindAsync(id);
            _context.Raca.Remove(racaParaDeletar);
            await _context.SaveChangesAsync();
            return Ok(racaParaDeletar);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateAsync(int id, Raca raca)
        {
            try
            {
                _context.Raca.Entry(raca).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(raca);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

        }
        [HttpPatch("{id:int}")]
        public async Task<ActionResult> PatchAsync(int id, JObject myObject)
        {
            try
            {
                var raca = await _context.Raca.FirstOrDefaultAsync(x => x.Id == id);
                if (raca is null)
                    return NotFound();

                foreach (var property in myObject.Properties())
                {
                    var patchDoc = new JsonPatchDocument();
                    patchDoc.Replace($"/{property.Name}", property.Value);
                    patchDoc.ApplyTo(raca);
                }
                raca.UpdateDataHoraUltimaAtualizacao();

                _context.Raca.Entry(raca).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(raca);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
