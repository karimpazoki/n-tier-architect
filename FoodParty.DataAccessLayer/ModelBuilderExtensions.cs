using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pluralize.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FoodParty.DataAccessLayer
{
    public static class ModelBuilderExtensions
    {
        private readonly static Func<ModelBuilder, ModelBuilderDecorator> modelBuilderFactory =
          (modelBuilder) => new ModelBuilderDecorator(modelBuilder);
        public static void AutoAddDbSetClass<BaseType>(this ModelBuilder modelBuilder, params Assembly[] assemblies)
        {
            modelBuilderFactory(modelBuilder).AddDbSetClass<BaseType>(assemblies);
        }
        public static void AddPluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            modelBuilderFactory(modelBuilder).AddPluralizingTableName();
        }

    }
    public class ModelBuilderDecorator
    {
        private readonly ModelBuilder modelBuilder;
        public ModelBuilderDecorator(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }
        public void AddDbSetClass<BaseType>(params Assembly[] assemblies)
        {
            IEnumerable<Type> types = assemblies.SelectMany(e => e.GetExportedTypes())
                .Where(e => e.IsClass && !e.IsAbstract && !e.IsSealed && e.IsPublic && typeof(BaseType).IsAssignableFrom(e));

            foreach (var type in types)
            {
                modelBuilder.Entity(type);
            }

        }
        public void AddPluralizingTableName()
        {
            Pluralizer pluralizer = new Pluralizer();
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                string tableName = entityType.GetTableName();
                entityType.SetTableName(pluralizer.Pluralize(tableName));
            }
        }
    }
}
