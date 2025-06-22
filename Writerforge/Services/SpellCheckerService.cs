using WriterForge;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WriterForge.Services
{
    // Заготовка для сервиса проверки орфографии
    public class SpellCheckerService : ISpellCheckerService
    {
        public string Name => "SpellChecker";
        public IEnumerable<string> CheckSpelling(string text)
        {
            // Примитивная проверка: возвращает слова, не состоящие только из английских букв
            if (string.IsNullOrWhiteSpace(text))
                return new List<string>();
            var words = text.Split(new[] {' ', '\t', '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
            var misspelled = new List<string>();
            foreach (var word in words)
            {
                if (!Regex.IsMatch(word, "^[a-zA-Z]+$"))
                    misspelled.Add(word);
            }
            return misspelled;
        }
        public void Execute(User user, Document doc)
        {
            // Можно реализовать логику для проверки орфографии в документе
        }
    }
}
