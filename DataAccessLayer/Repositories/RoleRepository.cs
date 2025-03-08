using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;

namespace BusinessLogicLayer.Services
{
    public class RoleRepository : IRepository<Role>
    {
        private readonly SkincareProductSystemContext _SkincareProductSystemContext;

        public RoleRepository()
        {
            _SkincareProductSystemContext = new();
        }

        public Role Add(Role data)
        {
            return null!;
        }

        public bool Delete(int id)
        {
            return false;
        }

        public Role? Get(int id)
        {
            return null;
        }

        public List<Role> GetAll()
        {
            return [];
        }

        public Role? Update(Role data)
        {
            return null;
        }
    }
}
