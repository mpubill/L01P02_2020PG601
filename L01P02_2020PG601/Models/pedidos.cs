using System.ComponentModel.DataAnnotations;

namespace L01P02_2020PG601.Models
{
    public class pedidos
    {
        [Key][Display(Name = "ID")] public int pedidoId { get; set; }
        [Display(Name = "ID de motorista")] public int motoristaId { get; set; }
        [Display(Name = "ID de cliente")] public int clienteId { get; set; }
        [Display(Name = "ID de plato")] public int platoId { get; set; }
        [Display(Name = "Cantidad")] public int cantidad { get; set; }
        [Display(Name = "Precio")] public decimal precio { get; set; }
    }
}
