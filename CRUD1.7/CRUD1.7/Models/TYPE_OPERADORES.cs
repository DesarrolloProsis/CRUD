namespace CRUD1._7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TYPE_OPERADORES
    {
        [Key]
        public int idenOperador { get; set; }

        [StringLength(10)]
        public string idOperador { get; set; }

        [StringLength(100)]
        public string numGea { get; set; }

        [StringLength(100)]
        public string numCapufe { get; set; }
    }
}
