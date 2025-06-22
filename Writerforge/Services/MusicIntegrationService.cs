using WriterForge;

namespace WriterForge.Services
{
    // Заготовка для сервиса интеграции музыки
    public class MusicIntegrationService : IMusicIntegrationService
    {
        public string Name => "MusicIntegration";
        public void Play(string track)
        {
            // ...реализация...
        }
        public void Pause()
        {
            // ...реализация...
        }
        public void Stop()
        {
            // ...реализация...
        }
        public void Execute(User user, Document doc)
        {
            // ...реализация...
        }
    }
}
