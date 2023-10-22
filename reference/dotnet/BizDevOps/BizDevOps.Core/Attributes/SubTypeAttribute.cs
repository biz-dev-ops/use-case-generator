using System;

namespace BizDevOps.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = true)]
    public class SubTypeAttribute : Attribute
    {
       
        public SubTypeAttribute(Type type, string discriminator)
        {
            if (string.IsNullOrEmpty(discriminator))
            {
                throw new ArgumentException($"'{nameof(discriminator)}' cannot be null or empty.", nameof(discriminator));
            }

            Type = type ?? throw new ArgumentNullException(nameof(type));
            Discriminator = discriminator;
        }

        public Type Type { get; }
        public string Discriminator { get; }
    }
}