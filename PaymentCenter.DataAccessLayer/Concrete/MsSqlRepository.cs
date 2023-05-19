using Microsoft.EntityFrameworkCore;
using PaymentCenter.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCenter.DataAccessLayer.Concrete
{
    public class MsSqlRepository<T> : IRepository<T> where T : class
    {
        //Burada bir BaseRepository açarak hem MySql hem Oracle hemde diğer veri tabanları için bir merkezi nokta oluşturulabilir. Ve buradaki bağımlılık ortadan gider.
        private PaymentCenterDbContext _dbContext = new PaymentCenterDbContext();

        private DbSet<T> _objectSet;
        public MsSqlRepository()
        {
            //Set<T>() metodunun generic parametresine kullanıcı int gibi bir değer göndermemeli. Buraya sadece entity isimlerim gelmeli.Onun için bir constraint uygulayacağım. where T:Class diyerek bir kısıtlama getirdim.
            //Burada sonuç olarak Set<T>() metodundan bir DbSet<T> dönecek.
            _objectSet = _dbContext.Set<T>();
        }
        public List<T> List()
        {
            return _objectSet.ToList();
        }
        public List<T> List(Expression<Func<T, bool>> where)
        {
            var list = _objectSet.Where(where).ToList();
            return list;
        }

        //Enumerable işlerini bellekte yapar,Queryable ise database içinde.
        //Ben bunun bir sorgu olarak kalmasını istersem.Ve üstüne çeşitli sorgular eklemek istersem aşağıdaki iki metodu kullanabilirim. (Order by gibi)
        public IQueryable<T> ListQueryable()
        {
            return _objectSet.AsQueryable<T>();
        }
        public IEnumerable<T> ListEnumerable()
        {
            return _objectSet.AsEnumerable<T>();
        }
        public List<T> ListCollection(Expression<Func<T, bool>> where, params string[] collectionNames)
        {
            List<T> list;
            if (where != null)
            {
                list = _objectSet.Where(where).ToList();
            }
            else
            {
                list = _objectSet.ToList();
            }
            foreach (var item in list)
            {
                for (int i = 0; i < collectionNames.Length; i++)
                {
                    _dbContext.Entry(item).Collection(collectionNames[i]).Load();
                }
            }
            return list;
        }
        public List<T> ListCollection(params string[] collectionNames)
        {
            var list = _objectSet.ToList();
            foreach (var item in list)
            {
                for (int i = 0; i < collectionNames.Length; i++)
                {
                    _dbContext.Entry(item).Collection(collectionNames[i]).Load();
                }
            }
            return list;
        }
        public List<T> ListReference(Expression<Func<T, bool>> where, params string[] referenceNames)
        {
            List<T> list;
            if (where != null)
            {
                list = _objectSet.Where(where).ToList();
            }
            else
            {
                list = _objectSet.ToList();
            }
            foreach (var item in list)
            {
                for (int i = 0; i < referenceNames.Length; i++)
                {
                    _dbContext.Entry(item).Reference(referenceNames[i]).Load();
                }
            }
            return list;
        }
        public List<T> ListReference(params string[] referenceNames)
        {
            var list = _objectSet.ToList();
            foreach (var item in list)
            {
                for (int i = 0; i < referenceNames.Length; i++)
                {
                    _dbContext.Entry(item).Reference(referenceNames[i]).Load();
                }
            }
            return list;
        }
        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectSet.FirstOrDefault(where);
        }
        public int Insert(T obj)
        {
            _objectSet.Add(obj);
            return Save();
        }
        public int Update(T obj)
        {
            var entries = _dbContext.ChangeTracker.Entries();

            foreach (var item in entries)
            {
                item.State = EntityState.Detached;
            }

            _dbContext.Entry(obj).State = EntityState.Modified;

            return Save();
        }
        public int Delete(T obj)
        {
            _objectSet.Remove(obj);
            return Save();
        }
        public int Save()
        {
            return _dbContext.SaveChanges();
        }
    }
}
