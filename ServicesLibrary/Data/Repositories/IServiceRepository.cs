using ProyectoTarea_04_.Models;

namespace ProyectoTarea_04_.Data.Repositories
{
    public interface IServiceRepository
    {
        void create(TServicio servicio);
        List<TServicio> GetAll();
        TServicio GetById(int id);
        void Delete(int id);
        void Update(TServicio servicio);
    }
}
