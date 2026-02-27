using CofeeShop.Business.Models;
using CofeeShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CofeeShop.Business.IServices
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto?> GetByIdAsync(int id);
        Task<EmployeeDto> CreateAsync(CreateEmployeeRequest request);
        Task<EmployeeDto?> UpdateAsync(int id, UpdateEmployeeRequest request);
        Task<bool> DeleteAsync(int id, int? modifiedBy);
    }
}
