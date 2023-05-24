using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
       static List<string> values = new List<string> { "aa", "bb" };

        public ValuesController() { 
        }

        public List<string> GetValues()
        {
            return values.ToList();
        }

        [HttpGet("{id}")]
        public string GetValue(int id)
        {
            return values[id];
        }
        [HttpPost]
        public void Add()
        {
             values.Add("Value");
        }
        [HttpPut]
        public void Update()
        {
            values[1] = "new";
        }
        [HttpDelete]
        public void Delete()
        {
            values.Remove("Value");

        }

    }
}
