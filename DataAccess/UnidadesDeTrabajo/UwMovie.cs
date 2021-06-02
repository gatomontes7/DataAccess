using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DataAccess.UnidadesDeTrabajo
{
    public class UwMovie
    {

        ApplicationDbContext _DBcontext;

        public UwMovie()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;User ID=sa;Password=1234;Database=bd_Demo;");

            _DBcontext = new ApplicationDbContext(optionsBuilder.Options);

        }

        public IQueryable<Entidades.Movie> RetornarLista()
        {
            try
            {
                return this._DBcontext.Movie.OrderByDescending(e => e.id_Movie);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Entidades.Movie BuscarPeli(Int32 idMovie)
        {
            try
            {
                return this._DBcontext.Movie.FirstOrDefault(e => e.id_Movie == idMovie);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Boolean GuardarPeli(Entidades.Movie eMovie)
        {
            try
            {
                this._DBcontext.Movie.Add(eMovie);
                this._DBcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool ModificarPeli(Entidades.Movie eMovie)
        {
            using (var oTrans = _DBcontext.Database.BeginTransaction())
            {
                try
                {
                    Entidades.Movie eMovieAux = this._DBcontext.Movie.FirstOrDefault(e => e.id_Movie == eMovie.id_Movie);

                    eMovieAux.name = eMovie.name;
                    eMovieAux.id_category = eMovie.id_category;
                    eMovieAux.year = eMovie.year;
                    this._DBcontext.Entry(eMovieAux).State = EntityState.Modified;
                    this._DBcontext.SaveChanges();
                    oTrans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    oTrans.Rollback();
                    throw ex;
                }
            }

        }
        public bool EliminarPeli(int idMovie)
        {
            using (var oTrans = _DBcontext.Database.BeginTransaction())
            {
                try
                {
                    Entidades.Movie eMovieAux = this._DBcontext.Movie.FirstOrDefault(e => e.id_Movie == idMovie);
                    this._DBcontext.Movie.Remove(eMovieAux);
                    this._DBcontext.SaveChanges();
                    oTrans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    oTrans.Rollback();
                    throw ex;
                }
            }

        }
    }
}
