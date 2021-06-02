using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServicioWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        // GET: api/Movie
        [HttpGet]
        public IEnumerable<DataAccess.Entidades.Movie> Get()
        {
            DataAccess.UnidadesDeTrabajo.UwMovie oMovie = new DataAccess.UnidadesDeTrabajo.UwMovie();
            return oMovie.RetornarLista();   
        }

        // GET: api/Movie/5
        [HttpGet("{id}")]
        public DataAccess.Entidades.Movie Get(int id)
        {
            DataAccess.UnidadesDeTrabajo.UwMovie oMovie = new DataAccess.UnidadesDeTrabajo.UwMovie();      
            return oMovie.BuscarPeli(id);
        }

        // POST: api/Movie
        [HttpPost]
        public void Post([FromBody] DataAccess.Entidades.Movie eMovie)
        {
            DataAccess.UnidadesDeTrabajo.UwMovie oMovie = new DataAccess.UnidadesDeTrabajo.UwMovie();
            oMovie.GuardarPeli(eMovie);
        }

        // PUT: api/Movie/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DataAccess.Entidades.Movie eMovie)
        {
            DataAccess.UnidadesDeTrabajo.UwMovie oMovie = new DataAccess.UnidadesDeTrabajo.UwMovie();
            eMovie.id_Movie = id;
            oMovie.ModificarPeli(eMovie);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DataAccess.UnidadesDeTrabajo.UwMovie oMovie = new DataAccess.UnidadesDeTrabajo.UwMovie();
            oMovie.EliminarPeli(id);
        }


    }
}
