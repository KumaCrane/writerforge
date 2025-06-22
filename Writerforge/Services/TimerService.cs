using WriterForge;
using System;
using System.Timers;

namespace WriterForge.Services
{
    public class TimerService : ITimerService
    {
        public string Name => "Timer";
        public event Action TimerElapsed = delegate { };

        private System.Timers.Timer? _timer;
        private DateTime? _endTime;
        private bool _isRunning = false;

        public void StartOrToggleTimer()
        {
            if (_isRunning)
            {
                // Сброс и остановка
                StopTimer();
            }
            else
            {
                // Запуск на 30 минут
                StartTimer(30);
            }
        }

        public void StartTimer(int minutes)
        {
            StopTimer();
            _endTime = DateTime.Now.AddMinutes(30);
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += OnTimerTick;
            _timer.Start();
            _isRunning = true;
        }

        public void StopTimer()
        {
            _timer?.Stop();
            _timer?.Dispose();
            _timer = null;
            _endTime = null;
            _isRunning = false;
        }

        private void OnTimerTick(object? sender, ElapsedEventArgs e)
        {
            if (_endTime.HasValue && DateTime.Now >= _endTime.Value)
            {
                StopTimer();
                TimerElapsed.Invoke();
            }
        }

        public string GetTimeLeft()
        {
            if (!_isRunning || !_endTime.HasValue)
                return FormatTime(30 * 60); // всегда 30:00 если не идёт
            var secondsLeft = (int)Math.Max(0, (_endTime.Value - DateTime.Now).TotalSeconds);
            return FormatTime(secondsLeft);
        }

        private string FormatTime(int totalSeconds)
        {
            int min = totalSeconds / 60;
            int sec = totalSeconds % 60;
            return $"{min:D2}:{sec:D2}";
        }

        public void Execute(User user, Document doc)
        {
            // ...реализация по необходимости...
        }
    }
}
