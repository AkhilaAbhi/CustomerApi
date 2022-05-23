using CustomerWebApp.Helper;
using CustomerWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CustomerWebApp.Controllers
{
    public class HomeController : Controller
    {
        CustomerDetailsApi _api = new CustomerDetailsApi();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<CustomerData> Customers = new List<CustomerData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Customer");
            if(res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                Customers = JsonConvert.DeserializeObject<List<CustomerData>>(results);    
            }
            return View(Customers);
        }

        public async Task<IActionResult> Details(int id)
        {
            var Customer = new CustomerData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Customer/{id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                Customer = JsonConvert.DeserializeObject<CustomerData>(results);
            }
            return View(Customer);
        }
        public ActionResult NewCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewCustomer(CustomerData customer)
        {
            HttpClient client = _api.Initial();

            var postTask = client.PostAsJsonAsync<CustomerData>("api/Customer/",customer);
            postTask.Wait();

            var result = postTask.Result;
            if(result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var Customer = new CustomerData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/Customer/{id}");

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}