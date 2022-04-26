using Microsoft.AspNetCore.Mvc;
using smartMedRestApi.Models;
using smartMedRestApi.Mappings;
using Microsoft.EntityFrameworkCore;

namespace smartMedRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {

        private readonly Context _context;

        public MedicationController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Medication>>> Get()
        {
            return Ok(await _context.Medication.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Medication>>> AddMed(string Name, int Quantity)
        {   

            var med = await _context.Medication.Where(x => x.Name == Name.ToLower()).FirstOrDefaultAsync();

            if (med != null)
            {
                return BadRequest("Medication already available");
            }    
            
            _context.Medication.Add( new Medication{ Name=Name.ToLower(), 
                                                     Quantity=Quantity, 
                                                     Creation_Date=DateTimeOffset.UtcNow } );
            await _context.SaveChangesAsync();

            return Ok(await _context.Medication.ToListAsync());
        }

        [HttpDelete("{Name}")]
        public async Task<ActionResult<List<Medication>>> Delete(string Name)
        {
            var med = await _context.Medication.Where(x => x.Name == Name.ToLower()).FirstOrDefaultAsync();
            if (med == null)
            {
                return BadRequest("Medication not found");
            }
                
            _context.Medication.Remove(med);
            await _context.SaveChangesAsync();

            return Ok(await _context.Medication.ToListAsync());
        }

    }
}