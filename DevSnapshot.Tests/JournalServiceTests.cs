using DevSnapshot.Services;
using DevSnapshot.Models;
using System.Text.Json;

namespace DevSnapshot.Tests;

public class JournalServiceTests
{
    [Fact]
    public async Task AddEntryAsync_CreatesFileAndSavesEntry()
    {
        var path = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        var service = new JournalService(path);
        try
        {
            await service.AddEntryAsync("test entry");

            Assert.True(File.Exists(path));
            var json = await File.ReadAllTextAsync(path);
            var entries = JsonSerializer.Deserialize<List<JournalEntry>>(json);
            Assert.NotNull(entries);
            Assert.Single(entries!);
            Assert.Equal("test entry", entries![0].Text);
        }
        finally
        {
            if (File.Exists(path)) File.Delete(path);
        }
    }

    [Fact]
    public async Task AddEntryAsync_AppendsToExistingFile()
    {
        var path = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        var service = new JournalService(path);
        try
        {
            await service.AddEntryAsync("first");
            await service.AddEntryAsync("second");

            var json = await File.ReadAllTextAsync(path);
            var entries = JsonSerializer.Deserialize<List<JournalEntry>>(json);
            Assert.NotNull(entries);
            Assert.Equal(2, entries!.Count);
            Assert.Equal("first", entries![0].Text);
            Assert.Equal("second", entries![1].Text);
        }
        finally
        {
            if (File.Exists(path)) File.Delete(path);
        }
    }
}
