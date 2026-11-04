namespace NotificationLib
{
    public class MinPriortyFilter : INotificationFilter
    {
        public IEnumerable<Notification> Apply(IEnumerable<Notification> notifications,
            NotificationFilterOptions options)
        {
            if (options.MinPriority == null) 
                return notifications;

            return notifications.Where(n => n.Priority >= options.MinPriority.Value);
        }
    }
}