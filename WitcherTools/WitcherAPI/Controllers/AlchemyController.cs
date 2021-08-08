using System.Collections.Generic;
using System.Linq;
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
        public ActionResult<IEnumerable<AlchemyProduct>> GetAlchemyProducts(
            [FromQuery] AlchemyProductType[] alchemyProductType, 
            [FromQuery] IngredientsQuery ingredientsQuery) {

            return Ok(_alchemyServices.GetAlchemyProducts());
        }

        [HttpGet("{id}")]
        public ActionResult<AlchemyProduct> GetAlchemyProduct(string id) {
            var alchemyProduct = _alchemyServices.GetAlchemyProducts().Find(a => a.Id == id);
            if (alchemyProduct == null) {
                return NotFound();
            }

            return Ok(alchemyProduct);
        }
    }
}