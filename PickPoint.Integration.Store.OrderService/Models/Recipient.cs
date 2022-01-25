#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace PickPoint.Integration.Store.OrderService.Models
{
    /// <summary>
    /// Модель пользователя - получателя заказа
    /// </summary>
    public class Recipient
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; } // Идентификатор пользователя

        [Required]
        public string Name { get; set; } // ФИО получателя

        [Required, RegularExpression(@"^\+7\d{3}-\d{3}-\d{2}-\d{2}$")]
        public string Phone { get; set; } // Номер телефона получателя +7XXX-XXX-XX-XX

        internal bool IsValid
        {
            get
            {
                if (!new Regex(@"^\+7\d{3}-\d{3}-\d{2}-\d{2}$").IsMatch(Phone))
                    return false;

                return true;
            }
        }
    }
}
