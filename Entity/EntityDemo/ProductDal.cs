using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDemo
{
    public class ProductDal
    {
        public List<Product> GetAll()
        {
            using (EtradeContext context = new EtradeContext())
            {
                return context.Product.ToList();
            }
        }
        public List<Product> GetByname(String key   )
        {
            using (EtradeContext context = new EtradeContext())
            {
                return context.Product.Where(p => p.Name.Contains(key)).ToList();
            }
        }
        public List<Product> GetByUnitPrice(decimal min,decimal max)
        {
            using (EtradeContext context = new EtradeContext())
            {
                return context.Product.Where(p => p.UnitPrice>=min && p.UnitPrice<=max).ToList();
            }
        }
        public Product GetById(int id)
        {
            using (EtradeContext context = new EtradeContext())
            {
                var result = context.Product.FirstOrDefault(p => p.Id == id);
                return result;

            }
        }
        public void Add(Product product)
        {
            using (EtradeContext context = new EtradeContext())
            {
                context.Product.Add(product);
                context.SaveChanges();
            }
        }
        public void Update(Product product)
        {
            using (EtradeContext context = new EtradeContext())
            {
                var entity = context.Entry(product);
                entity.State = System.Data.Entity.EntityState.Modified;

                context.SaveChanges();
            }
        }
        public void Delete(Product product)
        {
            using (EtradeContext context = new EtradeContext())
            {
                var entity = context.Entry(product);
                entity.State = System.Data.Entity.EntityState.Deleted;

                context.SaveChanges();
            }

        }
    }
}

