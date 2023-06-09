﻿using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
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
        public List<string> GetArray()
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

        [HttpPost("[action]")]
        public IActionResult PostItem(ArrayItemModel data)
        {
            if(data.Item==null) { return BadRequest(); }
            ArrayService.Array.Add(data.Item);
            return Ok(GetArray());
        }


        //https://localhost:7283/api/Rest/DeleteByIndex/2
        [HttpDelete("[action]/{index}")]
        public IActionResult DeleteByIndex(int index)
        {
            try
            {
                ArrayService.Array.RemoveAt(index);
                return Ok(GetArray());
            }
            catch (ArgumentOutOfRangeException) { return BadRequest(); }

        }

        //https://localhost:7283/api/Rest/UpdateByIndex/2
        [HttpDelete("[action]/{index}")]
        public IActionResult UpdateByIndex([FromBody] ArrayItemModel model, int index)
        {
            if (model.Item == null) { return BadRequest(); }
            try
            {
                ArrayService.Array[index] = model.Item ;
                return Ok(GetArray());
            }
            catch (ArgumentOutOfRangeException) { return BadRequest(); }

        }

    }

}
