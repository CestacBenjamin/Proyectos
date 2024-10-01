using ProyectoTarea_04_.Models;

namespace ProyectoTarea_04_.Data.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private Services_dbContext _dbContext;

        public ServiceRepository(Services_dbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void create(TServicio servicio)
        {
            _dbContext.TServicios.Add(servicio);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var Service_delete = GetById(id);
            if (Service_delete != null) 
            { 
                _dbContext.TServicios.Remove(Service_delete);
                _dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Error No se encontro el Servicio Buscado!");
            }
        }

        public List<TServicio> GetAll()
        {
            return _dbContext.TServicios.ToList();
        }

        public TServicio? GetById(int id)
        {
            return _dbContext.TServicios.Find(id);
        }

        public void Update(TServicio servicio)
        {
            _dbContext.Update(servicio);
            _dbContext.SaveChanges();
        }
    }
}
