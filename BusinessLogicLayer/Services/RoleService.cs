using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;

namespace BusinessLogicLayer.Services
{
    public class RoleService : IService<RoleDto>
    {
        private readonly IRepository<Role> _RoleRepository;

        public RoleService()
        {
            _RoleRepository = new RoleRepository();
        }

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

        public RoleDto? Update(RoleDto data)
        {
            return null;
        }
    }
}
