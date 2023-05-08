using CrossEventos.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrossEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
  
    public IEnumerable<Evento> _evento = new Evento[]{
            new Evento() {
            EventoID = 1,
            Nome = "Kvra Games",
            Local = "Geraldão",
            DataEvento = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy"),
            QtdPessoas = 1000,
            ImagemURL = "kvra.png"
            },
            new Evento() {
            EventoID = 2,
            Nome = "Deep Games",
            Local = "Deep Box",
            DataEvento = DateTime.Now.AddDays(15).ToString("dd/MM/yyyy"),
            QtdPessoas = 500,
            ImagemURL = "deepGames.png"
            }
    };

    public EventoController()
    {
       
    }
// metodo de busca de eventos
    [HttpGet]
    public IEnumerable<Evento> GetEventos()
    {
       return _evento;
    }
    [HttpGet("{id}")]
    public IEnumerable<Evento> EventosPorID(int id)
    {
       return _evento.Where(evento => evento.EventoID == id);
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
