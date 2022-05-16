using System.Collections.Generic;

namespace FirstProjectDemo.Models.Repository.Interface
{
    public interface IBooks
    {
        bool DeleteBook(int id);

    }

    public interface GenericInterface<T>
    {
        List<T> GetData();
    }
}
