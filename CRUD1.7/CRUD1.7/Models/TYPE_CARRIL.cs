namespace CRUD1._7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TYPE_CARRIL
    {
        [Key]
        public int idenCarril { get; set; }

        [StringLength(10)]
        public string idCarril { get; set; }

        [StringLength(10)]
        public string numCarril { get; set; }

        [StringLength(10)]
        public string numTramo { get; set; }

        public int? idPlaza { get; set; }

        public virtual TYPE_PLAZA TYPE_PLAZA { get; set; }
    }
}
