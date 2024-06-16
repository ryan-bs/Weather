using Newsletter.Data.DTOs;
using Newsletter.Models;

namespace Newsletter.Service.Interfaces;

public interface ISubscriptionService
{
    Task SubscribeAsync(SubscriptionDTO subscriptionDto);
    Task UnsubscribeAsync(Guid id);
    Task<IEnumerable<Subscription>> GetAllSubscriptionsAsync();
    Task<Subscription> GetSubscriptionByIdAsync(Guid id);
}
