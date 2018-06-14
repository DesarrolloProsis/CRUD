namespace CRUD1._7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TYPE_TRAMO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TYPE_TRAMO()
        {
            TYPE_PLAZA = new HashSet<TYPE_PLAZA>();
        }

        [Key]
        public int idenTramo { get; set; }

        [StringLength(10)]
        public string idTramo { get; set; }

        [StringLength(100)]
        public string nomTramo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TYPE_PLAZA> TYPE_PLAZA { get; set; }
    }
}
