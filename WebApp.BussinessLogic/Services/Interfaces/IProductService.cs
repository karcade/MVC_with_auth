using WebApp.Model.DatabaseModels;

namespace WebApp.BussinessLogic.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
        void Create(Product product);
        void Update(Product product); 
        void Delete(int id);
    }
}
