﻿using System.Linq.Expressions;

namespace WebUygulamaProje1.Models
{
    public interface IRepository<T> where T : class
    {
        // T -> KitapTuru demek
        IEnumerable<T> GetAll(string? includeProps = null); //Hepsini Getir Demek GetAll();
        T Get(Expression<Func<T, bool>> filtre, string? includeProps = null);
        void Ekle(T entity);
        void Sil(T entity);
        void SilAralik(IEnumerable<T> entities);
    }
}
