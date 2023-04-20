using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LanguageController : Controller
    {
        [HttpGet("getall")]
        public async Task<IActionResult> Get()
        {
            try
            {
                LanguageServices languageServices = new LanguageServices();
                return Ok(await languageServices.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // https://localhost:7283/api/Language/getall/react
        [HttpGet("getall/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                LanguageServices languageServices = new LanguageServices();
                return Ok(await languageServices.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
