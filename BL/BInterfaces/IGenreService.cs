﻿using BusinessLayer.BModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BInterfaces
{
    public interface IGenreService
    {
        void CreateOrUpdate(BGenre genre);
        BGenre GetGenre(int id);
        IEnumerable<BGenre> GetGenres();
        void DeleteGenre(int id);
        void Dispose();
    }
}
