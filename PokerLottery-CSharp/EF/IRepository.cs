﻿using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PokerLottery.EF
{
    public partial interface IRepository<T> where T : BaseEntity
    {
        T GetById(object id);
        void Insert(T entity);
        void InsertList(IList<T> entitys);
        void Update(T entity);
        void Delete(T entity);
        void DeleteList(IList<T> entitys);
        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }
        DbSet<T> CurrentDbSet { get; set; }

    }
}
