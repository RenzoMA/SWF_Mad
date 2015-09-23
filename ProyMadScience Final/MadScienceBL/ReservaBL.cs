using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MadScienceAdo;
using MadScienceAdo.Servicios;
using MadScienceBE;
using System.Data;
using MadScienceBL.Util;
using System.Threading.Tasks;

namespace MadScienceBL
{
    public class ReservaBL
    {
        DaoFactory servicio = DaoFactory.getFabrica();
        ServicioGenerico<ReservaEntity> servicioReserva;
        ServicioGenerico<TipoEventoEntity> servicioTipoEvento;
        ServicioGenerico<TiendaEntity> servicioTienda;
        ServicioGenerico<DetalleReservaEntity> serviceFastDetalle;

        FiestaBL servicioFiesta;
        TortaBL servicioTorta;
        SaborBL servicioSabor;
        TipoEventoBL tipoEvento;
        TiendaBL servicioTiendaBL;
        AsignacionBL servicioAsignacion;
        DetalleReservaBL servicioDetalle;
        TipoFiestaBL servicioTipoFiesta;

        public ReservaBL()
        {
            servicioReserva = servicio.getReserva(Constantes.COM);
            servicioTipoEvento = servicio.getTipoEvento(Constantes.COM);
            servicioTienda = servicio.getTienda(Constantes.COM);
            serviceFastDetalle = servicio.getDetalleReserva(Constantes.COM);
            servicioFiesta = new FiestaBL();
            servicioTorta = new TortaBL();
            servicioSabor = new SaborBL();
            tipoEvento = new TipoEventoBL();
            servicioTiendaBL = new TiendaBL();
            servicioAsignacion = new AsignacionBL();
            servicioDetalle = new DetalleReservaBL();
            servicioTipoFiesta = new TipoFiestaBL();
        }
        public bool Eliminar(int codigo)
        {
            ReservaEntity objReserva = new ReservaEntity();
            objReserva.Codigo = codigo;
            List<DetalleReservaEntity> listaDetalles = servicioDetalle.ListarTodos().Where(tx => tx.CodigoReserva == codigo).ToList();
            foreach (DetalleReservaEntity detalle in listaDetalles)
            {
                if (!servicioDetalle.Eliminar(detalle))
                {
                    return false;
                }
            }
            return servicioReserva.Eliminar(objReserva);
        }
        public List<ReservaEntity> listarTodos()
        {
            return servicioReserva.ListarTodos();
        }

        public bool Agregar(ReservaEntity obj)
        {
            return servicioReserva.Agregar(obj);
        }

        public bool Actualizar(ReservaEntity obj)
        {
            return servicioReserva.Actualizar(obj);
        }

        public int Insertar(ReservaEntity obj)
        {
            if (obj.Direccion == "" || obj.Direccion==null)
            {
                obj.Direccion = "No especificada";
            }
            return servicioReserva.Insertar(obj);
        }

