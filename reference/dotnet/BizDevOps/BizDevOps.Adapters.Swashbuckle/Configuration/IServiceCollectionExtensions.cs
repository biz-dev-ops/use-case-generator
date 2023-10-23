using BizDevOps.Core.Attributes;
using BizDevOps.Adapters.Swashbuckle.Attributes;
using BizDevOps.Adapters.Json.Resolvers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BizDevOps.Adapters.Swashbuckle.Configuration
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddBizDevOpsAdaptersSwashbuckle(this IServiceCollection services)
        {
            services
                .Configure<MvcOptions>(options => options.Filters.Add<ValidateModelStateAttribute>())
                .Configure<JsonOptions>(options => options.JsonSerializerOptions.TypeInfoResolver = new PolymorphicTypeResolver())
                .ConfigureSwaggerGen(options => {
                    options.UseAllOfForInheritance();
                    options.UseOneOfForPolymorphism();

                    options.SelectDiscriminatorNameUsing(baseType => baseType.GetCustomAttribute<PolymorphismInfoAttribute>()?.DiscriminatorProperty);
                    options.SelectSubTypesUsing(baseType => baseType.GetCustomAttributes<SubTypeAttribute>().Select(s => s.Type));

                    options.SelectDiscriminatorValueUsing(subType => subType.GetParentTypes()
                        .Select(t => t.GetCustomAttributes<SubTypeAttribute>()
                            .Where(s => s.Type == subType)
                            .Select(s => s.Discriminator)
                            .SingleOrDefault()
                        )
                        .Where(s => !string.IsNullOrEmpty(s))
                        .FirstOrDefault() ?? subType.Name
                    );
                });
                
            return services;
        }

        private static IEnumerable<Type> GetParentTypes(this Type type)
        {
            if (type == null)
            {
                yield break;
            }

            foreach (var i in type.GetInterfaces())
            {
                yield return i;
            }

            var currentBaseType = type.BaseType;
            while (currentBaseType != null)
            {
                yield return currentBaseType;
                currentBaseType= currentBaseType.BaseType;
            }
        }
    }
}