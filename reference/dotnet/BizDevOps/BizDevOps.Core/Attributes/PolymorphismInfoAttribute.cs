using System;
using System.Collections.Generic;

namespace BizDevOps.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface)]
    public class PolymorphismInfoAttribute : Attribute
    {
        public  PolymorphismInfoAttribute()
        { }

        public string DiscriminatorProperty { get; set; }
    }
}