        public List<ReservaEntity> ListadoReserva(DateTime fechaInicio, 
                                                  DateTime fechaFin, int codigoTienda,
                                                  string estado, int codigoTipo)
        {
            List<ReservaEntity> lReserva = new List<ReservaEntity>();
            switch (estado)
            {
                case "T": lReserva = servicioReserva.ListarFecha(fechaInicio.Date,fechaFin.Date)
                                 .Where(tx => tx.FechaCelebracion >= fechaInicio && tx.FechaCelebracion <= fechaFin).ToList();break;
                case "P": lReserva = servicioReserva.ListarFecha(fechaInicio.Date, fechaFin.Date)
                                .Where(tx => tx.FechaCelebracion >= fechaInicio && tx.FechaCelebracion <= fechaFin && tx.Estado=="P").ToList();break;
                case "E": lReserva = servicioReserva.ListarFecha(fechaInicio.Date, fechaFin.Date)
                                .Where(tx => tx.FechaCelebracion >= fechaInicio && tx.FechaCelebracion <= fechaFin && tx.Estado == "E").ToList(); break;
                case "A": lReserva = servicioReserva.ListarFecha(fechaInicio.Date, fechaFin.Date)
                                .Where(tx => tx.FechaCelebracion >= fechaInicio && tx.FechaCelebracion <= fechaFin && tx.Estado=="A").ToList();break;
                case "O": lReserva = servicioReserva.ListarFecha(fechaInicio.Date, fechaFin.Date)
                            .Where(tx => tx.FechaCelebracion >= fechaInicio && tx.FechaCelebracion <= fechaFin && tx.Estado == "O").ToList(); break;
            }

            List<TiendaEntity> lTienda = servicioTienda.ListarTodos();
            if (codigoTienda != 0)
            {
                lReserva = lReserva.Where(tx => tx.CodigoTienda == codigoTienda).ToList();
            }

            List<TipoEventoEntity> lEvento;
            if (codigoTipo == 0)
            {
                lEvento = servicioTipoEvento.ListarTodos();
            }
            else
            {
                lEvento = servicioTipoEvento.ListarTodos().Where(tx => tx.Codigo == codigoTipo).ToList();
            }

            var query = from re in lReserva
                        from ti in lTienda.Where(tx => re.CodigoTienda == tx.Codigo).DefaultIfEmpty()
                        select new { Reserva = re, Tienda = ti } into first
                        join ev in lEvento
                        on first.Reserva.CodigoTipoEvento equals ev.Codigo
                        select new { Reserva = first.Reserva, Tienda = first.Tienda, Tipo = ev.Nombre };

            List<ReservaEntity> listaReserva = new List<ReservaEntity>();
            foreach (var resultado in query)
            {
                ReservaEntity objReserva = new ReservaEntity();
                objReserva.Celular = resultado.Reserva.Celular;
                objReserva.Codigo = resultado.Reserva.Codigo;
                objReserva.CodigoTienda = resultado.Reserva.CodigoTienda;
                objReserva.CodigoTipoEvento = resultado.Reserva.CodigoTipoEvento;
                objReserva.CodigoUsuario = resultado.Reserva.CodigoUsuario;
                objReserva.Direccion = resultado.Reserva.Direccion;
                String state = "";
                String doble = "";
                switch (resultado.Reserva.Estado)
                {
                    case "P": state = "PENDIENTE"; break;
                    case "A": state = "ASIGNADO"; break;
                    case "E": state = "EN PROCESO"; break;
                    case "O": state = "POSTERGADO"; break;
                }
                switch (resultado.Reserva.FiestaDoble)
                {
                    case "S": doble = "SI"; break;
                    case "N": doble = "NO"; break;
                    default: doble = "NO"; break;
                }
                objReserva.Estado = state;
                objReserva.FechaCelebracion = resultado.Reserva.FechaCelebracion;
                objReserva.FechaCrea = resultado.Reserva.FechaCrea;
                objReserva.FechaNacimiento = resultado.Reserva.FechaNacimiento;
                objReserva.HoraFin = resultado.Reserva.HoraFin;
                objReserva.HoraInicio = resultado.Reserva.HoraInicio;
                objReserva.Invitados = resultado.Reserva.Invitados;
                objReserva.ModeloTorta = resultado.Reserva.ModeloTorta;
                objReserva.NombreCliente = resultado.Reserva.NombreCliente;
                objReserva.NombreNiño = resultado.Reserva.NombreNiño;
                objReserva.NombreTienda = resultado.Tienda == null ? "-" : resultado.Tienda.Nombre;
                objReserva.NombreTipo = resultado.Tipo;
                objReserva.ObsGeneral = resultado.Reserva.ObsGeneral;
                objReserva.ObsTorta = resultado.Reserva.ObsTorta;
                objReserva.SaborTorta = resultado.Reserva.SaborTorta;
                objReserva.Telefono = resultado.Reserva.Telefono;
                objReserva.UsuarioCrea = resultado.Reserva.UsuarioCrea;
                objReserva.FiestaDoble = doble;
                listaReserva.Add(objReserva);
            }

            return listaReserva.OrderBy(tx => tx.FechaCelebracion).ToList();
        }

        public ReservaEntity Consultar(int codigo)
        {
            return servicioReserva.Consultar(codigo);
        }

        public DataSet CargarArchivo(String file, String ext)
        {
            DataSet dts;
            Excel objExcel = new Excel();
            dts = objExcel.LoadExcel(file, ext, true);
            return dts;
        }



