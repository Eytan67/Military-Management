using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilitaryManagement.Model;

namespace MilitaryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private static List<Vehicle> _vehicles = new List<Vehicle>();
        private static List<Weapon> _weapons = new List<Weapon>();
        private static List<Personnel> _personnels = new List<Personnel>();

        [HttpGet]
        public IActionResult Get([FromQuery]AssetType type)
        {
            var res = new List<BaseAsset>();
            switch(type)
            {
                case AssetType.Vehicle:
                    res.AddRange(_vehicles);
                    break;
                case AssetType.Weapon:
                    res.AddRange(_weapons);
                    break;
                case AssetType.Personnel:
                    res.AddRange(_personnels);
                    break;
            }
            if(res.Count > 0)
                return Ok(res);
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody] BaseAsset asset)
        {
            if (asset == null)
                return BadRequest("Asset cannot be null");

            switch (asset.AssetType)
            {
                case AssetType.Vehicle:
                    var vehicle = asset as Vehicle;
                    if (vehicle != null)
                        _vehicles.Add(vehicle);
                    break;
                case AssetType.Weapon:
                    var weapon = asset as Weapon;
                    if (weapon != null)
                        _weapons.Add(weapon);
                    break;
                case AssetType.Personnel:
                    var personnel = asset as Personnel;
                    if (personnel != null)
                        _personnels.Add(personnel);
                    break;
                default:
                    return BadRequest("Unknown asset type");
            }

            return CreatedAtAction(nameof(Get), new { id = asset.Id }, asset);
        }

    }
}
