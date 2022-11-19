namespace ClientCsharpCliniqueRosemont.Source
{
    public class ApiConnecteur
    {
        protected HttpClient _httpClient;
        protected string _url;

        /// <summary>
        /// Client pour accéder aux méthodes de l'API avec authetification par clé API
        /// </summary>
        public ApiConnecteur()
        {
            _httpClient = new HttpClient();
            _url = "http://127.0.0.1:7002";

        }
    }
}
