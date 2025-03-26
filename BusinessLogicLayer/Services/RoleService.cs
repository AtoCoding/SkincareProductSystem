using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;

namespace BusinessLogicLayer.Services
{
    public class RoleService : IService<Role>
    {
        private static RoleService _Instance = null!;
        private readonly IRepository<Role> _RoleRepository;

        private RoleService()
        {
            _RoleRepository = RoleRepository.GetInstance();
        }

        public static RoleService GetInstance() => _Instance ??= new RoleService();

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
