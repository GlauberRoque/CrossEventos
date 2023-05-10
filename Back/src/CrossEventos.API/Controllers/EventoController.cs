using CrossEventos.Persistence;
using CrossEventos.Domain;
using Microsoft.AspNetCore.Mvc;
using CrossEventos.Persistence.Contexto;
using CrossEventos.Application.Contratos;

namespace CrossEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
  
        private readonly IEventosService _eventosService;

    public EventoController(IEventosService eventosService)
    {
            _eventosService = eventosService;
           
    }
// metodo de busca de eventos
    [HttpGet]
    public async Task<IActionResult> GetEventos()
    {
       try
       {
            var eventos = await _eventosService.GetAllEventosAsync(true);
            if (eventos == null) {
                return NotFound("Nenehum evento encontrado");
            }

            return Ok(eventos);
       }
       catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPorID(int id)
    {
        try
       {
            var evento = await _eventosService.GetEventosByIdAsync(id, true);
            if (evento == null) {
                return NotFound("Nenehum evento encontrado");
            }

            return Ok(evento);
       }
       catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
    }

    [HttpGet("{nome}/nome")]
    public async Task<IActionResult> GetbyNome(string nome)
    {
        try
       {
            var evento = await _eventosService.GetAllEventosByNomeAsync(nome, true);
            if (evento == null) {
                return NotFound("Nenehum evento encontrado");
            }

            return Ok(evento);
       }
       catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
    }

// metodo de inserir eventos
    [HttpPost]
    public async Task<IActionResult> Post(Evento model)
    {
         try
       {
            var evento = await _eventosService.AddEventos(model);
            if (evento == null) {
                return BadRequest("Erro ao tentar adicionar evento.");
            }

            return Ok(evento);
       }
       catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar eventos. Erro: {ex.Message}");
            }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Evento model)
    {
         try
       {
            var evento = await _eventosService.UpdateEventos(id, model);
            if (evento == null) {
                return BadRequest("Erro ao tentar adicionar evento.");
            }

            return Ok(evento);
       }
       catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar eventos. Erro: {ex.Message}");
            }
    }
   
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
          try
       {
            if(await _eventosService.DeleteEventos(id)){
                return Ok("Deletado");
            } else  {
                return BadRequest("Evento não deletado");
            }
       }
       catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar eventos. Erro: {ex.Message}");
            }
    }
}
