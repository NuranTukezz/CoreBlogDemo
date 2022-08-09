using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlogDemo.Controllers
{
    public class EmployeeTestController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var repsonseMessage = await httpClient.GetAsync("https://localhost:44371/api/Default");
            var jsonString = await repsonseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "Application/json");
            var repsonseMessage = await httpClient.PostAsync("https://localhost:44371/api/Default", content);
            if (repsonseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }
        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var httpClient = new HttpClient();
            var repsonseMessage = await httpClient.GetAsync("https://localhost:44371/api/Default/" + id);

            if (repsonseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await repsonseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Class1>(jsonEmployee);
                return View(values);
            }

            return RedirectToAction("Index");

        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            var content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var repsonseMessage = await httpClient.PutAsync("https://localhost:44371/api/Default/", content);

            if (repsonseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public async Task<IActionResult>DeleteEmployee(int id)
        {
            var httpClient = new HttpClient();
            var repsonseMessage = await httpClient.DeleteAsync("https://localhost:44371/api/Default/" + id);

            if (repsonseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();

        }


    }
    public class Class1
    {
        public int ID { get; set; }
        public string Name { get; set; }

    }

}