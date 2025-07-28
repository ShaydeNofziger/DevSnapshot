namespace DevSnapshot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("DevSnapshot CLI");
                Console.WriteLine("Commands: add <text>, list, summarize");
                return;
            }

            var command = args[0].ToLower();
            switch (command)
            {
                case "add":
                    if (args.Length < 2)
                    {
                        Console.WriteLine("Usage: add <text>");
                        return;
                    }

                    var service = new Services.JournalService();
                    await service.AddEntryAsync(string.Join(' ', args[1..]));
                    Console.WriteLine("Added entry: " + string.Join(' ', args[1..]));
                    break;
                case "list":
                    // TODO: Read and display saved entries
                    Console.WriteLine("Listing entries (not yet implemented)");
                    break;
                case "summarize":
                    // TODO: Call OpenAI API to summarize entries
                    Console.WriteLine("Summarizing (not yet implemented)");
                    break;
                default:
                    Console.WriteLine($"Unknown command: {command}");
                    break;
            }
        }
    }
}
