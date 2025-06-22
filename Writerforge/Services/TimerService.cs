using WriterForge;
using System;

namespace WriterForge.Services
{
    // Заготовка для сервиса таймера
    public class TimerService : ITimerService
    {
        public string Name => "Timer";
        public event Action TimerElapsed = delegate { };
        public void StartTimer(int minutes)
        {
            // ...реализация...
        }
        public void StopTimer()
        {
            // ...реализация...
        }
        public void Execute(User user, Document doc)
        {
            // ...реализация...
        }
    }
}
