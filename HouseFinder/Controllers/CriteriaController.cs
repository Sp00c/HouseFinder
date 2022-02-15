using HouseFinder.Data;
using HouseFinder.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class CriteriaController : ControllerBase
    {
        private HouseFinderDbContext _context;

        public CriteriaController(HouseFinderDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet("GetCriterias")]
        public IActionResult Get()
        {
            try
            {
                var criterias = _context.Criteria.ToList();
                if (!criterias.Any()) return StatusCode(StatusCodes.Status404NotFound, "criteria not found");
                
                return Ok(criterias);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost("CreateCriteria")]
        public IActionResult Create([FromBody] CriteriaRequest request)
        {
            CriteriaDto dto = new CriteriaDto()
            {
                Criteria_Name = request.Name
            };

            try
            {
                _context.Criteria.Add(dto);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
            var criterias = _context.Criteria.ToList();
            return Ok(criterias);
        }


        [HttpPut("UpdateCriteria")]
        public IActionResult Update([FromBody] CriteriaRequest request)
        {
            try
            {
                var criteria = _context.Criteria.FirstOrDefault(c => c.Criteria_Id == request.Id);
                if (criteria == null) return StatusCode(StatusCodes.Status404NotFound, "Criteria not found");

                criteria.Criteria_Name = request.Name;

                _context.Entry(criteria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();

                var criterias = _context.Criteria.ToList();
                return Ok(criterias);

            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occurred");
            }
        }

        [HttpDelete("DeleteCriteria/{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            try
            {
                var criteria = _context.Criteria.FirstOrDefault(u => u.Criteria_Id == id);
                if (criteria == null) return StatusCode(StatusCodes.Status404NotFound, "Criteria not found");

                _context.Entry(criteria).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _context.SaveChanges();
            }
         
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }

            var criterias = _context.Criteria.ToList();
            return Ok(criterias);
        }
    }
}
