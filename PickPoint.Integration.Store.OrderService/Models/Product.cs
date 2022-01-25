using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickPoint.Integration.Store.OrderService.Models
{
    /// <summary>
    /// Модель товара
    /// </summary>
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; } // Идентификатор товара

        [Required]
        public string Name { get; set; } // Наименование товара
    }
}
