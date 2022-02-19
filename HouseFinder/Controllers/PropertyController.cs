using HouseFinder.Api.Data.Models;
using HouseFinder.Api.Models;
using HouseFinder.Data;
using HouseFinder.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace HouseFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class PropertyController : ControllerBase
    {
        private HouseFinderDbContext _context;

        public PropertyController(HouseFinderDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var properties = _context.Property.ToList();
                if (!properties.Any()) return NotFound("No properties found");
                return Ok(properties);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] PropertyRequest request)
        {
            PropertyDto dto = new PropertyDto()
            {
                Property_Id = request.Id,
                Property_HouseNumber = request.HouseNumber,
                Property_AddressFirstLine = request.AddressFirstLine,
                Property_AddressSecondLine = request.AddressSecondLine,
                Property_Region = request.Region,
                Property_Country = request.Country,
                Property_PostCode = request.PostCode,
                Property_Longitude = request.Longitude,
                Property_Latitude = request.Latitude
            };

            try
            {
                _context.Property.Add(dto);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
            var properties = _context.Property.ToList();
            return Ok(properties);
        }


        [HttpPut]
        public IActionResult Update([FromBody] PropertyRequest request)
        {
            try
            {
                var property = _context.Property.FirstOrDefault(c => c.Property_Id == request.Id);
                if (property == null) return BadRequest("Property not found");

                property.Property_HouseNumber = request.HouseNumber;
                property.Property_AddressFirstLine = request.AddressFirstLine;
                property.Property_AddressSecondLine = request.AddressSecondLine;
                property.Property_PostCode = request.PostCode;
                property.Property_Region = request.Region;
                property.Property_Country = request.Country;
                property.Property_Longitude = request.Longitude;
                property.Property_Latitude = request.Latitude;

                _context.Entry(property).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();

                var properties = _context.Property.ToList();
                return Ok(properties);

            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occurred");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                var property = _context.Property.FirstOrDefault(u => u.Property_Id == id);
                if (property == null) return NotFound("Property not found");

                _context.Entry(property).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _context.SaveChanges();
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }

            var properties = _context.Property.ToList();
            return Ok(properties);
        }
    }
}
