using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2025_NetCore_Empleados.Models
{
    public class Empleados
    {
        [Key]
        public int idEmpleado { get; set; }
        [Column("Nombres")]
        [MaxLength(20)]
        public string nombres { get; set; } = string.Empty;
        [Column("Apellidos")]
        [MaxLength(50)]
        public string apellidos { get; set; } = string.Empty;
        [Column("Edad")]
        public int edad { get; set; }
        [Column("DniEmpleado")]
        [MaxLength(50)]
        public string dniEmpleado { get; set; } = string.Empty;
        [Column("Email")]
        [MaxLength(100)]
        public string email { get; set; } = string.Empty;

    }
}
