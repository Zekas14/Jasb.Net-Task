using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastrucutre.Data
{
    public class LibraryDataSeed
    {
        public static async Task SeedDataAsync(LibraryContext context)
        {
            if (!context.Categories.Any())
            {
                var categoriesJsonData = await File.ReadAllTextAsync("../Infrastrucutre/Data/SeedData/Categories.json");
                var categories = JsonSerializer.Deserialize<List<Category>>(categoriesJsonData);
                await context.Categories.AddRangeAsync(categories!);


            }
            if (context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }   
        }
    }
}
