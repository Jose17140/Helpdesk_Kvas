using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelpDesk_Kvas.Models.Datos.Entity
{
    public class FiltroClienteEntity
    {
        [Display(Name = "Buscar Cliente:")]
        public string BuscarCliente { get; set; }
    }

    public class RequerimientosEntity
    {
        [Key]
        public int IdRequerimiento { get; set; }

        [Display(Name = "Departamento:")]
        public int IdDepartamento { get; set; }

        [Display(Name = "Atendido:")]
        public bool Atendido { get; set; }

        [Display(Name = "Presupuesto:")]
        public bool Presupuestado { get; set; }

        [Display(Name = "Empleado:")]
        public int? IdEmpleado { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "Fecha de Entrada:")]
        public DateTime FechaEntrada { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "Fecha de Salida:")]
        public DateTime FechaSalida { get; set; }

        [Display(Name = "Cliente:")]
        public int IdCliente { get; set; }

        [Display(Name = "Equipo:")]
        public int IdEquipo { get; set; }

        [Display(Name = "Marca:")]
        public int IdMarca { get; set; }
        
        [Display(Name = "Modelo:")]
        public int IdModelo { get; set; }

        [Display(Name = "Prioridad:")]
        public int IdPrioridad { get; set; }

        [Required]
        [StringLength(250)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Falla:")]
        public string Falla { get; set; }

        [StringLength(250)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Diagnostico:")]
        public string Diagnostico { get; set; }

        [StringLength(250)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Solucion:")]
        public string Solucion { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Serial:")]
        public string Serial { get; set; }
        
        [StringLength(250)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Observaciones:")]
        public string Observaciones { get; set; }
        
        [StringLength(30)]
        [Display(Name = "Accesorio:")]
        public string Accesorio { get; set; }

        [Display(Name = "Tecnico:")]
        public int? IdTecnico { get; set; }

        [Display(Name = "Estatus:")]
        public int IdEstatus { get; set; }

        public int Mensaje { get; set; }
    }

    public class RequerimientoViewEntity : RequerimientosEntity
    {
        [Display(Name = "Departamento:")]
        public string Departamento { get; set; }

        [Display(Name = "Empleado:")]
        public string Empleado { get; set; }

        [Display(Name = "Prioridad:")]
        public string Prioridad { get; set; }

        [Display(Name = "Tecnico:")]
        public string Tecnico { get; set; }

        [Display(Name = "Estatus:")]
        public string Estatus { get; set; }

        #region EQUIPO
        [Display(Name = "Equipo:")]
        public string Equipo { get; set; }

        [Display(Name = "Marca:")]
        public string Marca { get; set; }

        [Display(Name = "Modelo:")]
        public string Modelo { get; set; }
        #endregion

        #region
        #endregion

        #region
        #endregion


        

        #region CLIENTE
        [Display(Name = "Nombre:")]
        public string Nombres { get; set; }

        [Display(Name = "Cedula:")]
        public string CiRif { get; set; }

        [Display(Name = "Telefonos:")]
        public string Telefonos { get; set; }

        [Display(Name = "Email:")]
        public string Email { get; set; }

        [Display(Name = "Direccion:")]
        public string Direccion { get; set; }
        #endregion
    }
}