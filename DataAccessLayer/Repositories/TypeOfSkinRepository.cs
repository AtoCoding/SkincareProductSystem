using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;

namespace DataAccessLayer.Repositories
{
    public class TypeOfSkinRepository : IRepository<TypeOfSkin>
    {
        private static TypeOfSkinRepository _Instance = null!;
        private readonly SkincareProductSystemContext __SkincareProductSystemContext;

        private TypeOfSkinRepository()
        {
            __SkincareProductSystemContext = new();
        }

        public static TypeOfSkinRepository GetInstance() => _Instance ??= new TypeOfSkinRepository();

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
