using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIRestful_Clientes.Data;
using APIRestful_Clientes.Models;
using Microsoft.VisualStudio.Web.CodeGeneration;


namespace APIRestful_Clientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private Logger _logger = new Logger();
        private readonly APIRestful_ClientesContext _context;

        public ClientesController(APIRestful_ClientesContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
        {
            _logger.Logs($"INFO:{DateTime.Now.ToString("[dd/MM/yyyy - HH:mm:ss]")}GET:api/Clientes - Se ha realizado una consulta masiva a la base de datos\n");
            return await _context.Clientes.OrderBy(x => x.LastName).ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> GetClientes(int id)
        {
            var clientes = await _context.Clientes.FindAsync(id);
            _logger.Logs($"INFO:{DateTime.Now.ToString("[dd/MM/yyyy - HH:mm:ss]")}GET:api/Clientes/{id} - Consulta de cliente con id {id}\n");
            if (clientes == null)
            {   
                _logger.Logs($"INFO:{DateTime.Now.ToString("[dd/MM/yyyy - HH:mm:ss]")}No se ha encontrado el cliente con id {id}\n");
                return NotFound();
            }
            _logger.Logs($"INFO:{DateTime.Now.ToString("[dd/MM/yyyy - HH:mm:ss]")}Datos del cliente con id {id}: {clientes.get_Cliente()}\n");
            return clientes;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientes(int id, Clientes clientes)
        {
            _logger.Logs($"INFO:{DateTime.Now.ToString("[dd/MM/yyyy - HH:mm:ss]")}PUT:api/Clientes/{id} - Actualizacion de datos del cliente con id {id}\n");
            if (id != clientes.Id)
            {
                _logger.Logs($"INFO:{DateTime.Now.ToString("[dd/MM/yyyy - HH:mm:ss]")}No se ha encontrado el cliente con id {id}\n");
                return BadRequest();
            }
            try
            {
                _logger.Logs($"INFO:{DateTime.Now.ToString("[dd/MM/yyyy - HH:mm:ss]")}Datos del cliente con id {id}: {clientes.get_Cliente()}\n");
                _context.Entry(clientes).State = EntityState.Modified;
                _logger.Logs($"INFO:{DateTime.Now.ToString("[dd/MM/yyyy - HH:mm:ss]")}Salvando cambios del cliente con id {id}\n");
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                
                _logger.Logs($"ERROR:{DateTime.Now.ToString("[dd/MM/yyyy - HH:mm:ss]")}Error al actualizar los datos del cliente con id {id}\n {e.ToString()}\n");
                throw;
                
            }
            _logger.Logs($"INFO:{DateTime.Now.ToString("[dd/MM/yyyy - HH:mm:ss]")}Datos del cliente con id {id} actualizados correctamente\n");
            return Ok(clientes);
        }

        // POST: api/Clientes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Clientes>> PostClientes(Clientes clientes)
        {   
            _logger.Logs($"INFO:{DateTime.Now.ToString("[dd/MM/yyyy - HH:mm:ss]")}POST:api/Clientes - Creacion de un nuevo cliente: {clientes.get_Cliente()}\n");
            _context.Clientes.Add(clientes);
            try
            {
                _logger.Logs($"INFO:{DateTime.Now.ToString("[dd/MM/yyyy - HH:mm:ss]")}Salvando datos del nuevo cliente\n");
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                if (ClientesExists(clientes.Id))
                {
                    _logger.Logs($"ERROR:{DateTime.Now.ToString("[dd/MM/yyyy - HH:mm:ss]")}El cliente existe ID: {clientes.Id}\n");
                    return Conflict();
                }
                else
                {
                    _logger.Logs($"ERROR:{DateTime.Now.ToString("[dd/MM/yyyy - HH:mm:ss]")}Error al crear el cliente con id {clientes.Id}\n {e.ToString()}");
                    throw;
                }
            }   

            _logger.Logs($"INFO:{DateTime.Now.ToString("[dd/MM/yyyy - HH:mm:ss]")}Cliente con id {clientes.Id} creado correctamente\n");
            return CreatedAtAction("GetClientes", new { id = clientes.Id }, clientes);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Clientes>> DeleteClientes(int id)
        {
            _logger.Logs($"INFO:{DateTime.Now.ToString("[dd/MM/yyyy - HH:mm:ss]")}DELETE:api/Clientes/{id} - Eliminacion del cliente con id {id}\n");
            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes == null)
            {
                _logger.Logs($"INFO:{DateTime.Now.ToString("[dd/MM/yyyy - HH:mm:ss]")}No se ha encontrado el cliente con id {id}\n");
                return NotFound();
            }

            _logger.Logs($"INFO:{DateTime.Now.ToString("[dd/MM/yyyy - HH:mm:ss]")}Datos del cliente con id {id}: {clientes.get_Cliente()}\n");
            try 
            { 
                _logger.Logs($"INFO:{DateTime.Now.ToString("[dd/MM/yyyy - HH:mm:ss]")}Eliminando el cliente con id {id}\n");
                _context.Clientes.Remove(clientes);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                if (ClientesExists(clientes.Id))
                {
                    _logger.Logs($"ERROR:{DateTime.Now.ToString("[dd/MM/yyyy - HH:mm:ss]")}Error al eliminar el cliente con id {clientes.Id}\n");
                    return Conflict();
                }
                else
                {
                    _logger.Logs($"ERROR:{DateTime.Now.ToString("[dd/MM/yyyy - HH:mm:ss]")}Error al eliminar el cliente con id {clientes.Id}\n {e.ToString()}\n");
                    throw;
                }
            }

            _logger.Logs($"INFO:{DateTime.Now.ToString("[dd/MM/yyyy - HH:mm:ss]")}Cliente con id {clientes.Id} eliminado correctamente\n");
            return clientes;
        }

        private bool ClientesExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}
