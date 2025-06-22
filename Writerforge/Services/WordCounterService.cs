using WriterForge;
using System;

namespace WriterForge.Services
{
    public class WordCounterService : IWordCounterService
    {
        public string Name => "WordCounter";
        private string _lastText = string.Empty;
        private int _lastCount = 0;

        public void UpdateText(string text)
        {
            _lastText = text;
            _lastCount = string.IsNullOrWhiteSpace(text)
                ? 0
                : text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public int GetLastCount() => _lastCount;

        public int CountWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return 0;
            return text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public void Execute(User user, Document doc)
        {
            if (doc != null && !string.IsNullOrWhiteSpace(doc.Content))
            {
                UpdateText(doc.Content);
            }
        }
    }
}
