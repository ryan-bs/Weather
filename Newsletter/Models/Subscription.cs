namespace Newsletter.Models;

public class Subscription
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    // Fazer um enum para a Frequencia
    // "Semanal", "Quinzenal", "Mensal", "Semestral"
    public string Frequency { get; set; } = string.Empty;
    public DateTime SubscribedAt { get; set; }
}
