using AdventureWorks.NetCore.Repository;
using AdventureWorks.NetCore.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AdventureWorks.Web.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly MoDbContext _context;
        public AddressesController(MoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Address>> Get()
        {
            if (_context.Addresses ==null)
            {
                return (IEnumerable<Address>)NotFound();
            }
            return await _context.Addresses.ToListAsync();

        }
        [HttpGet("id")]
        public async Task<ActionResult<Address>> GetById(int id)
        {
            if (_context.Addresses == null)
            {
                return NotFound();
            }
            var address = await _context.Addresses.FindAsync(id);

            if (address==null)
            {
                return NotFound();
            }

            return address;

        }
        [HttpPost]
        public async Task<ActionResult<Address>> Post(Address address)
        {

            if (_context.Addresses ==null)
            {
                return Problem("Ocurrio un error, no existe la entidad");
            }

            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Registro Creado Correctemante", new {id=address.AddressId},address);

        }
        /// <summary>
        /// Elimina un registro de la base de datos validando si existe
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve 200 OK si es correcto</returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Addresses == null)
            {
                return NotFound();
            }
            var address = await _context.Addresses.FindAsync(id);
            if (address==null)
            {
                return NotFound();
            }

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        /// <summary>
        /// Actualiza una Dirección validando si existe en 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="address"></param>
        /// <returns></returns>
            
        
        [HttpPut("id")]
        public async Task<IActionResult> UpdateAddress(int id, Address address)
        {
            if (id!=address.AddressId)
            {
                return BadRequest();
            }
            _context.Entry(address).State= EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
             return NoContent();

        }

        private bool AddressExists(int id)
        {
            return (_context.Addresses?.Any(e => e.AddressId == id)).GetValueOrDefault();

        }




    }
}
