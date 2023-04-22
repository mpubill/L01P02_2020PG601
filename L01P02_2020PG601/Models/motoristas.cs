using System.ComponentModel.DataAnnotations;

namespace L01P02_2020PG601.Models
{
    public class motoristas
    {
        [Key][Display(Name = "ID")] public int motoristaId { get; set; }
        [Display(Name = "Nombre de motorista")] public string? nombreMotorista { get; set; }
    }
}
