﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IAboutDal : IRepository<About>
    {
        //int AboutID { get; }

        //void Insert(About about);
        //void Delete(About about);
        //void Update(About about);
    }
}
