using Microsoft.AspNetCore.Mvc;
using Application;
using Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrivateWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBatcherController : ControllerBase
    {
        // GET: api/<ProductBatcherController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProductBatcherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductBatcherController>
        [HttpPost]
        public void Post([FromBody] ProductBatcherDto dto)
        {
            ProductBatcher.tran(dto);
        }

        // PUT api/<ProductBatcherController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductBatcherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
