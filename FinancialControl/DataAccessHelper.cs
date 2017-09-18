using System.Net;
using RestSharp;

namespace FinancialControl
{
    public interface IRestHelper
    {
        T ExecuteGet<T>(RestRequest request) where T : new();
        void ExecutePost(RestRequest request);

    }
    internal class RestHelper : IRestHelper
    {
        private readonly IRestClient _client;

        public RestHelper(IRestClient client)
        {
            _client = client;
        }
        public T ExecuteGet<T>(RestRequest request) where T : new()
        {
            var response = _client.Execute<T>(request);
            ThrowIfUnsucessfull(response);
            return response.Data;
        }

        public void ExecutePost(RestRequest request)
        {
            var response = _client.Execute(request);
            ThrowIfUnsucessfull(response);
        }

        private void ThrowIfUnsucessfull(IRestResponse response)
        {
            if (response.StatusCode != HttpStatusCode.OK)
                throw new DataAccessException($"Doesn't work because {response.Content}, {response.StatusCode}");

        }
    }
}