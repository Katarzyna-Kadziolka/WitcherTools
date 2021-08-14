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
            if (!ingredients.IsEmpty()) ingredients.SetDefaultValues();
            
            var alchemyProducts = _alchemyService.GetAlchemyProducts().Where(a =>
                (alchemyProductType.Length == 0 || alchemyProductType.Contains(a.Type)) &&
                (ingredients.IsEmpty() || ingredients.Contains(a.Ingredients)));

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