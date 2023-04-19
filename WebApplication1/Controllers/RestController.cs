using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestController : ControllerBase
    {
        //https://localhost:7283/api/Rest/index/1
        //[HttpGet("[action]/{id}")]
        //public IActionResult Index(int id)
        //{
        //    return id % 2 == 0 ? Ok("число четное") : BadRequest();
        //}

        //https://localhost:7283/api/Rest/check-number/1
        [HttpGet("check-number/{id}")]
        public IActionResult Index(int id)
        {
            return id % 2 == 0 ? Ok("число четное") : BadRequest();
        }

        //https://localhost:7283/api/Rest/GetArray
        //[HttpGet("[action]")]
        //public IActionResult GetArray()
        //{
        //    return Ok(ArrayService.Array);
        //}

        [HttpGet("[action]")]
        public string[] GetArray()
        {
            return ArrayService.Array;
        }

        [HttpGet("[action]/{index}")]
        public IActionResult GetArray(int index)
        {
            try
            {
                return Ok(ArrayService.Array[index - 1]);
            }
            catch (IndexOutOfRangeException)
            {
                return BadRequest();
            }
        }


    }

}
