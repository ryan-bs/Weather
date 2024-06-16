using Microsoft.AspNetCore.Mvc;
using Newsletter.Data.DTOs;
using Newsletter.Service.Interfaces;

namespace Newsletter.Controllers;

[ApiController]
[Route("[controller]")]
public class NewsletterController : ControllerBase
{
    private readonly ISubscriptionService _subscriptionService;

    public NewsletterController(ISubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }

    [HttpPost]
    public async Task<IActionResult> SubscribeAsync([FromBody] SubscriptionDTO subscriptionDto)
    {
        await _subscriptionService.SubscribeAsync(subscriptionDto);
        return Ok("Subscription successful");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> UnsubscribeAsync(Guid id)
    {
        await _subscriptionService.UnsubscribeAsync(id);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetTodosRegistros()
    {
        var subscriptions = await _subscriptionService.GetAllSubscriptionsAsync();
        return Ok(subscriptions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRegistroPorId(Guid id)
    {
        var subscription = await _subscriptionService.GetSubscriptionByIdAsync(id);

        if (subscription == null)
            return NotFound();

        return Ok(subscription);
    }
}
