namespace CRUD1._7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TYPE_PLAZA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TYPE_PLAZA()
        {
            TYPE_CARRIL = new HashSet<TYPE_CARRIL>();
        }

        [Key]
        public int idenPlaza { get; set; }

        [StringLength(10)]
        public string idPlaza { get; set; }

        [StringLength(100)]
        public string nomPlaza { get; set; }

        public int? idTramo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TYPE_CARRIL> TYPE_CARRIL { get; set; }

        public virtual TYPE_TRAMO TYPE_TRAMO { get; set; }
    }
}
