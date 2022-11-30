using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MedAdvisor.API.Test.Infrastructure
{
    public static class TestExtensions
    {
        private static JsonSerializerOptions GetJsonOptions()
        {
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            };

            jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

            return jsonSerializerOptions;
        }

        public static async Task<T> ExecuteAsync<T>(this HttpClient httpClient,
            HttpMethod method,
            string url,
            string authorizationHeader,
            string requestBody = null)
        {

            HttpRequestMessage request = new()
            {
                RequestUri = new Uri(url, url.StartsWith("http") ? UriKind.Absolute : UriKind.Relative),
                Method = method
            };

            if (!string.IsNullOrEmpty(requestBody))
            {
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            }

            string[] headerParts = authorizationHeader.Split(" ");
            request.Headers.Authorization = new AuthenticationHeaderValue(headerParts[0], headerParts[1]);

            HttpResponseMessage response = await httpClient.SendAsync(request);

            string json = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(json))
            {
                return default;
            }

            return JsonSerializer.Deserialize<T>(json, GetJsonOptions());
        }

        public static async Task<(HttpStatusCode, T)> ExecuteWithFullResultAsync<T>(this HttpClient httpClient,
            HttpMethod method,
            string url,
            string authorizationHeader,
            string requestBody = null)
        {

            HttpRequestMessage request = new()
            {
                RequestUri = new Uri(url, url.StartsWith("http") ? UriKind.Absolute : UriKind.Relative),
                Method = method
            };

            if (!string.IsNullOrEmpty(requestBody))
            {
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            }

            if (!string.IsNullOrEmpty(authorizationHeader))
            {
                string[] headerParts = authorizationHeader.Split(" ");
                request.Headers.Authorization = new AuthenticationHeaderValue(headerParts[0], headerParts[1]);
            }

            HttpResponseMessage response = await httpClient.SendAsync(request);

            var httpStatus = response.StatusCode;
            string json = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(json))
            {
                return (httpStatus, default(T));
            }

            return (httpStatus, JsonSerializer.Deserialize<T>(json, GetJsonOptions()));
        }

        public static async Task<HttpStatusCode> ExecuteAsync(this HttpClient httpClient,
            HttpMethod method,
            string url,
            string authorizationHeader,
            string requestBody = default)
        {

            HttpRequestMessage request = new()
            {
                RequestUri = new Uri(url, url.StartsWith("http") ? UriKind.Absolute : UriKind.Relative),
                Method = method
            };

            if (!string.IsNullOrEmpty(requestBody))
            {
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            }

            if (!string.IsNullOrEmpty(authorizationHeader))
            {
                string[] headerParts = authorizationHeader.Split(" ");
                request.Headers.Authorization = new AuthenticationHeaderValue(headerParts[0], headerParts[1]);
            }

            HttpResponseMessage response = await httpClient.SendAsync(request);

            return response.StatusCode;
        }

        public static async Task<(HttpStatusCode, T)> ExecuteWithFullResultAsync<T>(this HttpClient httpClient,
            HttpMethod method,
            string url,
            string authorizationHeader,
            MultipartFormDataContent form)
        {

            HttpRequestMessage request = new()
            {
                RequestUri = new Uri(url, url.StartsWith("http") ? UriKind.Absolute : UriKind.Relative),
                Method = method
            };

            if (form != null)
            {
                request.Content = form;
            }

            if (!string.IsNullOrEmpty(authorizationHeader))
            {
                string[] headerParts = authorizationHeader.Split(" ");
                request.Headers.Authorization = new AuthenticationHeaderValue(headerParts[0], headerParts[1]);
            }

            HttpResponseMessage response = await httpClient.SendAsync(request);

            var httpStatus = response.StatusCode;
            string json = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(json))
            {
                return (httpStatus, default(T));
            }

            return (httpStatus, JsonSerializer.Deserialize<T>(json, GetJsonOptions()));
        }
    }
}
