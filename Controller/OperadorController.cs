using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Data;
using Models.Models;
using Models.Models.ViewModel;

namespace Models.Controller
{
    public class OperadorController : ControllerBase
    {
        private readonly ContextApp _contextApp;

        public OperadorController(ContextApp contextApp)
        {
            _contextApp = contextApp;
        }

        [HttpGet("/v1/operadores")]
        public async Task<ActionResult> GetAsync()
        {
            try
            {
                var operadores = await _contextApp.Operadores
                    .Select(x=>new
                    {
                        x.Id,
                        x.Nome,
                        x.StatusOperador.Descricao
                    })
                    .AsNoTracking()
                    .ToListAsync();
                if (operadores == null)
                    return NotFound();
                return Ok(operadores);
            }
            catch (Exception)
            {

                return StatusCode(500, "Códido de erro: 03X01 - Erro ao tentar buscar os dados!");
            }
        }
        [HttpPost("/v1/operadores")]
        public async Task<IActionResult> PostAsync([FromBody] EditorOperadorViewModel model)
        {
            try
            {
                var operadores = new Operador();
                operadores.Nome = model.Nome;
                operadores.StatusOperadorId = model.StatusOperadorId;
                await _contextApp.Operadores.AddAsync(operadores);
                await _contextApp.SaveChangesAsync();
                return Created($"v1/operadores/{operadores.Id}", operadores);
            }
            catch (Exception)
            {


                return StatusCode(500, "Códido de erro: 03X03 - Erro ao tentar salvar!");
            }
        }
    }
}
