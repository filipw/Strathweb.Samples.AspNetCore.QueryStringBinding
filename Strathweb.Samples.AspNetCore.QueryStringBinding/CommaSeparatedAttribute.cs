using System;

namespace Strathweb.Samples.AspNetCore.QueryStringBinding
{
    [AttributeUsage(AttributeTargets.Parameter, Inherited = true, AllowMultiple = false)]
    public class CommaSeparatedAttribute : Attribute
    {
    }
}
