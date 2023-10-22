using System;

namespace BizDevOps.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = true)]
    public class SubTypeAttribute : Attribute
    {
        public SubTypeAttribute(Type type)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
        }

        public Type Type { get; }
        public string Discriminator { get; set; }
    }
}