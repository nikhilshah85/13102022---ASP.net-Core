namespace bankingAPPMVC.Models
{
    public class AccountsAPI
    {
        public int accNo { get; set; }

        public string accName { get; set; }
        public string accType { get; set; }
        public double accBalance { get; set; }
        public bool accIsActive { get; set; }

        List<AccountsAPI> accDetails = new List<AccountsAPI>();

        public List<AccountsAPI> GetAccountsFromAPI()
        {
            string url = "https://localhost:7143/api/Banking/importantacc";
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var call = client.GetAsync(url);
            if (call.Result.IsSuccessStatusCode)
            {
                //this is a successfull call
                var result = call.Result.Content.ReadAsAsync<List<AccountsAPI>>();
                result.Wait();
                accDetails = result.Result;
                return accDetails;
                
            }
            else
            {
                throw new Exception("Call Failed, Please contact Admin");
            }


        }
    }
}
