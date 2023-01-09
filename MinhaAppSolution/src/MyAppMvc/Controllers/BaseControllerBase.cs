using Dev.Bussines.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dev.AppMvc.Controllers
{
    public abstract class BaseControllerBase : Controller
    {
        private readonly INotificador _notificador;

        public BaseControllerBase(INotificador notificador)
        {
            _notificador = notificador;
        }
        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }
    }
}