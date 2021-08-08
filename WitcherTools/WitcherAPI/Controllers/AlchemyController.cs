using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WitcherAPI.Models;
using WitcherAPI.Models.Alchemy;
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
            [FromQuery] Ingredients ingredients) {

            var alchemyProducts = _alchemyServices.GetAlchemyProducts().
                FindAll(a => 
                             (alchemyProductType.Length == 0 || alchemyProductType.Contains(a.Type)) && 
                             (a.Ingredients.Rebis == null || ingredients.Rebis == null ||
                             ingredients.Rebis >= a.Ingredients.Rebis) &&
                             (a.Ingredients.Hydragenum == null || ingredients.Hydragenum == null ||
                              ingredients.Hydragenum >= a.Ingredients.Hydragenum) &&
                             (a.Ingredients.Vermillion == null || ingredients.Vermillion == null ||
                              ingredients.Vermillion >= a.Ingredients.Vermillion) &&
                             (a.Ingredients.Vitriol == null || ingredients.Vitriol == null ||
                              ingredients.Vitriol >= a.Ingredients.Vitriol) &&
                             (a.Ingredients.Aether == null || ingredients.Aether == null ||
                              ingredients.Aether >= a.Ingredients.Aether) &&
                             (a.Ingredients.Quebrith == null || ingredients.Quebrith == null ||
                              ingredients.Quebrith >= a.Ingredients.Quebrith));
            

            return Ok(alchemyProducts);
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