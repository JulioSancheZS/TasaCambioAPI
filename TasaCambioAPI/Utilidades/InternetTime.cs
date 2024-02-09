namespace TasaCambioAPI.Utilidades
{
    public static class InternetTime
    {
        public static DateTimeOffset? GetCurrentTime()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var result = client.GetAsync("https://google.com",
                          HttpCompletionOption.ResponseHeadersRead).Result;
                    return result.Headers.Date;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
