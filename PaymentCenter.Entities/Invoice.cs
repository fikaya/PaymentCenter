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
    public class Invoice
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [Range(200, 10000000000, ErrorMessage = "{0} 5'den küçük ve 10000000000'den büyük olamaz.")]
        [Display(Name = "Fatura Tutarı")]
        public float InvoiceAmount { get; set; }

        [Display(Name = "Fatura Ödenme Durumu")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fatura Tarihi")]
        public DateTime InvoiceDate { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Son Ödeme Tarihi")]
        public DateTime DueDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ödeme Tarihi")]
        public DateTime? PaymentDate { get; set; }

        [ForeignKey("BoxOfficeAttendant")]
        public int? BoxOfficeAttendantID { get; set; }
        public virtual BoxOfficeAttendant BoxOfficeAttendant { get; set; }

        [ForeignKey("InstitutionSubscriber")]
        public int InstitutionSubscriberID { get; set; }
        public virtual InstitutionSubscriber InstitutionSubscriber { get; set; }
    }
}
