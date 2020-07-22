using System.Collections.Generic;
using VSDev.Business.Notifications;

namespace VSDev.Business.Interfaces
{
    public interface INotificator
    {
        bool HasNotification();
        void Handle(Notification notification);
        List<Notification> GetNotifications();
    }
}