        public String ValidarArchivo(DataSet dts,UsuarioEntity usuario,TiendaEntity tienda)
        {
            
            List<ReservaEntity> listaReserva = new List<ReservaEntity>();
            List<FiestaEntity> listaFiesta = servicioFiesta.ListarTodos();
            List<TortaEntity> listaTorta = servicioTorta.ListarTodo();
            List<SaborEntity> listaSabor = servicioSabor.ListarTodo();
            List<TipoEventoEntity> listaTipoEvento = servicioTipoEvento.ListarTodos();
            int fiestaDoble = 0;
            foreach (DataRow dtr in dts.Tables["'FORMATO RESERVAS$'"].Rows)
            {
                ReservaEntity objReserva = new ReservaEntity();
                List<DetalleReservaEntity> listaDetalle = new List<DetalleReservaEntity>();
                DetalleReservaEntity objDetalle = new DetalleReservaEntity();
                objReserva.CodigoTienda = tienda.Codigo;
                objReserva.Direccion = tienda.Direccion;
                objReserva.CodigoUsuario = usuario.Codigo;
                objReserva.UsuarioCrea = usuario.Login;
                objReserva.Estado = "P";
                objReserva.CodigoTipoEvento = listaTipoEvento.Where(tx => tx.Nombre == "TIENDA").FirstOrDefault().Codigo;
                if (dtr[6].ToString().Equals(String.Empty))
                {
                    return "Fecha de celebracion vacia en la fila: " + (dts.Tables["'FORMATO RESERVAS$'"].Rows.IndexOf(dtr) + 2);
                }
                else
                {
                    objReserva.FechaCelebracion = Convert.ToDateTime(dtr[6].ToString());
                    if (objReserva.FechaCelebracion < DateTime.Now.Date.AddDays(-6))
                    {
                        return "La fecha de celebracion ingresada es menor a la actual en la fila: " + (dts.Tables["'FORMATO RESERVAS$'"].Rows.IndexOf(dtr) + 2);
                    }
                }
                if (dtr[7].ToString().Equals(String.Empty))
                {
                    return "El horario de celebracion esta vacio en la fila: " + (dts.Tables["'FORMATO RESERVAS$'"].Rows.IndexOf(dtr) + 2);
                }
                else
                {
                    String horario = dtr[7].ToString();
                    int indice = horario.IndexOf("-");
                    Double horaInicio = Convert.ToDouble(horario.Substring(0, indice).ToString().Trim());
                    Double horaFin = Convert.ToDouble(horario.Substring(indice+1, 2).ToString().Trim());
                    objReserva.HoraInicio = horaInicio;
                    objReserva.HoraFin = horaFin;

                }
                if (dtr[1].ToString().Equals(String.Empty))
                {
                    objReserva.FechaNacimiento = DateTime.Now.AddYears(-5);
                }
                else
                {
                    objReserva.FechaNacimiento = Convert.ToDateTime(dtr[1].ToString());
                }
                if (dtr[0].ToString().Equals(String.Empty))
                {
                    return "No se ha ingresado nombre del niño en la fila: " + (dts.Tables["'FORMATO RESERVAS$'"].Rows.IndexOf(dtr) + 2);
                }
                else
                {
                    objReserva.NombreNiño = dtr[0].ToString().ToUpper().Trim();
                }
                if (dtr[8].ToString().Equals(String.Empty))
                {
                    objReserva.FiestaDoble = "N";
                }
                else
                {
                    objReserva.FiestaDoble = "S";
                    fiestaDoble = fiestaDoble + 1;
                }
                if (dtr[9].ToString().Equals(String.Empty))
                {
                    return "No se ha ingresado fiesta tematica en la fila: " + (dts.Tables["'FORMATO RESERVAS$'"].Rows.IndexOf(dtr) + 2);
                }

                if (dtr[4].ToString().Equals(String.Empty))
                {
                    return "No se ha ingresado nombre del cliente en la fila: " + (dts.Tables["'FORMATO RESERVAS$'"].Rows.IndexOf(dtr) + 2);
                }
                else
                {
                    objReserva.NombreCliente = dtr[4].ToString().ToUpper().Trim();
                }
                if (dtr[5].ToString().Equals(String.Empty))
                {
                    return "No se ha ingresado apellido del cliente en la fila: " + (dts.Tables["'FORMATO RESERVAS$'"].Rows.IndexOf(dtr) + 2);
                }
                else
                {
                    objReserva.NombreCliente = objReserva.NombreCliente + " " + dtr[5].ToString().ToUpper().Trim();
                }

                objReserva.Telefono = dtr[2].ToString().ToUpper().Trim();
                objReserva.Celular = dtr[3].ToString().ToUpper().Trim();
                objReserva.ObsTorta = dtr[4].ToString().ToUpper().Trim();
                String invitados = dtr[17].ToString().Trim();
                try
                {
                    objReserva.Invitados = Convert.ToInt16(invitados);
                }
                catch
                {
                    objReserva.Invitados = 0;
                }
                
                objReserva.ObsGeneral = dtr[23].ToString().ToUpper().Trim();

                String fiesta = dtr[9].ToString().ToUpper().Trim();
                String adicional1 = dtr[10].ToString().ToUpper().Trim();
                String adicional2 = dtr[11].ToString().ToUpper().Trim();
                String adicional3 = dtr[12].ToString().ToUpper().Trim();
                String adicional4 = dtr[13].ToString().ToUpper().Trim();
                String fiestaMs = dtr[18].ToString().ToUpper().Trim();
                String AdicionalMs1 = dtr[19].ToString().ToUpper().Trim();
                String AdicionalMs2 = dtr[20].ToString().ToUpper().Trim();
                String AdicionalMs3 = dtr[21].ToString().ToUpper().Trim();
                String AdicionalMs4 = dtr[22].ToString().ToUpper().Trim();
                String modeloTorta = dtr[14].ToString().ToUpper().Trim();
                String saborTorta = dtr[15].ToString().ToUpper().Trim();

                FiestaEntity objFiesta;

                if (fiestaMs != String.Empty)
                {
                    objFiesta = new FiestaEntity();
                    objFiesta = listaFiesta.Where(tx => tx.Nombre == fiestaMs.ToUpper().Trim()).FirstOrDefault();
                    if (objFiesta != null)
                    {
                        objDetalle = new DetalleReservaEntity();
                        objDetalle.CodigoFiesta = objFiesta.Codigo;
                        objDetalle.Usuario = usuario.Login;
                        objDetalle.FechaCreacion = DateTime.Now;
                        listaDetalle.Add(objDetalle);
                    }
                    else
                    {
                        return "Fiesta MS no identificada en la fila: " + (dts.Tables["'FORMATO RESERVAS$'"].Rows.IndexOf(dtr) + 2);
                    }
                }

                if (AdicionalMs1 != String.Empty)
                {
                    objFiesta = new FiestaEntity();
                    objFiesta = listaFiesta.Where(tx => tx.Nombre == AdicionalMs1.ToUpper().Trim()).FirstOrDefault();
                    if (objFiesta!=null)
                    {
                        objDetalle = new DetalleReservaEntity();
                        objDetalle.CodigoFiesta = objFiesta.Codigo;
                        objDetalle.Usuario = usuario.Login;
                        objDetalle.FechaCreacion = DateTime.Now;
                        listaDetalle.Add(objDetalle);
                    }
                    else
                    {
                        return "Adicional MS1 no identificada en la fila: " + (dts.Tables["'FORMATO RESERVAS$'"].Rows.IndexOf(dtr) + 2);
                    }
                }

                if (AdicionalMs2 != String.Empty)
                {
                    objFiesta = new FiestaEntity();
                    objFiesta = listaFiesta.Where(tx => tx.Nombre == AdicionalMs2.ToUpper().Trim()).FirstOrDefault();
                    if (objFiesta!=null)
                    {
                        objDetalle = new DetalleReservaEntity();
                        objDetalle.CodigoFiesta = objFiesta.Codigo;
                        objDetalle.Usuario = usuario.Login;
                        objDetalle.FechaCreacion = DateTime.Now;
                        listaDetalle.Add(objDetalle);
                    }
                    else
                    {
                        return "Adicional MS2 no identificada en la fila: " + (dts.Tables["'FORMATO RESERVAS$'"].Rows.IndexOf(dtr) + 2);
                    }
                }

                if (AdicionalMs3 != String.Empty)
                {
                    objFiesta = new FiestaEntity();
                    objFiesta = listaFiesta.Where(tx => tx.Nombre == AdicionalMs3.ToUpper().Trim()).FirstOrDefault();
                    if (objFiesta!=null)
                    {
                        objDetalle = new DetalleReservaEntity();
                        objDetalle.CodigoFiesta = objFiesta.Codigo;
                        objDetalle.Usuario = usuario.Login;
                        objDetalle.FechaCreacion = DateTime.Now;
                        listaDetalle.Add(objDetalle);
                    }
                    else
                    {
                        return "Adicional MS3 no identificada en la fila: " + (dts.Tables["'FORMATO RESERVAS$'"].Rows.IndexOf(dtr) + 2);
                    }
                }

                if (AdicionalMs4 != String.Empty)
                {
                    objFiesta = new FiestaEntity();
                    objFiesta = listaFiesta.Where(tx => tx.Nombre == AdicionalMs4.ToUpper().Trim()).FirstOrDefault();
                    if (objFiesta != null)
                    {
                        objDetalle = new DetalleReservaEntity();
                        objDetalle.CodigoFiesta = objFiesta.Codigo;
                        objDetalle.Usuario = usuario.Login;
                        objDetalle.FechaCreacion = DateTime.Now;
                        listaDetalle.Add(objDetalle);
                    }
                    else
                    {
                        return "Adicional MS4 no identificada en la fila: " + (dts.Tables["'FORMATO RESERVAS$'"].Rows.IndexOf(dtr) + 2);
                    }

                }
                if (fiesta != String.Empty)
                {
                    objFiesta = new FiestaEntity();
                    objFiesta = listaFiesta.Where(tx => tx.Nombre == fiesta.ToUpper().Trim()).FirstOrDefault();
                    if (objFiesta!= null)
                    {
                        objDetalle = new DetalleReservaEntity();
                        objDetalle.CodigoFiesta = objFiesta.Codigo;
                        objDetalle.Usuario = usuario.Login;
                        objDetalle.FechaCreacion = DateTime.Now;
                        listaDetalle.Add(objDetalle);
                    }
                    else
                    {
                        return "Tematica no identificada en la fila: " + (dts.Tables["'FORMATO RESERVAS$'"].Rows.IndexOf(dtr) + 2);
                    }
                }

                if (adicional1 != String.Empty)
                {
                    objFiesta = new FiestaEntity();
                    objFiesta = listaFiesta.Where(tx => tx.Nombre == adicional1.ToUpper().Trim()).FirstOrDefault();
                    if (objFiesta!= null)
                    {
                        objDetalle = new DetalleReservaEntity();
                        objDetalle.CodigoFiesta = objFiesta.Codigo;
                        objDetalle.Usuario = usuario.Login;
                        objDetalle.FechaCreacion = DateTime.Now;
                        listaDetalle.Add(objDetalle);
                    }
                    else
                    {
                        return "Adicional1 no identificado en la fila: " + (dts.Tables["'FORMATO RESERVAS$'"].Rows.IndexOf(dtr) + 2);
                    }
                }
                if (adicional2 != String.Empty)
                {
                    objFiesta = new FiestaEntity();
                    objFiesta = listaFiesta.Where(tx => tx.Nombre == adicional2.ToUpper().Trim()).FirstOrDefault();
                    if (objFiesta!= null)
                    {
                        objDetalle = new DetalleReservaEntity();
                        objDetalle.CodigoFiesta = objFiesta.Codigo;
                        objDetalle.Usuario = usuario.Login;
                        objDetalle.FechaCreacion = DateTime.Now;
                        listaDetalle.Add(objDetalle);
                    }
                    else
                    {
                        return "Adicional1 no identificado en la fila: " + (dts.Tables["'FORMATO RESERVAS$'"].Rows.IndexOf(dtr) + 2);
                    }
                }
                if (adicional3 != String.Empty)
                {
                    objFiesta = new FiestaEntity();
                    objFiesta = listaFiesta.Where(tx => tx.Nombre == adicional3.ToUpper().Trim()).FirstOrDefault();
                    if (objFiesta!= null)
                    {
                        objDetalle = new DetalleReservaEntity();
                        objDetalle.CodigoFiesta = objFiesta.Codigo;
                        objDetalle.Usuario = usuario.Login;
                        objDetalle.FechaCreacion = DateTime.Now;
                        listaDetalle.Add(objDetalle);
                    }
                    else
                    {
                        return "Adicional1 no identificado en la fila: " + (dts.Tables["'FORMATO RESERVAS$'"].Rows.IndexOf(dtr) + 2);
                    }
                }
                if (adicional4 != String.Empty)
                {
                    objFiesta = new FiestaEntity();
                    objFiesta = listaFiesta.Where(tx => tx.Nombre == adicional4.ToUpper().Trim()).FirstOrDefault();
                    if (objFiesta != null)
                    {
                        objDetalle = new DetalleReservaEntity();
                        objDetalle.CodigoFiesta = objFiesta.Codigo;
                        objDetalle.Usuario = usuario.Login;
                        objDetalle.FechaCreacion = DateTime.Now;
                        listaDetalle.Add(objDetalle);
                    }
                    else
                    {
                        return "Adicional1 no identificado en la fila: " + (dts.Tables["'FORMATO RESERVAS$'"].Rows.IndexOf(dtr) + 2);
                    }
                }

                if (modeloTorta != string.Empty)
                {
                    TortaEntity obj = listaTorta.Where(tx => tx.Nombre == modeloTorta.ToUpper().Trim()).FirstOrDefault();
                    if(obj!=null)
                    {
                        objReserva.ModeloTorta = modeloTorta.ToUpper().Trim();
                    }
                    else
                    {
                        return "Torta no identificada en la fila: " + (dts.Tables["'FORMATO RESERVAS$'"].Rows.IndexOf(dtr) + 2);
                    }
                }
                if (saborTorta != String.Empty)
                {
                    SaborEntity objSabor = listaSabor.Where(tx => tx.Nombre == saborTorta.ToUpper().Trim()).FirstOrDefault();
                    if (objSabor!=null)
                    {
                        objReserva.SaborTorta = saborTorta.ToUpper().Trim();
                    }
                    else
                    {
                        return "Sabor no identificado en la fila: " + (dts.Tables["'FORMATO RESERVAS$'"].Rows.IndexOf(dtr) + 2);
                    }
                }
                objReserva.FechaCrea = DateTime.Now;
                objReserva.ListaDetalle = listaDetalle;
                listaReserva.Add(objReserva);
            }
            if (fiestaDoble % 2.0 != 0)
            {
                return "Cantidad de fiestas dobles ingresadas incorrecto";
            }
            foreach (ReservaEntity reserv in listaReserva)
            {
                DetalleReservaBL servicioDetalle = new DetalleReservaBL();
                int codigo = Insertar(reserv);
                if (codigo != 0)
                {
                    foreach (DetalleReservaEntity det in reserv.ListaDetalle)
                    {
                        det.CodigoReserva = codigo;
                        det.FechaCreacion = DateTime.Now;
                    }
                    servicioDetalle.Agregar(reserv.ListaDetalle);
                }
            }
            return "ok";
        }

