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
    
    public partial class tb_fiesta
    {
        public tb_fiesta()
        {
            this.tb_detalle_reserva = new HashSet<tb_detalle_reserva>();
            this.tb_especialidad = new HashSet<tb_especialidad>();
            this.tb_fiesta_evento = new HashSet<tb_fiesta_evento>();
            this.tb_pago_fiesta = new HashSet<tb_pago_fiesta>();
        }
    
        public int id_fiesta { get; set; }
        public string nombre { get; set; }
        public string flg_estado { get; set; }
        public int id_tipo_fiesta { get; set; }
    
        public virtual ICollection<tb_detalle_reserva> tb_detalle_reserva { get; set; }
        public virtual ICollection<tb_especialidad> tb_especialidad { get; set; }
        public virtual ICollection<tb_fiesta_evento> tb_fiesta_evento { get; set; }
        public virtual ICollection<tb_pago_fiesta> tb_pago_fiesta { get; set; }
        public virtual tb_tipo_fiesta tb_tipo_fiesta { get; set; }
    }
}
