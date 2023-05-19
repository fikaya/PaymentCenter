﻿using PaymentCenter.BusinessLayer.Abstract;
using PaymentCenter.DataAccessLayer.Abstract;
using PaymentCenter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCenter.BusinessLayer.Concrete
{
    public class BoxOfficeAttendantManager : BaseManager<BoxOfficeAttendant>, IBoxOfficeAttendantService<BoxOfficeAttendant>
    {
        public BoxOfficeAttendantManager(IRepository<BoxOfficeAttendant> repository) : base(repository)
        {
            
        }

    }
}
