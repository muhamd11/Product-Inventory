﻿using Api.Scrutor;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.Products.DTO;

namespace Api.Controllers.AdditionsModules.Products.Interfaces
{
    public interface IProductValid : ITransientService
    {
        public BaseValid ValidGetDetails(BaseGetDetailsDto inputModel);

        public BaseValid ValidGetAll(BaseSearchDto inputModel);

        public BaseValid ValidAddOrUpdate(ProductAddOrUpdateDTO inputModel, bool isUpdate);

        public BaseValid ValidDelete(BaseDeleteDto inputModel);

        public BaseValid ValidProductId(int productId);
    }
}