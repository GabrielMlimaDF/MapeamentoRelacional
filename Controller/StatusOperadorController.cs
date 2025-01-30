using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Data;
using Models.Models;

namespace Models.Controller
{
    public class StatusOperadorController:ControllerBase
    {
        private readonly ContextApp _contextApp;

        public StatusOperadorController(ContextApp contextApp)
        {
            _contextApp = contextApp;
        }

        [HttpGet("/v1/status-operadores")]
        public async Task<ActionResult> GetAsync()
        {
            try
            {
                var statusoperadores = await _contextApp.StatusOperadores.ToListAsync();
                if (statusoperadores == null)
                    return NotFound();
                return Ok(statusoperadores);
            }
            catch (Exception)
            {

                return StatusCode(500, "Códido de erro: 03X01 - Erro ao tentar buscar os dados!");
            }
        }
        [HttpPost("/v1/status-operadores")]
        public async Task<IActionResult> PostAsync([FromBody] StatusOperador status)
        {
            try
            {
                await _contextApp.StatusOperadores.AddAsync(status);
                await _contextApp.SaveChangesAsync();
                return Created($"v1/status-operadores/{status.Id}", status);
            }
            catch (Exception)
            {


                return StatusCode(500, "Códido de erro: 03X03 - Erro ao tentar salvar!");
            }
        }

    }
}
