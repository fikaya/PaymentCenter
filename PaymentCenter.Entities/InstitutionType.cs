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
    /// Kurum Tipi varlığı olarak hizmet veriyor.
    /// </summary>
    public class InstitutionType
    {
        private const string RegularExpression = @"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$";

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [RegularExpression(RegularExpression, ErrorMessage = "{0} alanı sadece büyük ve küçük harflerden oluşabilir.")]
        [MinLength(5, ErrorMessage = "{0} 5 karakterden az olamaz."), MaxLength(100, ErrorMessage = "{0} 100 karakterden fazla olamaz.")]
        [Display(Name = "Kurum Tipi Adı")]
        public string InstitutionTypeName { get; set; }
    }
}
