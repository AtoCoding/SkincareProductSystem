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

        public TypeOfSkin Add(TypeOfSkin data)
        {
            return data;
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
            return [];
        }

        public List<TypeOfSkin> Search(string? keyword)
        {
            return [];
        }

        public TypeOfSkin? Update(TypeOfSkin data)
        {
            return null!;
        }
    }
}
