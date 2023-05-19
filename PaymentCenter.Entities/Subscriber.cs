using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PaymentCenter.Entities
{
    /// <summary>
    /// Abone varlığı olarak hizmet veriyor.
    /// </summary>
    public class Subscriber
    {
        public Subscriber()
        {
            InstitutionSubscribers = new List<InstitutionSubscriber>();
        }


        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
       
        [MinLength(1, ErrorMessage = "{0} 1 karakterden az olamaz."), MaxLength(50, ErrorMessage = "{0} 25 karakterden fazla olamaz.")]
        [Display(Name = "Ad")]
        public string SubscriberName { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [MinLength(1, ErrorMessage = "{0}1 karakterden az olamaz."), MaxLength(50, ErrorMessage = "{0} 50 karakterden fazla olamaz.")]
        [Display(Name = "Soyad")]
        public string SubscriberSurname { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [Phone(ErrorMessage = "Geçersiz {0} girdiniz.")]
        [MinLength(11, ErrorMessage = "{0} 11 basamaklı olmalıdır."), MaxLength(11, ErrorMessage = "{0} 11 basamaklı olmalıdır.")]
        [Display(Name = "Türkiye Cumhuriyeti Kimlik Numarası")]
        public string SubscriberIdentityNumber { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [Phone(ErrorMessage = "Geçersiz {0} girdiniz.")]
        [MinLength(11, ErrorMessage = "{0} 11 basamaklı olmalıdır."), MaxLength(11, ErrorMessage = "{0} 11 basamaklı olmalıdır.")]
        [Display(Name = "Telefon Numarası")]
        public string SubscriberPhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçersiz {0} girdiniz.")]
        [MinLength(5, ErrorMessage = "{0}5 karakterden az olamaz."), MaxLength(50, ErrorMessage = "{0} 50 karakterden fazla olamaz.")]
        [Display(Name = "E-posta")]
        public string SubscriberEmail { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [Range(18, 90, ErrorMessage = "{0} 18'den küçük ve 90'dan büyük olamaz.")]
        [Display(Name = "Yaş")]
        public int SubscriberAge { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [MinLength(5, ErrorMessage = "{0}5 karakterden az olamaz."), MaxLength(450, ErrorMessage = "{0} 450 karakterden fazla olamaz.")]
        [Display(Name = "Adres")]
        public string SubscriberAddress { get; set; }
        public virtual ICollection<InstitutionSubscriber> InstitutionSubscribers { get; }

    }
}
