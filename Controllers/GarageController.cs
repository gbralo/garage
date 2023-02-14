using BikeGarageAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeGarageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarageController : ControllerBase
    {

        private static List<Garage> garages = new List<Garage> {
            new Garage{ Id = 1,Name="Test", Country="Croatia", CreatedOn= DateTime.Now, OwnerId=1, Type="Service", Description="Some desc...", Location="Zagreb" },
            new Garage{ Id = 2,Name="Test 2", Country="Croatia", CreatedOn= DateTime.Now.AddDays(1), OwnerId=1, Type="Home()", Description="Some desc...", Location="Samobor" }
            };


        [HttpGet]
        public async Task<ActionResult<List<Garage>>> GetAllGarages()
        {
            return Ok(garages);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Garage>> GetSingleGarage(int id)
        {
            var hero = garages.Find(x => x.Id == id);   
            return hero!= null ? Ok(hero): NotFound("Garage not found!");
        }


        [HttpPost]
        public async Task<ActionResult<Garage>> AddGarage([FromBody]Garage garage)
        {
            garages.Add(garage);
            return Ok(garages);
        }







    }
}
