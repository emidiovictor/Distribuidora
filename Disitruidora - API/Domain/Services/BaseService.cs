using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interfaces.Services.Base;
using Domain.Notifications;
using FluentValidation.Results;

namespace Domain
{
    public class BaseService
    {

        protected readonly INotificationHandler _notificationHandler;


        public BaseService(INotificationHandler notificationHandler)
        {
            _notificationHandler = notificationHandler;
        }

        protected void NotificarValidacoesErro(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                _notificationHandler.Handle(new Notification(error.PropertyName, error.ErrorMessage, error.ErrorCode));
        }

        protected void NotificarValidacoesErro(string propertyName, string errorMessage, string errorCode)
        {
            _notificationHandler.Handle(new Notification(propertyName, errorMessage, errorCode));
        }

        protected void NotificarValidacao(string propertyName , string errorMessage)
        {
            _notificationHandler.Handle(new Notification(propertyName, errorMessage));
        }

        protected bool HasNotifications()
        {
            return _notificationHandler.HasNotifications();
        }

        protected IEnumerable<string> GetNotifications()
        {
            return _notificationHandler.GetNotifications().Select(x => x.Value);
        }


 
        protected bool ValidateObjectIsNotNull<T>(T obj, string msg)
        {
            var objIsValid = obj != null;

            if (!objIsValid)
                NotificarValidacao(string.Empty, msg);

            return objIsValid;
        }

        protected bool ValidateListIsNotNullOrEmpty<T>(IEnumerable<T> obj, string msg)
        {
            var objIsValid = obj != null && obj.Any();

            if (!objIsValid && !string.IsNullOrEmpty(msg))
                NotificarValidacao(string.Empty, msg);

            return objIsValid;
        }

        protected bool ValidateListIsNotNull<T>(IEnumerable<T> obj, string msg)
        {
            var objIsValid = obj != null;

            if (!objIsValid)
                NotificarValidacao(string.Empty, msg);

            return objIsValid;
        }

        protected bool ValidateList<T>(IEnumerable<T> list, Func<T, bool> action) where T : BaseEntity<T>
        {
            var isValid = false;

            foreach (var obj in list)
            {
                var result = action(obj);

                isValid = isValid || result;

                if (!isValid)
                    NotificarValidacoesErro(obj.ValidationResult);
            }

            return isValid;
        }
    }
}