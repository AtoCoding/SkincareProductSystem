using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;

namespace BusinessLogicLayer.Services
{
    public class TypeOfSkinService : IService<TypeOfSkin>
    {
        private static TypeOfSkinService _Instance = null!;

        private readonly TypeOfSkinRepository _TypeOfSkinRepository;

        private TypeOfSkinService()
        {
            _TypeOfSkinRepository = TypeOfSkinRepository.GetInstance();
        }

        public static TypeOfSkinService GetInstance() => _Instance ??= new TypeOfSkinService();

        public bool Add(TypeOfSkin data)
        {
            return false;
        }

        public bool Delete(int id)
        {
            return false;
        }

        public TypeOfSkin? Get(int id)
        {
            return null!;
        }

        public List<TypeOfSkin> GetAll()
        {
            return _TypeOfSkinRepository.GetAll();
        }

        public List<TypeOfSkin> Search(string? keyword)
        {
            return [];
        }

        public bool Update(TypeOfSkin data)
        {
            return false;
        }
    }
}
