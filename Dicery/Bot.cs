using Dicery.Commands;
using Dicery.Models;
using Guilded;
using Guilded.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dicery
{
    public class Bot
    {
        private static readonly string? json = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json"));
        private static readonly string? token = JsonSerializer.Deserialize<ConfigJson>(json!)!.Token!;
        private static readonly string? prefix = JsonSerializer.Deserialize<ConfigJson>(json!)!.Prefix!;
        private static readonly string? timePattern = "hh:mm:ss tt";

        public async Task RunAsync()
        {
            await using var client = new GuildedBotClient(token!)
                .AddCommands(new MemberCommands(), prefix!)
                .AddCommands(new ModCommands(), prefix!);



            await client.ConnectAsync();
            await client.SetStatusAsync("Watching Everything", 90002579);
            var time = DateTime.Now.ToString(timePattern);
            var date = DateTime.Now.ToShortDateString();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"[{date}][{time}][INFO]  [{client.Name}] connected...");
            Console.WriteLine($"[{date}][{time}][INFO]  [{client.Name}] registering command modules...");
            await Task.Delay(200);
            Console.WriteLine($"[{date}][{time}][INFO]  [{client.Name}] listening for events...");
            await Task.Delay(-1);
        }
    }
}
