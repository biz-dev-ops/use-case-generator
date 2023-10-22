using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BizDevOps.Core.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace BizDevOps.Adapters.Swashbuckle.Configuration
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddBizDevOpsAdaptersSwashbuckle(this IServiceCollection services)
        {
            services
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
            // is there any base type?
            if (type == null)
            {
                yield break;
            }

            // return all implemented or inherited interfaces
            foreach (var i in type.GetInterfaces())
            {
                yield return i;
            }

            // return all inherited types
            var currentBaseType = type.BaseType;
            while (currentBaseType != null)
            {
                yield return currentBaseType;
                currentBaseType= currentBaseType.BaseType;
            }
        }
    }
}