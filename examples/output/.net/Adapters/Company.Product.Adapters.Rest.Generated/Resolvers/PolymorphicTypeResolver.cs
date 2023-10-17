// using System;
// using System.Linq;
// using System.Text.Json;
// using System.Text.Json.Serialization;
// using System.Text.Json.Serialization.Metadata;

// namespace Company.Product.Adapters.Rest.Resolvers
// {
//     public class PolymorphicTypeResolver : DefaultJsonTypeInfoResolver
//     {
//         public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
//         {
//             var jsonTypeInfo = base.GetTypeInfo(type, options);
//             if(jsonTypeInfo.PolymorphismOptions != null)
//                 return jsonTypeInfo;

//             var derivedTypes = type.Assembly
//                 .GetTypes()
//                 .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(jsonTypeInfo.Type));

//             if(!derivedTypes.Any())
//                 return jsonTypeInfo;

//             jsonTypeInfo.PolymorphismOptions = new JsonPolymorphismOptions
//             {
//                 TypeDiscriminatorPropertyName = "$type",
//                 IgnoreUnrecognizedTypeDiscriminators = true,
//                 UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FailSerialization
//             };

//             foreach(var derivedType in derivedTypes) {
//                 jsonTypeInfo.PolymorphismOptions.DerivedTypes.Add(new JsonDerivedType(derivedType, derivedType.Name));
//             }

//             return jsonTypeInfo;
//         }
//     }
// }