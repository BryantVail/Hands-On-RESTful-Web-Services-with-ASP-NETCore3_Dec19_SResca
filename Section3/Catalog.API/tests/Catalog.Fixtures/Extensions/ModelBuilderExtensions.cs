using System;
using System.Collections.Generic;
using System.Text;
// file requisite namespaces
using Microsoft.EntityFrameworkCore;
using System.IO;
using Newtonsoft.Json;

namespace Catalog.Fixtures.Extensions
{
    public static class ModelBuilderExtensions
    {

        public static ModelBuilder Seed<T>(this ModelBuilder modelBuilder, string file) where T : class
        {
            using (var reader = new StreamReader(file))
            {
                var json = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<T[]>(json);
                modelBuilder.Entity<T>().HasData(data);
            }

            return modelBuilder;
        }

    }
}
