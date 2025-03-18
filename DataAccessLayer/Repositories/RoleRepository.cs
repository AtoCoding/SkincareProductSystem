using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;

namespace BusinessLogicLayer.Services
{
    public class RoleRepository : IRepository<Role>
    {
        private static RoleRepository _Instance = null!;
        private readonly SkincareProductSystemContext _SkincareProductSystemContext;

        private RoleRepository()
        {
            _SkincareProductSystemContext = new();
        }

        public static RoleRepository GetInstance() => _Instance ??= new RoleRepository();

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

        public List<Role> Search(string? keyword)
        {
            return [];
        }

        public Role? Update(Role data)
        {
            return null;
        }
    }
}
