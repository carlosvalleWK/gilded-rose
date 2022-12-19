using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Data.Repository.Interface
{
    internal interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
    }
}
