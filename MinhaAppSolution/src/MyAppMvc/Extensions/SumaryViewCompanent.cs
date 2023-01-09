using Dev.Bussines.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dev.AppMvc.Extensions
{
    public class SumaryViewCompanent : ViewComponent
    {
        private readonly INotificador _notificador;
        public SumaryViewCompanent(INotificador notificador)
        {
            _notificador = notificador;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_notificador.ObterNotificacoes());
            notificacoes.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Mensagem));
            return View();
        }
    }
}
