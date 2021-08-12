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
        private readonly IAlchemyService _alchemyService;

        public AlchemyController(IAlchemyService alchemyService) {
            _alchemyService = alchemyService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AlchemyProduct>> GetAlchemyProducts(
            [FromQuery] AlchemyProductType[] alchemyProductType,
            [FromQuery] Ingredients ingredients) {
            if (ingredients.GetType().GetProperties().Any(a => a.GetValue(ingredients) != null)) {
                foreach (var propertyInfo in ingredients.GetType().GetProperties()
                    .Where(a => a.GetValue(ingredients) == null)) {
                    propertyInfo.SetValue(ingredients, 0);
                }
            }

            var alchemyProducts = _alchemyService.GetAlchemyProducts().FindAll(a =>
                (alchemyProductType.Length == 0 || alchemyProductType.Contains(a.Type)) &&
                (ingredients.Rebis == null && ingredients.Vermillion == null &&
                 ingredients.Aether == null && ingredients.Hydragenum == null && ingredients.Quebrith == null &&
                 ingredients.Vitriol == null) ||
                ingredients.Rebis >= a.Ingredients.Rebis &&
                ingredients.Hydragenum >= a.Ingredients.Hydragenum &&
                ingredients.Vermillion >= a.Ingredients.Vermillion &&
                ingredients.Vitriol >= a.Ingredients.Vitriol &&
                ingredients.Aether >= a.Ingredients.Aether &&
                ingredients.Quebrith >= a.Ingredients.Quebrith);

            return Ok(alchemyProducts);
        }

        [HttpGet("{id}")]
        public ActionResult<AlchemyProduct> GetAlchemyProduct(string id) {
            var alchemyProduct = _alchemyService.GetAlchemyProduct(id);
            if (alchemyProduct == null) {
                return NotFound();
            }

            return Ok(alchemyProduct);
        }
    }
}