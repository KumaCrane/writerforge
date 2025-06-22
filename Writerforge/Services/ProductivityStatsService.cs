using WriterForge;
using System;

namespace WriterForge.Services
{
    // Заготовка для сервиса сбора статистики
    public class ProductivityStatsService : IProductivityStatsService
    {
        public string Name => "ProductivityStats";
        public void LogSession(User user, Document doc, int wordsWritten, TimeSpan duration)
        {
            // ...реализация...
        }
        public object? GetStats(User user)
        {
            // ...реализация...
            return null;
        }
        public void Execute(User user, Document doc)
        {
            // ...реализация...
        }
    }
}
