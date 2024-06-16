using Microsoft.AspNetCore.Mvc;

namespace WeatherNewsletter.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class WeatherNewsletterController : ControllerBase
    {
        [HttpPost]
        public IActionResult RealizarRegistro(/*informações para envio de email*/)
        {


            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult Descadastrar(Guid id)
        {


            throw new NotImplementedException();
        }

        [HttpGet]
        public void GetTodosRegistros()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public void GetRegistroPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
