using System;

namespace WriterForge
{
    class Program
    {
        static void Main()
        {
            var project = new WritingProject 
            { 
                Title = "Мой роман", 
                Content = "Привет, это тестовый текст." 
            };

            Console.WriteLine(string.Format("Проект: {0}", project.Title));
            Console.WriteLine(string.Format("Слов: {0}", project.WordCount));

            var spellChecker = new SpellChecker();
            var errors = spellChecker.CheckSpelling(project.Content);
            Console.WriteLine(string.Format("Ошибки: {0}", string.Join(", ", errors)));

            var timer = new PomodoroTimer();
            timer.Start();
        }
    }
}