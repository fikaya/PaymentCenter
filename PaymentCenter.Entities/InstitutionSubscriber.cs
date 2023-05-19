using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCenter.Entities
{
    /// <summary>
    /// Bize ara tablo olarak hizmet veriyor.
    /// </summary>
    public class InstitutionSubscriber
    {
        public InstitutionSubscriber()
        {
            SubscriberRegistrationNumber = Guid.NewGuid();
            //Ödeme Merkezinin Belirlediği Ücret
            DepositAmount = 250;
            Invoices = new List<Invoice>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Abonelik Durumu")]
        public bool IsActive { get; set; } = true;

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [Range(200, 500, ErrorMessage = "{0} 200'den küçük ve 500'den büyük olamaz.")]
        [Display(Name = "Depozito Ücreti")]
        public float DepositAmount { get; set; }
        public Guid SubscriberRegistrationNumber { get; set; }

        [ForeignKey("Institution")]
        public int InstitutionID { get; set; }
        public virtual Institution Institution { get; set; }

        [ForeignKey("Subscriber")]
        public int SubscriberID { get; set; }
        public virtual Subscriber Subscriber { get; set; }
        public virtual ICollection<Invoice> Invoices { get; }
    }
}
