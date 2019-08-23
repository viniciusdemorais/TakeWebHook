using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using System;
using take.webhook.entity.Entity;

namespace take.webhook.entity
{
    public class WebHookContext : DbContext
    {
        public DbSet<Conversa> Conversa { get; set; }
        public DbSet<DadoBruto> DadoBruto { get; set; }
        public DbSet<RespostaWebHook> RespostaWebHook { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
#if DEBUG
                .AddJsonFile("appsettings.Development.json")
#else
                .AddJsonFile("appsettings.json")
#endif
            .Build();

            string conn = configuration.GetConnectionString("WebHook");

            if (conn.Contains("%CONTENTROOTPATH%"))
                conn = conn.Replace("%CONTENTROOTPATH%", Environment.CurrentDirectory);

            optionsBuilder.UseMySQL(conn)
            .ConfigureWarnings(warnings => warnings.Throw(CoreEventId.IncludeIgnoredWarning));

            optionsBuilder.EnableSensitiveDataLogging(true);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Iterate over every DbSet<> found in the current DbContext
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Iterate over each property found on the Entity class
                foreach (IMutableProperty property in entityType.GetProperties())
                {
                    if (property.PropertyInfo.PropertyType.IsBoolean())
                    {
                        // Since MySQL stores bool as tinyint, let's add a converter so the tinyint is treated as boolean
                        modelBuilder.Entity(entityType.ClrType)
                                    .Property(property.Name)
                                    .HasConversion(new BoolToZeroOneConverter<short>());
                    }
                }

            };
        }

    }
    public static class TypeExtensions
    {
        public static bool IsBoolean(this Type type)
        {
            Type t = Nullable.GetUnderlyingType(type) ?? type;

            return t == typeof(bool);
        }
    }
}
