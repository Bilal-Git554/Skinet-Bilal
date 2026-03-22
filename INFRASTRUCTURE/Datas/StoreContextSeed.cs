using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using CORE.Entities;

namespace INFRASTRUCTURE.Datas;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext seeding_context)
    {
       if(!seeding_context.Product.Any())
        {
            var products_data = await File.ReadAllTextAsync("../INFRASTRUCTURE/Datas/SeedData/products.json");

            var products = JsonSerializer.Deserialize<List<Products>>(products_data);

            if(products == null)
            {
                return;
            }
            
            seeding_context.Product.AddRange(products);

            await seeding_context.SaveChangesAsync();
        } 
    }
}
