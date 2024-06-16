using Microsoft.EntityFrameworkCore;
using Newsletter.Models;

namespace Newsletter.Data;

public class NewsletterContext : DbContext
{
    public NewsletterContext(DbContextOptions<NewsletterContext> opts) : base(opts)
    {
    }

    public DbSet<Subscription> Subscriptions { get; set; }
}
