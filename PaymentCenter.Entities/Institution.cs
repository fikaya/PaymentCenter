using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PaymentCenter.Entities
{
    /// <summary>
    /// Kurum varlığı olarak hizmet veriyor.
    /// </summary>
    public class Institution
    {
        public Institution()
        {
            InstitutionSubscribers = new List<InstitutionSubscriber>();
        }
        private const string RegularExpression = @"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$";

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [RegularExpression(RegularExpression, ErrorMessage = "{0} alanı sadece büyük ve küçük harflerden oluşabilir.")]
        [MinLength(5, ErrorMessage = "{0} 5 karakterden az olamaz."), MaxLength(200, ErrorMessage = "{0} 200 karakterden fazla olamaz.")]
        [Display(Name = "Kurum Adı")]
        public string InstitutionName { get; set; }

        [ForeignKey("InstitutionType")]
        public int InstitutionTypeID { get; set; }
        public virtual InstitutionType InstitutionType { get; set; }
        public virtual ICollection<InstitutionSubscriber> InstitutionSubscribers { get; }
    }
}
