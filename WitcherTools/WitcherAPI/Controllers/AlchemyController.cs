using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WitcherAPI.Models;
using WitcherAPI.Services;

namespace WitcherAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AlchemyController : ControllerBase {
        private readonly IAlchemyServices _alchemyServices;

        public AlchemyController(IAlchemyServices alchemyServices) {
            _alchemyServices = alchemyServices;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AlchemyProduct>> GetAlchemyProducts() {

            return Ok();
        }

    }
}