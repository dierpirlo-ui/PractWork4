namespace NotificationLib
{
    public class TypeFilter : INotificationFilter
    {
        public IEnumerable<Notification> Apply(
            IEnumerable<Notification> notifications,
            NotificationFilterOptions options)
        {
            if (options.Types == null || options.Types.Length == 0)
                return notifications;

            return notifications.Where(n => options.Types.Contains(n.Type));
        }
    }
}
