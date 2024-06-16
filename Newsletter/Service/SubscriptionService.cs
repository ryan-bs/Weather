using Microsoft.EntityFrameworkCore;
using Newsletter.Data;
using Newsletter.Data.DTOs;
using Newsletter.Models;
using Newsletter.Service.Interfaces;

namespace Newsletter.Service;

public class SubscriptionService : ISubscriptionService
{
    private readonly NewsletterContext _context;

    public SubscriptionService(NewsletterContext context)
    {
        _context = context;
    }

    public async Task SubscribeAsync(SubscriptionDTO subscriptionDto)
    {
        var subscription = new Subscription
        {
            Id = Guid.NewGuid(),
            Email = subscriptionDto.Email,
            Frequency = subscriptionDto.Frequency,
            SubscribedAt = DateTime.UtcNow
        };
        _context.Subscriptions.Add(subscription);
        await _context.SaveChangesAsync();
    }

    public async Task UnsubscribeAsync(Guid id)
    {
        var subscription = await _context.Subscriptions.FindAsync(id);
        if (subscription != null)
        {
            _context.Subscriptions.Remove(subscription);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Subscription>> GetAllSubscriptionsAsync()
    {
        return await _context.Subscriptions.ToListAsync();
    }

    public async Task<Subscription> GetSubscriptionByIdAsync(Guid id)
    {
        return await _context.Subscriptions.FindAsync(id);
    }
}
