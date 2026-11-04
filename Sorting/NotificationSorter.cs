using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace NotificationLib
{
    public class NotificationSorter : INotificationSorter
    {
        public IEnumerable<Notification> Sort(
            IEnumerable<Notification> notifications,
            NotificationFilterOptions options)
        {
            if (options.SortBy is null)
                return notifications;

            Func<Notification, object> key = options.SortBy switch
            {
                SortNotificationBy.Date => n => n.CreatedAt,
                SortNotificationBy.Priority => n => n.Priority,
                _ => n => n.Title
            };

            return options.Descending
                ? notifications.OrderByDescending(key)
                : notifications.OrderBy(key);
        }
    }
}