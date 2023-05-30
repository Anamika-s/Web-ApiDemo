using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_ApiDemo.Models;

namespace Web_ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        static List<Student> list = null;
        void Initialize()
        {
            list = new List<Student>()
                {
                    new Student(){ Id=1, Name="Aashna", BatchCode="DotNet", Marks=90},

                    new Student(){ Id=2, Name="Priynaka", BatchCode="DotNet", Marks=87},
                    new Student(){ Id=3, Name="Tisha", BatchCode="SAP", Marks=98},
                    new Student(){ Id=4, Name="Naveen", BatchCode="SAP", Marks=90},
                    new Student(){ Id=5, Name="Siddhant", BatchCode="DotNet", Marks=90},
                    new Student(){ Id=6, Name="Vaibhav", BatchCode="DotNet", Marks=90},
                };

        }
        public StudentController()
        {
            if (list == null)
                Initialize();
        }
        public List<Student> Get()
        {
            return list;
        }

        [HttpGet("{id}")]
        public Student GetStudent(int id)
        {
            return list[id-1];
        }

        [HttpPost]
        public void AddStudent(Student student)
        {
            list.Add(student);
        }

        [HttpPut("{id}")]
        public void EditStudent(int id, Student student)
        {
            (from p in list
             where p.Id == id
             select p).ToList()
             .ForEach(x =>
             {
                 x.Name = student.Name;

                 x.BatchCode = student.BatchCode;
                 x.Marks = student.Marks;
             }
             );


        }

        [HttpDelete("{id}")]
        public void DeleteStudent(int id)
        {
            Student student = list.Where(x=>x.Id== id-1).FirstOrDefault();    
            if(student != null)
            list.Remove(student);
        }

    }
}
