using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD1._7.Models
{
    public class ModeloVirtual
    {
        public List<carriles> Carriles { get; set; }
        public List<tramos> Tramos { get; set; }
        public List<plazas> Plazas { get; set; }
    }


    public class tramos
    {
        public int idenTramo { get; set; }
        public string idTramo { get; set; }
        public string nomTramo { get; set; }
    }

    public class plazas
    {
        public int idenPlaza { get; set; }
        public string idPlaza { get; set; }
        public string nomPlaza { get; set; }
    }

    public class carriles
    {
        public int idenCarril { get; set; }
        public string idCarril { get; set; }
        public string numCarril { get; set; }
        public string numTramo { get; set; }
    }
}