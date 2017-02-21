using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    [Serializable]
    public class RepositoryObject<T>
    {
        public int Id { get; set; }
        public T Object { get; set; }

        public RepositoryObject()
        {
        }

        public RepositoryObject(int id, T obj)
        {
            Id = id;
            Object = obj;
        }

    }
}