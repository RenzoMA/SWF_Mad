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
    
    public partial class tb_tienda
    {
        public tb_tienda()
        {
            this.tb_reserva = new HashSet<tb_reserva>();
        }
    
        public int id_tienda { get; set; }
        public Nullable<int> id_zona { get; set; }
        public string nombre { get; set; }
        public string flg_estado { get; set; }
        public string direccion { get; set; }
    
        public virtual ICollection<tb_reserva> tb_reserva { get; set; }
        public virtual tb_zona tb_zona { get; set; }
    }
}