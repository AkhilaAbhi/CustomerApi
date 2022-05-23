namespace CustomerWebApp.Helper
{
    public class CustomerDetailsApi
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5255/");
            return client;
        }
    }
}
