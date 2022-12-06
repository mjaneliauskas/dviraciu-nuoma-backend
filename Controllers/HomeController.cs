using dviraciu_nuoma_backend.Models;
using dviraciu_nuoma_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace dviraciu_nuoma_backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IDviratisService _dviratisService;
        private readonly IKelioneService _kelioneService;
        public HomeController(IUserService userService, IDviratisService dviratisService, IKelioneService kelioneService)
        {
            _userService = userService;
            _dviratisService = dviratisService;
            _kelioneService = kelioneService;
        }
        [HttpPost]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAll());
        }
        [HttpPost]
        public IActionResult GetUserByUsernameAndPassword(string username, string password)
        {
            var response = _userService.GetUserByUsernamePassword(username, password);
            return response != null ? Ok() : BadRequest();
        }
        [HttpPost]
        public IActionResult CreateNewBike(string modelioPavadinimas, DviracioTipasEnum tipas, double kaina, string specifikacija)
        {
            var response = _dviratisService.SukurtiDvirati(modelioPavadinimas, tipas, kaina, specifikacija);
            return response ? Ok() : BadRequest();
        }
        [HttpDelete]
        public IActionResult DeleteBike(Guid dviracioId)
        {
            var response = _dviratisService.IstrintiDvirati(dviracioId);
            return response ? Ok() : BadRequest();
        }
        [HttpGet]
        public IActionResult GetAllBikes(DviracioStatusasEnum? filtras = null)
        {
            var response = _dviratisService.GetAll(filtras);
            return Ok(response);
        }
        [HttpGet]
        public IActionResult GetDviracioSpecifikacija(Guid dviracioId)
        {
            var response = _dviratisService.GetDviracioSpecifikacijaById(dviracioId);
            return Ok(response);
        }
        [HttpGet]
        public IActionResult StartKelione(Guid dviracioId, string username)
        {
            var response = _kelioneService.StartKelione(dviracioId, username);
            return response.Equals(Guid.Empty) ? StatusCode(StatusCodes.Status500InternalServerError, "Nepavyko pradeti keliones. Serverio klaida") : Ok(response);
        }
        [HttpGet]
        public IActionResult EndKelione(Guid kelionesId)
        {
            var response = _kelioneService.EndKelione(kelionesId);
            return response ? Ok(response) : StatusCode(StatusCodes.Status500InternalServerError, "Nepavyko pabaigti keliones. Serverio klaida");
        }
    }
}
