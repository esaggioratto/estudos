using System.Net;
using VaiBrasil.service.model;
using Newtonsoft.Json;
namespace VaiBrasil.service
{
    public class ViaCepService
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        /// <summary>
        /// consulta o endereco completo do cep informado como parametro
        /// </summary>
        /// <param name="cep"></param>
        public static ViaCepModel GetAdress(string cep)
        {

            string novaUrl = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(novaUrl);

            ViaCepModel end = JsonConvert.DeserializeObject<ViaCepModel>(conteudo);

            if (string.IsNullOrEmpty(end.Cep))
            { return null; }
            else
            { return end; }

        }

    }
}
