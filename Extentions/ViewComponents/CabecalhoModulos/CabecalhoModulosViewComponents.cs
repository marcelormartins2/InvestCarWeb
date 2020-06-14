using System.Threading.Tasks;
using InvestCarWeb.Extentions.ViewComponents.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace InvestCarWeb.Extentions.ViewComponents.CabecalhoModulos
{
    [ViewComponent(Name = "Cabecalho")]
    public class CabecalhoModulosViewComponents : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string titulo, string subtitulo)
        {
            var model = new Modulo()
            {
                Titulo = titulo,
                Subtitulo = subtitulo
            };

            return View(model);
        }
    }
}
