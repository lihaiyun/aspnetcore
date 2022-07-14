using BWW.Models;
using Newtonsoft.Json;
using System.Text;

namespace BWW.Services
{
    public class LoanService
    {
        private readonly IConfiguration _configuration;

        public LoanService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Instalment>> GetInstalments(decimal loanAmt)
        {
            List<Instalment> list = new();

            string url = string.Format("{0}/api/Instalment/{1}", _configuration["ServiceBaseURL"], loanAmt);

            HttpClient client = new();
            Task<HttpResponseMessage> getTask = client.GetAsync(url);
            getTask.Wait();
            var responseMsg = getTask.Result;

            if (responseMsg.IsSuccessStatusCode)
            {
                // Read the response message in Json string format 
                string apiResponse = await responseMsg.Content.ReadAsStringAsync();

                // Deserialize Json into instalment object in a list
                List<Instalment>? result = JsonConvert.DeserializeObject<List<Instalment>>(apiResponse);
                if (result != null)
                {
                    list = result;
                }
            }
            return list;
        }

        public bool SubmitLoanApplication(LoanApplication application)
        {
            string url = string.Format("{0}/api/LoanApplication", _configuration["ServiceBaseURL"]);
            // Serialize LoanApplication object into Json
            StringContent content = new(JsonConvert.SerializeObject(application), Encoding.UTF8, "application/json");

            HttpClient client = new();
            // PostAsync sent Post request to specified uri with LoadApplication object
            Task<HttpResponseMessage>  postTask = client.PostAsync(url, content);
            postTask.Wait();
            var result = postTask.Result;

            return result.IsSuccessStatusCode;
        }
    }
}
