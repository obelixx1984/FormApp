using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace FormApp.API.Controllers
{
    [Route("app/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// Pokazuje zapisane wartości
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET app/values/5
        /// <summary>
        /// Pokazuje zapisaną 1 wartość np. 5
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST app/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT app/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE app/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}