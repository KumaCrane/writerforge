using WriterForge;

namespace WriterForge.Services
{
    // Заготовка для сервиса облачного хранилища
    public class CloudStorageService : ICloudStorageService
    {
        public string Name => "CloudStorage";
        public void Upload(Document doc)
        {
            // ...реализация...
        }
        public Document? Download(string documentId)
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
