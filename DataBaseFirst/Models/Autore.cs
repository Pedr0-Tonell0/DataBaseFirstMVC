//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataBaseFirst.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Autore
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Autore()
        {
            this.Libros = new HashSet<Libro>();
        }
    
        public int ID { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public int IdPais { get; set; }
    
        public virtual Pais Pais { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Libro> Libros { get; set; }
    }
}
