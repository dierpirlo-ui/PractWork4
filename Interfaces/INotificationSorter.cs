namespace NotificationLib
{
    public interface INotificationSorter
    {
        IEnumerable<Notification> Sort(
            IEnumerable<Notification> notifications,
            NotificationFilterOptions options);
    }
}