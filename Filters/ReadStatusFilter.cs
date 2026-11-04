namespace NotificationLib
{
    public class ReadStatusFilter : INotificationFilter
    {
        public IEnumerable<Notification> Apply(
            IEnumerable<Notification> notifications,
            NotificationFilterOptions options)
        {
            if (options.IsRead is null)
                return notifications;

            return notifications.Where(n => n.IsRead == options.IsRead.Value);
        }
    }
}