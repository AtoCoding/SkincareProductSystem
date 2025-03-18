using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;

namespace BusinessLogicLayer.Services
{
    public class RoleService : IService<RoleDto>
    {
        private static RoleService _Instance = null!;
        private readonly IRepository<Role> _RoleRepository;

        private RoleService()
        {
            _RoleRepository = RoleRepository.GetInstance();
        }

        public static RoleService GetInstance() => _Instance ??= new RoleService();

        public RoleDto Add(RoleDto data)
        {
            return null!;
        }

        public bool Delete(int id)
        {
            return false;
        }

        public RoleDto? Get(int id)
        {
            return null;
        }

        public List<RoleDto> GetAll()
        {
            return [];
        }

        public List<RoleDto> Search(string? keyword)
        {
            return [];
        }

        public RoleDto? Update(RoleDto data)
        {
            return null;
        }
    }
}
