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
    
    public partial class tb_tipo_pago
    {
        public tb_tipo_pago()
        {
            this.tb_asignacion = new HashSet<tb_asignacion>();
            this.tb_pago_fiesta = new HashSet<tb_pago_fiesta>();
        }
    
        public int id_tipo_pago { get; set; }
        public string nombre { get; set; }
        public string flg_estado { get; set; }
    
        public virtual ICollection<tb_asignacion> tb_asignacion { get; set; }
        public virtual ICollection<tb_pago_fiesta> tb_pago_fiesta { get; set; }
    }
}
