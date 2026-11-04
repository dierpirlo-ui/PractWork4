namespace NotificationLib
{
    public class SearchTextFilter : INotificationFilter
    {
        public IEnumerable<Notification> Apply(
            IEnumerable<Notification> notifications,
            NotificationFilterOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.SearchText))
                return notifications;

            var text = options.SearchText;

            return notifications.Where(n =>
                (n.Title?.Contains(text, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (n.Content?.Contains(text, StringComparison.OrdinalIgnoreCase) ?? false));
        }
    }
}