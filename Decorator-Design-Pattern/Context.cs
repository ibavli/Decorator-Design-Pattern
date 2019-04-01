using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Design_Pattern
{
    public class Context<T>
    {
        //Bu sınıfın bir ORM context'i olduğunu düşünün

        public void Add(T entity)
        {
            Console.WriteLine("-'" + typeof(T).FullName + "' adlı entity veritabanına eklendi.");
        }

        public void Update(T entity)
        {
            Console.WriteLine("-'" + typeof(T).FullName + "' adlı entity veritabanında güncellendi");
        }

        public void Delete(T entity)
        {
            Console.WriteLine("-'" + typeof(T).FullName + "' adlı entity veritabanından silindi.");
        }

        public T Get(int id)
        {
            Console.WriteLine("-'" + typeof(T).FullName + "' adlı entity veritabanından çekildi.");
            T entity = (T)Activator.CreateInstance(typeof(T));
            return entity;
        }

    }
}
