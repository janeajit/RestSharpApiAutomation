using System;
using RestSharp;

namespace ApiTestAutomation
{
    /// <summary>
    /// API Client for handling HTTP requests
    /// </summary>
    public class ApiClient
    {
        private readonly RestClient _client;

        public ApiClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public async Task<RestResponse> SendRequestAsync(string endpoint, Method method, Dictionary<string, string>? headers = null, Dictionary<string, string>? parameters = null)
        {
            var request = new RestRequest(endpoint, method);

            // Add headers
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }

            // Add parameters
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    request.AddParameter(param.Key, param.Value);
                }
            }

            return await _client.ExecuteAsync(request);
        }
    }
}

