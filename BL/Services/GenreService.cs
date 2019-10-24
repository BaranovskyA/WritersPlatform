using BusinessLayer.BInterfaces;
using BusinessLayer.BModel;
using BusinessLayer.Utils;
using DataLayer.Entities;
using DataLayer.Interfaces;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class GenreService : IGenreService
    {
        IUnitOfWork Database { get; set; }

        public GenreService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateOrUpdate(BGenre genre)
        {
            if (genre.Id == 0)
            {

                Genres dgenre = new Genres() { GenreName=genre.GenreName };
                Database.Genres.Create(dgenre);
            }
            else
            {
                Genres editGenre = AutoMapper<BGenre, Genres>.Map(genre);
                Database.Genres.Update(editGenre);
            }
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public BGenre GetGenre(int id)
        {
            if (id != 0)
            {
                return AutoMapper<Genres, BGenre>.Map(Database.Genres.Get, (int)id);
            }
            return new BGenre();
        }

        public IEnumerable<BGenre> GetGenres()
        {
            return AutoMapper<IEnumerable<Genres>, List<BGenre>>.Map(Database.Genres.GetAll);
        }

        public void DeleteGenre(int id)
        {
            Database.Genres.Delete(id);
            Database.Save();
        }

    }
}
