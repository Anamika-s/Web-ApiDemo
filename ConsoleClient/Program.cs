using ConsoleClient.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
             GetStudents().Wait();
            GetStudentById(2).Wait();
        }
        static async Task  GetStudents()
        {
            using (var client = new HttpClient())
            {
                //Send HTTP requests from here. 
                client.BaseAddress = new Uri("http://localhost:5259/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage response = await client.GetAsync("api/Student");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    var student = JsonConvert.DeserializeObject<List<Student>>(jsonString.Result);

                    foreach (var temp in student)
                    {
                        Console.WriteLine("Id:{0}\tName:{1}", temp.Id, temp.Name);
                        //  Console.WriteLine("No of Employee in Department: {0}", department.Employees.Count);
                    }
                }
                else
                {
                    Console.WriteLine(response.ReasonPhrase);
                    Console.WriteLine("Internal server Error");
                }

            }


        }

        static async Task GetStudentById(int id)
        {
            using (var client = new HttpClient())
            {
                //Send HTTP requests from here. 
                client.BaseAddress = new Uri("http://localhost:5259/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage response = await client.GetAsync("api/Student/"+id);
                if (response.IsSuccessStatusCode)
                {
                    Student student = await response.Content.ReadAsAsync<Student>();
                    Console.WriteLine("Id:{0}\tName:{1}", student.Id, student.Name);
                    //  Console.WriteLine("No of Employee in Department: {0}", department.Employees.Count);
                }
                else
                {
                    Console.WriteLine(response.ReasonPhrase);
                    Console.WriteLine("Internal server Error");
                }

            }
        }

    }
}