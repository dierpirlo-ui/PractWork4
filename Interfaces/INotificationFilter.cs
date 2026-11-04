namespace NotificationLib
{
    public interface INotificationFilter
    {
        IEnumerable<Notification> Apply(
            IEnumerable<Notification> notifications,
            NotificationFilterOptions options);
    }
}