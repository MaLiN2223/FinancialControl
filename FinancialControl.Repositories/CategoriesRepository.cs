using System.Collections.Generic;
using System.Drawing; 


namespace FinancialControl.Repositories
{
    public class Category
    { 
        public string Title { get; set; }
        public string Description { get; set; }
        public Color Color { get; set; }
    }
    public interface ICategoriesRepository
    {
        List<Category> Categores { get; }
    }
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly IDataAccessProxy _dataAccess;
        private readonly IPathRepository _repository;
        private List<Category> _categories;

        public CategoriesRepository(IDataAccessProxy dataAccess, IPathRepository repository)
        {
            _dataAccess = dataAccess;
            _repository = repository;
        }

        public List<Category> Categores
        {
            get
            {
                if (_categories == null)
                    _categories = _dataAccess.GetCategories();
                return _categories;
            }
        }
    }
}