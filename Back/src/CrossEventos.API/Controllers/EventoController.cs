using CrossEventos.API.Data;
using CrossEventos.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrossEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
  
        private readonly DataContext _context;

    public EventoController(DataContext context)
    {
            _context = context;
    }
// metodo de busca de eventos
    [HttpGet]
    public IEnumerable<Evento> GetEventos()
    {
       return _context.Eventos;
    }
    [HttpGet("{id}")]
    public Evento EventosPorID(int id)
    {
       return _context.Eventos.FirstOrDefault(evento => evento.EventoID == id);
    }

// metodo de inserir eventos
    [HttpPost]
    public String PostEventos()
    {
        return "Exemplo de post";
    }

    [HttpPut("{id}")]
    public String PutEventos(int id)
    {
        return $"Exemplo de put com id = {id}";
    }
   
    [HttpDelete("{id}")]
    public String DeleteEventos(int id)
    {
        return $"Exemplo de delete com id = {id}";
    }
}
