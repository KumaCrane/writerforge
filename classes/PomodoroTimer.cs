namespace WriterForge;
public class PomodoroTimer
{
    public int WorkMinutes { get; set; } = 25;
    public int BreakMinutes { get; set; } = 5;

    public void Start()
    {
        Console.WriteLine($"Работаем {WorkMinutes} минут...");
        // Таймер можно сделать через System.Timers.Timer
    }
}