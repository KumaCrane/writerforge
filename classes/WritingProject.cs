namespace WriterForge;

public class WritingProject
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int WordCount => Content.Split(new[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
}