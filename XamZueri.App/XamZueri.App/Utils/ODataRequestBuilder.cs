using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Platform;

namespace XamZueri.App.Utils
{
    public class ODataRequestBuilder<TEntity>
    {
        private readonly Uri _baseUrl;

        private readonly HttpRequestMessage _requestMessage;

        private readonly IDictionary<string, string> _parameters = new Dictionary<string, string>();

        private string _extra;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl">Format: http://xamzueri.ch/ </param>
        public ODataRequestBuilder(string baseUrl)
            :this(new Uri(baseUrl))
        {

        }

        public ODataRequestBuilder(Uri baseUrl)
        {
            _baseUrl = baseUrl;
            _requestMessage = new HttpRequestMessage { RequestUri = _baseUrl };
        }

        public ODataRequestBuilder<TEntity> Skip(int howMany)
        {
            _parameters["$skip"] = howMany.ToString();
            return this;
        }

        public ODataRequestBuilder<TEntity> OrderBy(string field, string order)
        {
            _parameters["$orderby"] = $"{field} {order}";
            return this;
        }

        public ODataRequestBuilder<TEntity> Single(int key)
        {
            _extra = $"({key})";
            return this;
        }

        public ODataRequestBuilder<TEntity> Single(Guid key)
        {
            _extra = $"(guid'{key}')";
            return this;
        }

        public HttpRequestMessage Request
        {
            get
            {
                var entity = typeof (TEntity).Name; // KISS

                if (_parameters.Count > 0)
                {
                    var queryString = string.Join("&",
                        _parameters.Select(t => $"{t.Key}={Uri.EscapeUriString(t.Value)}"));

                    _requestMessage.RequestUri = new Uri($"{_baseUrl}odata/{entity}s?{queryString}");
                }
                else
                {
                    _requestMessage.RequestUri = new Uri($"{_baseUrl}odata/{entity}s{_extra}");
                }

                return _requestMessage;
            }   
        }


    }
}
