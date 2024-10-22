﻿using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceNoticias
    {
        IEnumerable<NOTICIA> GetNoticias();
        IEnumerable<string> GetNoticiaTipo();
        NOTICIA Save(NOTICIA noticia);
        NOTICIA GetNoticiasById(int id);
        void Delete(int id);
    }
}