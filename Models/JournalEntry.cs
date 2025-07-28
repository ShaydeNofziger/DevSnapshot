namespace DevSnapshot.Models
{
    public class JournalEntry
    {
        public DateTime Timestamp { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
