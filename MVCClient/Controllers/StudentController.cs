//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCClient.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MVCClient.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentController
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                List<Student> students = new List<Student>();
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
                    students = JsonConvert.DeserializeObject<List<Student>>(jsonString.Result);

                }
                else
                {
                    ViewBag.msg = response.ReasonPhrase;

                }
                return View(students);

            }
        }

        // GET: StudentController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            using (var client = new HttpClient())
            {
                Student student = new Student();
                //Send HTTP requests from here. 
                client.BaseAddress = new Uri("http://localhost:5259/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage response = await client.GetAsync("api/Student/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    student = JsonConvert.DeserializeObject<Student>(jsonString.Result);

                }
                else
                {
                    ViewBag.msg = response.ReasonPhrase;

                }
                return View(student);
            }
        }
        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Student student)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    //Send HTTP requests from here. 
                    client.BaseAddress = new Uri("http://localhost:5259/");

                     HttpResponseMessage response = await client.PostAsJsonAsync("api/Student", student);

                    if (response.IsSuccessStatusCode)
                    {
                        // Get the URI of the created resource.  
                        return RedirectToAction("Index");
                    }
                    else 
                        return View(student);
                }

            }
            catch
            {
                return View(student);
            }  
        }


        // GET: StudentController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            using (var client = new HttpClient())
            {
                Student student = new Student();
                //Send HTTP requests from here. 
                client.BaseAddress = new Uri("http://localhost:5259/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage response = await client.GetAsync("api/Student/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    student = JsonConvert.DeserializeObject<Student>(jsonString.Result);
                    return View(student);
                }
                else
                {
                    ViewBag.msg = response.ReasonPhrase;
                    return View();
                }

            }

        }
            // POST: StudentController/Edit/5
            [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Student student)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //Send HTTP requests from here. 
                    client.BaseAddress = new Uri("http://localhost:5259/");

                    //PUT Method  
                     HttpResponseMessage response = await client.PutAsJsonAsync("api/Student/" + id, student);
                    if (response.IsSuccessStatusCode)

                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else 
                        return View(student);
                }

               
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                Student student = new Student();
                //Send HTTP requests from here. 
                client.BaseAddress = new Uri("http://localhost:5259/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage response = await client.GetAsync("api/Student/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    student = JsonConvert.DeserializeObject<Student>(jsonString.Result);
                    return View(student);
                }
                else
                {
                    ViewBag.msg = response.ReasonPhrase;
                    return View();
                }
            }
        }

            // POST: StudentController/Delete/5
            [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Deleted(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //Send HTTP requests from here. 
                    client.BaseAddress = new Uri("http://localhost:5259/");

                    HttpResponseMessage response = await client.DeleteAsync("api/Student/" + id);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                        return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
