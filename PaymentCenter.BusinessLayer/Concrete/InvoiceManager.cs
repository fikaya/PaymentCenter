using PaymentCenter.BusinessLayer.Abstract;
using PaymentCenter.DataAccessLayer.Abstract;
using PaymentCenter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCenter.BusinessLayer.Concrete
{
    public class InvoiceManager : BaseManager<Invoice>, IInvoiceService<Invoice>
    {
        public InvoiceManager(IRepository<Invoice> repository) : base(repository)
        {
            //Burada bunu yapma sebebimizi açıklayalım.InvoiceManager BaseManager ı inherit ediyor. Ve ben şu interface e şu nesneyi üret derken örnek verelim InvoiceManager nesnesini ver diyorum.Şimdi bunu verdiğimiz de InvoiceManagerın inherit ettiği BaseManagerın da bir constructor değeri verilmesi gerekiyor(Çünkü oda arkada newleniyor).Bende diyorum ki bu InvoiceManager oluşurken onun constructor ına ne veriyorsam bunu git BaseManager ın constructorında da ver.
        }

    }
}
