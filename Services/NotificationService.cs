namespace NotificationLib
{
    public class NotificationService
    {
        private readonly IEnumerable<INotificationFilter> _filters;
        private readonly INotificationSorter _sorter;

        public NotificationService(
            IEnumerable<INotificationFilter> filters,
            INotificationSorter sorter)
        {
            _filters = filters ?? throw new ArgumentNullException(nameof(filters));
            _sorter = sorter ?? throw new ArgumentNullException(nameof(sorter));
        }

        public static NotificationService CreateDefault()
        {
            var filters = new List<INotificationFilter>
            {
                new ReadStatusFilter(),
                new TypeFilter(),
                new SearchTextFilter(),
                new MinPriortyFilter()
            };

            return new NotificationService(filters, new NotificationSorter());
        }

        public IEnumerable<Notification> FilterAndSort(
            IEnumerable<Notification> notifications,
            NotificationFilterOptions options)
        {
            if (notifications is null)
                throw new ArgumentNullException(nameof(notifications));
            if (options is null)
                throw new ArgumentNullException(nameof(options));

            var result = notifications;

            foreach (var filter in _filters)
            {
                result = filter.Apply(result, options);
            }

            return _sorter.Sort(result, options);
        }
    }
}