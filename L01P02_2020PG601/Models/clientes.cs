using System.ComponentModel.DataAnnotations;

namespace L01P02_2020PG601.Models
{
    public class clientes
    {
        [Key]
        [Display(Name ="ID")]
        public int clienteId { get; set; }
        [Display(Name = "Nombre del cliente")] public string? nombreCliente { get; set; }
        [Display(Name = "Dirección")] public string? direccion { get; set; }
    }
}
