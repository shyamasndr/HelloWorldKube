using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace WebMVC.Pages
{
    public class IndexModel : PageModel
    {
        HttpClient client = new HttpClient();
        public string APIHostName { get; set; }
        public string APIResponseTime { get; set; }
        public string APIMessage { get; set; }
        public IndexModel(IConfiguration Configuration)
        {
            client.BaseAddress = new Uri(Configuration["HelloWorldApiUrl"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public void OnGet()
        {
            JArray responseArray = new JArray("Error", "Error", "Error");
            try
            {
                var response = client.GetStringAsync("api/values").Result;
                responseArray = JArray.Parse(response);
                APIMessage = responseArray[0].ToString();
                APIHostName = responseArray[1].ToString();
                APIResponseTime = responseArray[2].ToString();

            }
            catch (Exception ex)
            {
                APIMessage = ex.Message;

            }

        }
    }
}
