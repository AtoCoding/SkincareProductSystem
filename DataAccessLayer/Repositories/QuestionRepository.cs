using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;

namespace DataAccessLayer.Repositories
{
    public class QuestionRepository : IRepository<Question>
    {
        private static QuestionRepository _Instance = null!;
        private readonly SkincareProductSystemContext __SkincareProductSystemContext;

        private QuestionRepository()
        {
            __SkincareProductSystemContext = new();
        }

        public static QuestionRepository GetInstance() => _Instance ??= new QuestionRepository();

        public bool Add(Question data)
        {
            return false;
        }

        public bool Delete(int id)
        {
            return false;
        }

        public Question? Get(int id)
        {
            return null!;
        }

        public List<Question> GetAll()
        {
            return [];
        }

        public List<Question> Search(string? keyword)
        {
            return [];
        }

        public bool Update(Question data)
        {
            return false;
        }
    }
}