        public List<ReservaEntity> ReporteTorta(DateTime fechaInicio, DateTime fechaFin)
        {
            List<ReservaEntity> lista = servicioReserva.ListarFecha(fechaInicio.Date,fechaFin.Date)
                                        .Where(tx =>tx.ModeloTorta != "" && tx.ModeloTorta!=null & tx.Estado=="A").ToList();

            TiendaBL tiendaBL = new TiendaBL();


            foreach (ReservaEntity reserv in lista)
            {
                if (reserv.CodigoTienda == null)
                {
                    reserv.NombreTienda = "N/A";
                }
                else
                {
                    reserv.NombreTienda = tiendaBL.Consultar(Convert.ToInt16(reserv.CodigoTienda.ToString())).Nombre;
                }
                 
            }
            return lista.OrderBy(tx => tx.FechaCelebracion).ToList();

        }

        public List<ReportReservaTienda> ReporteTienda(DateTime fechaInicio, DateTime fechaFin, int codigoTienda)
        {
            TiendaBL tiendaBL = new TiendaBL();
            DetalleReservaBL detalleBL = new DetalleReservaBL();
            FiestaBL fiestaBL = new FiestaBL();
            TipoFiestaBL tipoFiestaBL = new TipoFiestaBL();
            List<ReportReservaTienda> reporte = new List<ReportReservaTienda>();
            List<ReservaEntity> listaReserva;
            if (codigoTienda == 0)
            {
                listaReserva = servicioReserva.ListarFecha(fechaInicio,fechaFin).Where(tx => tx.FechaCelebracion >= fechaInicio && tx.FechaCelebracion <= fechaFin && tx.CodigoTienda != null && tx.Estado=="A").ToList();
            }
            else
            {
                listaReserva = servicioReserva.ListarFecha(fechaInicio, fechaFin).Where(tx => tx.FechaCelebracion >= fechaInicio && tx.FechaCelebracion <= fechaFin && tx.CodigoTienda == codigoTienda && tx.Estado == "A").ToList();
            }
            List<DetalleReservaEntity> listaDetalle;
            List<TipoFiestaEntity> lista = tipoFiestaBL.ListarTodos();
            List<TiendaEntity> listaTienda = tiendaBL.ListarTodos();
            List<DetalleReservaEntity> listaDetalles = serviceFastDetalle.ListarFecha(fechaInicio, fechaFin);

            foreach(ReservaEntity reserv in listaReserva)
            {
                ReportReservaTienda objReport = new ReportReservaTienda();
                objReport.FechaReserva = reserv.FechaCelebracion;
                objReport.Horario = reserv.HoraInicio+" - "+reserv.HoraFin;
                objReport.NombreCliente = reserv.NombreCliente;
                objReport.NombreNiño = reserv.NombreNiño;
                objReport.NombreTienda = listaTienda.Where(tx => tx.Codigo == reserv.CodigoTienda).FirstOrDefault().Nombre;
                objReport.ObservacionesGeneral = reserv.ObsGeneral;
                objReport.ObservacionesTorta = reserv.ObsTorta;
                objReport.Tamaño = reserv.SaborTorta;
                objReport.Torta = reserv.ModeloTorta;
                //listaDetalle = detalleBL.ListarPorReservaReporte(reserv.Codigo);
                listaDetalle = listaDetalles.Where(tx => tx.CodigoReserva == reserv.Codigo).ToList();
                int contadorAdicional = 0;
                int contadorAdicionalMS = 0;
                foreach (DetalleReservaEntity deta in listaDetalle)
                { 
                   FiestaEntity fiesta = new FiestaEntity();
                   fiesta = fiestaBL.Consultar(deta.CodigoFiesta);
                   string nombreTipo = lista.Where(tx => tx.Codigo == fiesta.CodigoTipoFiesta).FirstOrDefault().Nombre;
                   if (nombreTipo == "TEMATICAS")
                   {
                       objReport.Fiesta = fiesta.Nombre;
                       continue;
                   }
                   if (nombreTipo == "FIESTA MS")
                   {
                       objReport.FiestaMs = fiesta.Nombre;
                       continue;
                   }
                   if (nombreTipo == "ADICIONAL")
                   {
                       if (contadorAdicional == 0)
                       {
                           objReport.Adicional1 = fiesta.Nombre;
                           contadorAdicional = contadorAdicional+1;
                           continue;
                       }
                       if (contadorAdicional == 1)
                       {
                           objReport.Adicional2 = fiesta.Nombre;
                           contadorAdicional = contadorAdicional + 1;
                           continue;
                       }
                       if (contadorAdicional == 2)
                       {
                           objReport.Adicional3 = fiesta.Nombre;
                           contadorAdicional = contadorAdicional + 1;
                           continue;
                       }
                       if (contadorAdicional == 3)
                       {
                           objReport.Adicional4 = fiesta.Nombre;
                           contadorAdicional = contadorAdicional + 1;
                           continue;
                       }
                   }
                   if (nombreTipo == "ADICIONAL MS")
                   {
                       if (contadorAdicionalMS == 0)
                       {
                           objReport.Adicionalms1 = fiesta.Nombre;
                           contadorAdicionalMS = contadorAdicionalMS + 1;
                           continue;
                       }
                       if (contadorAdicionalMS == 1)
                       {
                           objReport.Adicionalms2 = fiesta.Nombre;
                           contadorAdicionalMS = contadorAdicionalMS + 1;
                           continue;
                       }
                       if (contadorAdicionalMS == 2)
                       {
                           objReport.Adicionalms3 = fiesta.Nombre;
                           contadorAdicionalMS = contadorAdicionalMS + 1;
                           continue;
                       }
                       if (contadorAdicionalMS == 3)
                       {
                           objReport.Adicionalms4 = fiesta.Nombre;
                           contadorAdicionalMS = contadorAdicionalMS + 1;
                           continue;
                       }
                   }

                }
                reporte.Add(objReport);
            }
            return reporte.OrderBy(tx => tx.FechaReserva).ThenBy(tx=>tx.NombreTienda).ToList();
        }

