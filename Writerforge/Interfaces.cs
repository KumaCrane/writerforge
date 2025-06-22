using WriterForge;
using WriterForge.Services;
using System;
using System.Collections.Generic;

namespace WriterForge
{
    // Интерфейс для расширяемых фич
    public interface IWriterFeature
    {
        string Name { get; }
        void Execute(User user, Document doc);
    }

    // Интерфейс для сервиса подсчёта слов
    public interface IWordCounterService : IWriterFeature
    {
        int CountWords(string text);
    }

    // Интерфейс для таймера
    public interface ITimerService : IWriterFeature
    {
        void StartTimer(int minutes);
        void StopTimer();
        event Action TimerElapsed;
    }

    // Интерфейс для интеграции музыки
    public interface IMusicIntegrationService : IWriterFeature
    {
        void Play(string track);
        void Pause();
        void Stop();
    }

    // Интерфейс для проверки орфографии
    public interface ISpellCheckerService : IWriterFeature
    {
        IEnumerable<string> CheckSpelling(string text);
    }

    // Интерфейс для сбора статистики
    public interface IProductivityStatsService : IWriterFeature
    {
        void LogSession(User user, Document doc, int wordsWritten, TimeSpan duration);
        object? GetStats(User user);
    }

    // Интерфейс для облачного хранилища
    public interface ICloudStorageService : IWriterFeature
    {
        void Upload(Document doc);
        Document? Download(string documentId);
    }

    // Пример моделей
    public class User
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        // ...existing code...
    }

    public class Document
    {
        public string Id { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        // ...existing code...
    }
}