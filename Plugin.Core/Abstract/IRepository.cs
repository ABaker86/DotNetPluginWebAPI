using System.Linq;

namespace Plugin.Core;

public interface IGetAll<T>
{
    IEnumerable<T> GetAll();
}

public interface IGetById<T>
{
    T GetById(int id);
}

public interface IUpdate<T>
{
    T Update(T data);
}

public interface IDelete<T>
{
    bool Delete(T data);
}

public interface IInsert<T>
{
    IEnumerable<T> Insert(IEnumerable<T> data);
}