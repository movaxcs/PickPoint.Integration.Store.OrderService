#nullable disable
using System.ComponentModel.DataAnnotations;
using PickPoint.Integration.Store.OrderService.Models;
using System.ComponentModel;

namespace PickPoint.Integration.Store.OrderService.Dto
{
    /// <summary>
    /// Аттрибуты свойств указаны только для удобства работы со swagger-ом
    /// </summary>
    public class OrderDto
    {
        internal long Id { get; set; }

        [Required, DefaultValue(1000)]
        public decimal Cost { get; set; }

        [Required, DefaultValue("0000-001")]
        public string PostamatId { get; set; }

        [Required, DefaultValue(1)]
        public long RecipientId { get; set; }

        [Required, DefaultValue(new long[] { 1, 2 })]
        public long[] Products { get; set; }

        internal bool IsValid
        {
            get
            {
                if (Cost <= 0 || Products == null || Products.Count() == 0 || Products.Count() > 10)
                    return false;

                return true;
            }
        }

    }
}
