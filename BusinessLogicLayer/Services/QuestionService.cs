using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;

namespace BusinessLogicLayer.Services
{
    public class QuestionService : IService<Question>
    {
        private static QuestionService _Instance = null!;
        private readonly QuestionRepository _QuestionRepository;

        private QuestionService()
        {
            _QuestionRepository = QuestionRepository.GetInstance();
        }

        public static QuestionService GetInstance() => _Instance ??= new QuestionService();

        public Question Add(Question data)
        {
            return data;
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

        public Question? Update(Question data)
        {
            return null!;
        }
    }
}
