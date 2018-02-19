using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Strathweb.Samples.AspNetCore.QueryStringBinding
{
    public class SeparatedQueryStringValueProviderFactory : IValueProviderFactory
    {
        private readonly string _separator;
        private HashSet<string> _keys;

        public SeparatedQueryStringValueProviderFactory(string separator) : this((IEnumerable<string>)null, separator)
        { }

        public SeparatedQueryStringValueProviderFactory(string key, string separator) : this(new List<string> { key }, separator)
        {
        }

        public SeparatedQueryStringValueProviderFactory(IEnumerable<string> keys, string separator)
        {
            _keys = keys != null ? new HashSet<string>(keys) : null;
            _separator = separator;
        }

        public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
        {
            context.ValueProviders.Insert(0,
                new SeparatedQueryStringValueProvider(_keys, context.ActionContext.HttpContext.Request.Query,
                    _separator));
            return Task.CompletedTask;
        }

        public void AddKey(string key)
        {
            if (_keys == null)
            {
                _keys = new HashSet<string>();
            }

            _keys.Add(key);
        }
    }
}
