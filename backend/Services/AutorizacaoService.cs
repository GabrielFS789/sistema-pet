using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace backend.Services
{
    public class AutorizacaoService : Attribute, IAuthorizationFilter
    {
        private readonly string _permissao;

        public AutorizacaoService(string permissao)
        {
            _permissao = permissao;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var usuarioClaims = context.HttpContext.User;
            Console.WriteLine(usuarioClaims);

            //Verifica se o usuario é administrador
            var isAdmin = usuarioClaims.Claims.FirstOrDefault(c => c.Type == "Administrador")?.Value;
            if (bool.TryParse(isAdmin, out bool isAdminBool) && isAdminBool)
                return;


            //Verifica se o usuario está autorizado
            if (!usuarioClaims.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            //Verifica as permissões do usuario
            var possuiPermissao = usuarioClaims.Claims.Any(c => c.Type == _permissao && bool.TryParse(c.Value, out bool valor) && valor);

            if (!possuiPermissao)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
