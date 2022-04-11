using Greenwich.DataPersistence.Common;
using Greenwich.EntityFramework.Entities;
using Greenwich.Models.Requests;
using Greenwich.WebService.IServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenwich.WebService.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGEWUnitOfWork _unitOfWork;
        private ILogger<CategoryService> _logger;

        public CategoryService(IGEWUnitOfWork unitOfWork, ILogger<CategoryService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<bool> CreateCategoryAsync(CreateCategoryRequest request)
        {
            try
            {
                var categoryDTO = new Category { 
                    Name = request.Name,
                    Description = request.Description
                };

                await _unitOfWork.CategoryRepository.InsertAsync(categoryDTO);
                return await _unitOfWork.SaveChangeAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while CreateUserAsync", ex);
            }
            return false;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {            
            try
            {
                IEnumerable<Category>  modelList = await _unitOfWork.CategoryRepository.GetAsync();
                return modelList;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while GetALlUsersAsync", ex);
            }

            return new List<Category>();
        }

        public async Task<bool> UpdateCategoryAsync(Category model)
        {
            var categoryDTO = await _unitOfWork.CategoryRepository.GetByIdAsync(model.Id);
            if (categoryDTO != null)
            {
                categoryDTO.Name = model.Name;
                categoryDTO.Description = model.Description;

                _unitOfWork.CategoryRepository.Update(categoryDTO);
                return await _unitOfWork.SaveChangeAsync() > 0;
            }

            return false;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var categoryDTO = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (categoryDTO != null)
            {
                _unitOfWork.CategoryRepository.Delete(categoryDTO);
                return await _unitOfWork.SaveChangeAsync() > 0;
            }

            return false;
        }
    }
}
