#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace PickPoint.Integration.Store.OrderService.Models
{
    public class Postamat
    {
        [Key, Required, RegularExpression(@"^\d{4}-\d{3}$")]
        public string Id { get; set; }    // Номер постамата

        [Required]
        public string Address { get; set; } // Адрес постамата

        [Required]
        public PostamatStatus Status { get; set; } = PostamatStatus.Worked; // Статус постамата

        internal bool IsValid
        {
            get
            {
                if (Status == PostamatStatus.Closed || !new Regex(@"^\d{4}-\d{3}$").IsMatch(Id))
                    return false;

                return true;
            }
        }

    }
}
