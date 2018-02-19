using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Strathweb.Samples.AspNetCore.QueryStringBinding
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class SeparatedQueryStringAttribute : Attribute, IResourceFilter
    {
        private readonly SeparatedQueryStringValueProviderFactory _factory;

        public SeparatedQueryStringAttribute() : this(",") { }

        public SeparatedQueryStringAttribute(string separator)
        {
            _factory = new SeparatedQueryStringValueProviderFactory(separator);
        }

        public SeparatedQueryStringAttribute(string key, string separator)
        {
            _factory = new SeparatedQueryStringValueProviderFactory(key, separator);
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {

        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.ValueProviderFactories.Insert(0, _factory);
        }

        public void AddKey(string key)
        {
            _factory.AddKey(key);
        }
    }
}
