namespace CoincapLibrary
{
    /// <summary>
    /// CoinCap 2.0 RESTful API is currently in production!
    /// The CoinCap team is excited to offer you new endpoints and more clarity on pricing! CoinCap 2.0 launched on September 26, 2018.
    /// Please let us know what you like, what you would hope to see, or any bugs/changes that you'd like to document. 
    /// The easiest way to submit feedback to our team is to fill out a support ticket here.
    /// The old CoinCap API is deprecated and was shut down on March 1, 2019. 
    /// For any issues with transitioning from the old CoinCap API to the new, please submit feedback via the zendesk link above!
    /// </summary>
    public abstract class CoincapBase
    {
        protected abstract string UriBase { get; set; }
        protected virtual async Task<string?> RequestDataAsync(Uri uri)
        {
            using var httpClient = new HttpClient();
            using var request = new HttpRequestMessage
            {
                RequestUri = uri,
                Method = HttpMethod.Get
            };

            request.Headers.Add("Accept", "*/*");

            var response = await httpClient.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        protected virtual async Task<Value?> DeserializeDataAsync<Value>(Uri uri)
        {
            var data = await RequestDataAsync(uri);

            var document = JsonDocument.Parse(data).RootElement.GetProperty("data");

            return document.Deserialize<Value>();
        }

        protected virtual string? ConvertStructToString<TStruct>(TStruct? value) where TStruct : struct
            => value.HasValue ? value.Value.ToString() : null;
    }
}
