using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilitaryManagement.Model;
using MilitaryManagement.DAL;

namespace MilitaryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly AssetDBContext _assetDBContext;
        public AssetController(AssetDBContext context)
        {
            this._assetDBContext = context;
        }      

        [HttpGet]
        public IActionResult Get([FromQuery]AssetType type)
        {
            switch(type)
            {
                case AssetType.Vehicle:
                    return Ok(_assetDBContext.Vehicles);
                    break;
                case AssetType.Weapon:
                    return Ok(_assetDBContext.Weapons);
                    break;
                case AssetType.Personnel:
                    return Ok(_assetDBContext.Personnels);
                    break;
                default:
                    return BadRequest();
            }
        }

        [HttpPost("personnel")]
        public IActionResult CreatePersonnel([FromBody] Personnel personnel)
        {
            if (personnel == null)
                return BadRequest("Asset cannot be null");

            _assetDBContext.Personnels.Add(personnel);
            _assetDBContext.SaveChanges();
            return Ok();

        }
        [HttpPost("weapon")]
        public IActionResult CreateWeapon([FromBody] Weapon weapon)
        {
            if (weapon == null)
            {
                return BadRequest("Asset cannot be null");

            }

            _assetDBContext.Weapons.Add(weapon);
            _assetDBContext.SaveChanges();

            return Ok();

        }

        [HttpPost("vehicle")]
        public IActionResult CreateVehicle([FromBody] Vehicle vehicle)
        {
            if (vehicle == null)
                return BadRequest("Asset cannot be null");

            _assetDBContext.Vehicles.Add(vehicle);
            _assetDBContext.SaveChanges();

            return Ok();

        }

    }
}
