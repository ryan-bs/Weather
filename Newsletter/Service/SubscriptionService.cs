using Microsoft.EntityFrameworkCore;
using Newsletter.Data;
using Newsletter.Data.DTOs;
using Newsletter.Models;
using Newsletter.Service.Interfaces;

namespace Newsletter.Service;

public class SubscriptionService : ISubscriptionService
{
    private readonly NewsletterContext _context;
    private readonly IEmailService _emailService;

    public SubscriptionService(NewsletterContext context, IEmailService emailService)
    {
        _context = context;
        _emailService = emailService;
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
        await SendConfirmationEmail(subscription.Email);
    }

    public async Task UnsubscribeAsync(Guid id)
    {
        var subscription = await _context.Subscriptions.FindAsync(id);
        if (subscription != null)
        {
            _context.Subscriptions.Remove(subscription);
            await _context.SaveChangesAsync();
            await SendUnsubscribeConfirmationEmail(subscription.Email);
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

    private async Task SendConfirmationEmail(string email)
    {
        string subject = "Assinatura realizada!";
        string body = "Obrigado por assinar nossa Newsletter.";
        await _emailService.SendEmailAsync(email, subject, body);
    }

    private async Task SendUnsubscribeConfirmationEmail(string email)
    {
        string subject = "Descadastrado com sucesso";
        string body = "Você realizou o descadastro da Newsletter com sucesso.";
        await _emailService.SendEmailAsync(email, subject, body);
    }
}
