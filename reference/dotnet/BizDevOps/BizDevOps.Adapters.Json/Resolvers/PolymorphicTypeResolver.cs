using BizDevOps.Core.Attributes;

using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace BizDevOps.Adapters.Json.Resolvers
{
    public class PolymorphicTypeResolver : DefaultJsonTypeInfoResolver
    {
        public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
        {
            var jsonTypeInfo = base.GetTypeInfo(type, options);
            if (jsonTypeInfo.PolymorphismOptions != null)
                return jsonTypeInfo;

            jsonTypeInfo.PolymorphismOptions = MapJsonPolymorphismOptions(type);
            return jsonTypeInfo;
        }

        private static JsonPolymorphismOptions? MapJsonPolymorphismOptions(Type type)
        {
            var typeDiscriminatorPropertyName = MapTypeDiscriminatorPropertyName(type);
            var derivedTypes = MapDerivedTypese(type);

            if(typeDiscriminatorPropertyName == null && !derivedTypes.Any())
                return null;

            var options = new JsonPolymorphismOptions
            {
                TypeDiscriminatorPropertyName = typeDiscriminatorPropertyName,
                IgnoreUnrecognizedTypeDiscriminators = true,
                UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FailSerialization
            };

            foreach(var derivedType in derivedTypes)
                options.DerivedTypes.Add(derivedType);

            return options;
        }

        private static string? MapTypeDiscriminatorPropertyName(Type type) 
            => type.GetCustomAttribute<PolymorphismInfoAttribute>(false)?.DiscriminatorProperty;

        private static IEnumerable<JsonDerivedType> MapDerivedTypese(Type type)
            => type.GetCustomAttributes<SubTypeAttribute>(false).Select(s => new JsonDerivedType(s.Type, s.Discriminator));
    }
}