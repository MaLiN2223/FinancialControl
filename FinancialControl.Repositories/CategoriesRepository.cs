using System.Collections.Generic;
using System.IO;
using Utils;

namespace FinancialControl.Repositories
{
    public interface ICategoriesRepository
    {
        List<Category> Categores { get; }
    }
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly IPathRepository _repository;
        private readonly ISerializer _serializer;
        private List<Category> _categories;

        public CategoriesRepository(IPathRepository repository, ISerializer serializer)
        {
            _repository = repository;
            _serializer = serializer;
        }

        public List<Category> Categores
        {
            get
            {
                if (_categories == null)
                    _categories = GetCategories();
                return _categories;
            }
        }

        private List<Category> GetCategories()
        {
            return _serializer.DeserializeList<Category>(Path.Combine(_repository.ApplicationDataDirectory, "Categories.mal"));

        }
    }
}