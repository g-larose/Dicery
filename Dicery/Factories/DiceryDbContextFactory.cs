using Dicery.Data;
using Dicery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dicery.Factories
{
    public class DiceryDbContextFactory : IDesignTimeDbContextFactory<DiceryDbContext>
    {
        public DiceryDbContext CreateDbContext(string[]? args = null)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
            var config = File.ReadAllText(path);
            var json = JsonSerializer.Deserialize<ConfigJson>(config);
            var options = new DbContextOptionsBuilder<DiceryDbContext>();
            options.UseNpgsql(json!.ConnectionString!);

            return new DiceryDbContext(options.Options);
        }
    }
}
