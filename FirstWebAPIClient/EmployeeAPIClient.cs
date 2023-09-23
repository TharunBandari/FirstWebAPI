using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstWebAPI.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;



namespace FirstWebAPIClient
{
    internal class EmployeeAPIClient
    {
        static Uri uri = new Uri("http://localhost:5256/");
        public static async Task CallGetAllEmployee()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                List<EmpViewModel> employees = new List<EmpViewModel>();
                client.DefaultRequestHeaders
                    .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HTTPGET:
                HttpResponseMessage response = await client.GetAsync("ListAllEmployees");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    String json = await response.Content.ReadAsStringAsync();
                    employees = JsonConvert.DeserializeObject<List<EmpViewModel>>(json);
                    foreach (EmpViewModel emp in employees)
                    {
                        await Console.Out.WriteLineAsync($"{emp.EmpId},{emp.FirstName}:{emp.LastName}");
                    }
                }



            }
        }
        public static async Task AddNewEmployee()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                EmpViewModel empViewModel = new EmpViewModel()
                {
                    FirstName = "William",
                    LastName = "John",
                    City = "NY",
                    BirthDate = new DateTime(1980, 01, 01),
                    HireDate = new DateTime(2000, 01, 01),
                    Title = "Manager",
                };
                var myContent = JsonConvert.SerializeObject(empViewModel);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");



                //HttpPost:
                HttpResponseMessage response = await client.PostAsync("AddEmployee", byteContent);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    await Console.Out.WriteLineAsync(response.StatusCode.ToString());
                }
            }
        }
    }
}