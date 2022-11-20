namespace ClientCsharpCliniqueRosemont.Source
{
    public class ApiConnecteur
    {
        protected HttpClient _httpClient;
        protected string _url;


        public ApiConnecteur()
        {
            _httpClient = new HttpClient();
            _url = "http://127.0.0.1:7002";
        }
    }
}
