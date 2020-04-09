using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormApp.API.Controllers
{
    [Authorize]
    [Route("app/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;

        }

        /// <summary>
        /// Pokazuje zapisane wartości
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();

            return Ok(values);
        }

        // GET app/values/5
        /// <summary>
        /// Pokazuje zapisaną jedną wartość np. id=5
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(value);
        }

        // POST app/values
        /// <summary>
        /// Wysyła wartość do bazy danych np. 5
        /// </summary>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT app/values/5
        /// <summary>
        /// Edytuje wartość z bazy danych np. 5
        /// </summary>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE app/values/5
        /// <summary>
        /// Usuwa wartość z bazy danych np. 5
        /// </summary>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}