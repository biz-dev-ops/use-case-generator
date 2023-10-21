using Company.Product.Domain.UseCases.Types;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace Company.Product.Adapters.Rest.Resolvers
{
    public class PolymorphicTypeResolver : DefaultJsonTypeInfoResolver
    {
        public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
        {
            var jsonTypeInfo = base.GetTypeInfo(type, options);
            if (jsonTypeInfo.PolymorphismOptions != null)
                return jsonTypeInfo;

            if (type == typeof(Animal))
            {
                jsonTypeInfo.PolymorphismOptions = new JsonPolymorphismOptions
                {
                    TypeDiscriminatorPropertyName = "object_type",
                    IgnoreUnrecognizedTypeDiscriminators = true,
                    UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FailSerialization,
                    DerivedTypes = {
                        new JsonDerivedType(typeof(Cat), "CAT"),
                        new JsonDerivedType(typeof(Cow), "COW"),
                        new JsonDerivedType(typeof(Dog), "DOG")
                    }
                };
            }

            return jsonTypeInfo;
        }
    }
}