        public List<ReportTiendaDetalle> ReporteTiendaDetalle(DateTime fechaInicio, DateTime fechaFin, int codigoTienda)
        {
            List<ReservaEntity> listaReserva;

            if (codigoTienda == 0)
            {
                listaReserva=servicioReserva.ListarFecha(fechaInicio.Date,fechaFin.Date).Where(tx => tx.FechaCelebracion >= fechaInicio && tx.FechaCelebracion <= fechaFin && tx.Estado == "A" && tx.CodigoTienda != null).ToList();
            }
            else
            {
                listaReserva = servicioReserva.ListarFecha(fechaInicio.Date, fechaFin.Date).Where(tx => tx.FechaCelebracion >= fechaInicio && tx.FechaCelebracion <= fechaFin && tx.Estado == "A" && tx.CodigoTienda == codigoTienda).ToList();
            }

            List<DetalleReservaEntity> listaDetalle = servicioDetalle.ListarTodos();
            List<TiendaEntity> listaTienda = servicioTiendaBL.ListarTodos();
            List<TipoFiestaEntity> listaTipoFiesta = servicioTipoFiesta.ListarTodos();
            List<FiestaEntity> listaFiesta = servicioFiesta.ListarTodos();

            var query = from rese in listaReserva
                        join deta in listaDetalle
                        on rese.Codigo equals deta.CodigoReserva
                        select new {Reserva = rese,Detalle = deta};



            List<ReportTiendaDetalle> lista = new List<ReportTiendaDetalle>();

            foreach (var resultado in query)
            {
                ReportTiendaDetalle report = new ReportTiendaDetalle();
                FiestaEntity objFiesta = new FiestaEntity();
                objFiesta = listaFiesta.Where(tx=>tx.Codigo == resultado.Detalle.CodigoFiesta).FirstOrDefault();

                TipoFiestaEntity objTipoFiesta = new TipoFiestaEntity();
                objTipoFiesta = listaTipoFiesta.Where(tx => tx.Codigo == objFiesta.CodigoTipoFiesta).FirstOrDefault();

                TiendaEntity objTienda = new TiendaEntity();
                objTienda = listaTienda.Where(tx => tx.Codigo == resultado.Reserva.CodigoTienda).FirstOrDefault();

                report.NombreFiesta = objFiesta.Nombre;
                report.TipoFiesta = objTipoFiesta.Nombre;
                report.NombreTienda = objTienda.Nombre;
                lista.Add(report);
            }
            lista = lista.OrderBy(tx=>tx.NombreTienda).ThenBy(tx=>tx.TipoFiesta).ThenBy(tx=>tx.NombreFiesta).ToList();

            var group = lista
                        .GroupBy(x => new { x.TipoFiesta, x.NombreTienda, x.NombreFiesta })
                        .Select(y => new
                        {
                            Tienda = y.Key.NombreTienda,
                            Fiesta = y.Key.NombreFiesta,
                            Tipo = y.Key.TipoFiesta,
                            Cuenta = y.Count()
                        });

            List<ReportTiendaDetalle> listaCompuesta = new List<ReportTiendaDetalle>();

            foreach (var result in group)
            {
                ReportTiendaDetalle report = new ReportTiendaDetalle();
                report.NombreFiesta = result.Fiesta;
                report.NombreTienda = result.Tienda;
                report.TipoFiesta = result.Tipo;
                report.Cantidad = result.Cuenta;
                listaCompuesta.Add(report);
            }

            return listaCompuesta;
        }
    }
}
