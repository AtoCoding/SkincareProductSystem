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
            return __SkincareProductSystemContext.TypeOfSkins.ToList();
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
