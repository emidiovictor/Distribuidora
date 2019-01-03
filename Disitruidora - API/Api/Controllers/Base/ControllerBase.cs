using System.Linq;
using System.Net;
using Domain.Interfaces.Services.Base;
using Domain.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Base
{
    public abstract class ApiController : Controller
    {
        private readonly INotificationHandler _notifications;

        protected ApiController(INotificationHandler notifications)
        {
            _notifications = (NotificationHandler)notifications;
        }

        protected virtual IActionResult Response(object result)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }

        protected virtual IActionResult Response()
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = null as object
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }

        protected IActionResult ResponseStatusCode(HttpStatusCode statusCode, object result)
        {
            return StatusCode(statusCode.GetHashCode(), new
            {
                data = result,
                errors = _notifications.GetNotifications().Select(x => x.Value)
            });
        }

        protected IActionResult ResponseStatusCode(HttpStatusCode statusCode)
        {
            return StatusCode(statusCode.GetHashCode(), new
            {
                data = null as object,
                errors = _notifications.GetNotifications().Select(x => x.Value)
            });
        }

        protected bool OperacaoValida()
        {
            return (!_notifications.HasNotifications());
        }

        protected void NotificarErroModelInvalida()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(string.Empty, erroMsg);
            }
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _notifications.Handle(new Notification(codigo, mensagem));
        }

        protected bool ModelStateValida()
        {
            if (ModelState.IsValid) return true;

            NotificarErroModelInvalida();
            return false;
        }

    }
}
