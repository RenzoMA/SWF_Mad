//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MadScienceAdo
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_trabajador
    {
        public tb_trabajador()
        {
            this.tb_asignacion = new HashSet<tb_asignacion>();
            this.tb_disponibilidad = new HashSet<tb_disponibilidad>();
            this.tb_especialidad = new HashSet<tb_especialidad>();
        }
    
        public int id_trabajador { get; set; }
        public string nombre { get; set; }
        public string flg_estado { get; set; }
    
        public virtual ICollection<tb_asignacion> tb_asignacion { get; set; }
        public virtual ICollection<tb_disponibilidad> tb_disponibilidad { get; set; }
        public virtual ICollection<tb_especialidad> tb_especialidad { get; set; }
    }
}
