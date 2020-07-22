using System.Collections.Generic;
using System.Linq;
using VSDev.Business.Interfaces;

namespace VSDev.Business.Notifications
{
    public class Notificator : INotificator
    {
        private readonly List<Notification> _notifications;

        public Notificator()
        {
            _notifications = new List<Notification>();
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

    }
}
