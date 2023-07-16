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
        private readonly static Func<ModelBuilder, ModelBuilderDecorator> ModelBuilderFactory =
          (modelBuilder) => new ModelBuilderDecorator(modelBuilder);
        public static void AutoAddDbSetClass<TBaseType>(this ModelBuilder modelBuilder, params Assembly[] assemblies)
        {
            ModelBuilderFactory(modelBuilder).AddDbSetClass<TBaseType>(assemblies);
        }
        public static void AddPluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            ModelBuilderFactory(modelBuilder).AddPluralizingTableName();
        }

    }
    public class ModelBuilderDecorator
    {
        private readonly ModelBuilder _modelBuilder;
        public ModelBuilderDecorator(ModelBuilder modelBuilder)
        {
            this._modelBuilder = modelBuilder;
        }
        public void AddDbSetClass<TBaseType>(params Assembly[] assemblies)
        {
            IEnumerable<Type> types = assemblies.SelectMany(e => e.GetExportedTypes())
                .Where(e => e.IsClass && !e.IsAbstract && !e.IsSealed && e.IsPublic && typeof(TBaseType).IsAssignableFrom(e));

            foreach (var type in types)
            {
                _modelBuilder.Entity(type);
            }

        }
        public void AddPluralizingTableName()
        {
            Pluralizer pluralizer = new Pluralizer();
            foreach (IMutableEntityType entityType in _modelBuilder.Model.GetEntityTypes())
            {
                string tableName = entityType.GetTableName();
                entityType.SetTableName(pluralizer.Pluralize(tableName));
            }
        }
    }
}
