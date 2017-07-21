using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using Microsoft.Extensions.Primitives;

namespace Strathweb.Samples.AspNetCore.QueryStringBinding
{
    public class SeparatedQueryStringValueProvider : QueryStringValueProvider
    {
        private readonly string _key;
        private readonly string _separator;
        private readonly IQueryCollection _values;

        public SeparatedQueryStringValueProvider(IQueryCollection values, string separator)
            : this(null, values, separator)
        {
        }

        public SeparatedQueryStringValueProvider(string key, IQueryCollection values, string separator)
            : base(BindingSource.Query, values, CultureInfo.InvariantCulture)
        {
            _key = key;
            _values = values;
            _separator = separator;
        }

        public override ValueProviderResult GetValue(string key)
        {
            var result = base.GetValue(key);

            if (_key != null && _key != key)
            {
                return result;
            }

            if (result != ValueProviderResult.None && result.Values.Any(x => x.IndexOf(_separator, StringComparison.OrdinalIgnoreCase) > 0))
            {
                var splitValues = new StringValues(result.Values
                    .SelectMany(x => x.Split(new[] { _separator }, StringSplitOptions.None)).ToArray());
                return new ValueProviderResult(splitValues, result.Culture);
            }

            return result;
        }
    }
}
