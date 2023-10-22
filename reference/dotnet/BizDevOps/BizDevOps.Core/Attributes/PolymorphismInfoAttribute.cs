using System;
using System.Collections.Generic;

namespace BizDevOps.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface)]
    public class PolymorphismInfoAttribute : Attribute
    {
        public  PolymorphismInfoAttribute(string discriminatorProperty)
        {
            if (string.IsNullOrEmpty(discriminatorProperty))
            {
                throw new ArgumentException($"'{nameof(discriminatorProperty)}' cannot be null or empty.", nameof(discriminatorProperty));
            }

            DiscriminatorProperty = discriminatorProperty;
        }

        public string DiscriminatorProperty { get; }
    }
}