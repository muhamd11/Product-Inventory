using App.Shared.Interfaces.Scrutor;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.Products;
using App.Shared.Models.Products.DTO;
using System.Threading.Tasks;

namespace Api.Controllers.ProductsModules.Products.Interfaces
{
    public interface IProductServices : ITransientService
    {
        Task<BaseGetDataWithPagnation<ProductInfo>> GetAllAsync(ProductSearchDto inputModel);

        Task<ProductInfoDetails> GetDetails(BaseGetDetailsDto inputModel);

        Task<BaseActionDone<ProductInfo>> AddOrUpdate(ProductAddOrUpdateDTO inputModel, bool isUpdate);

        Task<BaseActionDone<ProductInfo>> DeleteAsync(BaseDeleteDto inputModel);
    }
}