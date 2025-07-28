using System.Text.Json;
using DevSnapshot.Models;

namespace DevSnapshot.Services
{
    public class JournalService
    {
        private readonly string _filePath;

        public JournalService(string filePath = "entries.json")
        {
            _filePath = filePath;
        }

        public async Task AddEntryAsync(string text)
        {
            var entry = new JournalEntry
            {
                Timestamp = DateTime.UtcNow,
                Text = text
            };

            List<JournalEntry> entries = new();
            if (File.Exists(_filePath))
            {
                using var stream = File.OpenRead(_filePath);
                var existing = await JsonSerializer.DeserializeAsync<List<JournalEntry>>(stream);
                if (existing != null)
                {
                    entries = existing;
                }
            }

            entries.Add(entry);

            using var writeStream = File.Create(_filePath);
            await JsonSerializer.SerializeAsync(writeStream, entries, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}
