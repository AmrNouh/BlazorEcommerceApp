using Website.Shared.Models;

namespace BlazorAppDay02.Components
{
    public partial class ViewAll
    {
        //private readonly IProductRepository _productRepository;
        //public readonly ICategoryRepository _categoryRepository;
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public int CategoryId { get; set; }

        //public ViewAll(IProductRepository productRepository, ICategoryRepository categoryRepository)
        //{
        //    _productRepository = productRepository;
        //    _categoryRepository = categoryRepository;
        //}

        //protected override void OnInitialized()
        //{
        //    base.OnInitialized();
        //    Categories = categoryRepository.GetAllAsync();
        //    Products = productRepository.GetAll();
        //}

        public void FilterProducts()
        {
            if (CategoryId != 0)
            {
                //Products = productRepository.FilterByCategoryId(CategoryId);
            }
            else
            {
                //Products = productRepository.GetAll();
            }
        }
    }
}
