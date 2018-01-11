using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelpDesk_Kvas.Models.Datos.Entity
{
    public class RequerimientosEntity
    {
        [Key]
        public int IdRequerimiento { get; set; }

        [Display(Name = "Marca:")]
        public int IdEmpleado { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Entrada:")]
        public DateTime FechaEntrada { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Salida:")]
        public DateTime FechaSalida { get; set; }

        [Display(Name = "Cliente:")]
        public int IdCliente { get; set; }

        [Display(Name = "Equipo:")]
        public int IdEquipo { get; set; }

        [Display(Name = "Marca:")]
        public int IdMarca { get; set; }

        [Display(Name = "Prioridad:")]
        public int IdPrioridad { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Modelo:")]
        public int IdModelo { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Serial:")]
        public string Serial { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Descripcion:")]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Falla:")]
        public string Falla { get; set; }
        
        [StringLength(100)]
        [Display(Name = "Diagnostico:")]
        public string Diagnostico { get; set; }
        
        [StringLength(100)]
        [Display(Name = "Solucion:")]
        public string Solucion { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Accesorio:")]
        public string Accesorio { get; set; }

        [Display(Name = "Deposito:")]
        public int IdDeposito { get; set; }

        [Display(Name = "Tecnico:")]
        public int? IdTecnico { get; set; }

        [Display(Name = "Estatus:")]
        public int IdEstatus { get; set; }

        public int Mensaje { get; set; }
    }

    public class RequerimientoViewEntity : RequerimientosEntity
    {
        [Display(Name = "Empleado:")]
        public string Empleado { get; set; }

        [Display(Name = "Cliente:")]
        public string Cliente { get; set; }

        [Display(Name = "Equipo:")]
        public string Equipo { get; set; }

        [Display(Name = "Marca:")]
        public string Marca { get; set; }

        [Display(Name = "Prioridad:")]
        public string Prioridad { get; set; }

        [Display(Name = "Modelo:")]
        public string Modelo { get; set; }

        [Display(Name = "Deposito:")]
        public string Deposito { get; set; }

        [Display(Name = "Tecnico:")]
        public string Tecnico { get; set; }

        [Display(Name = "Estatus:")]
        public string Estatus { get; set; }
    }
}