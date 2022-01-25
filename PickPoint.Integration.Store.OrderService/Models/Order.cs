#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickPoint.Integration.Store.OrderService.Models
{
    /// <summary>
    /// Модель заказа
    /// </summary>
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; } // Идентификатор заказа


        [Required]
        public OrderStatus Status { get; set; } = OrderStatus.Registered; // Статус заказа

        [Required]
        public decimal Cost { get; set; } // Стоимость заказа


        /// <summary>
        /// Постамат
        /// </summary>
        [Required]
        public string PostamatId { get; set; } // Ссылка на постамат доставки

        [ForeignKey("PostamatId")]
        public virtual Postamat Postamat { get; set; } // Постамат доставки


        /// <summary>
        /// Получатель заказа
        /// </summary>
        [Required]
        public long RecipientId { get; set; } // Ссылка на получателя заказа

        [ForeignKey("RecipientId")]
        public virtual Recipient Recipient { get; set; } // Получатель


        /// <summary>
        /// Состав заказа
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }
    }
}
