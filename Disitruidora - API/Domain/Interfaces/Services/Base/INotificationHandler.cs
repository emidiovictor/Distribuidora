using System.Collections.Generic;
using Domain.Notifications;

namespace Domain.Interfaces.Services.Base
{
    public interface INotificationHandler
    {
        List<Notification> GetNotifications();

        void Handle(Notification message);

        bool HasNotifications();
    }
}