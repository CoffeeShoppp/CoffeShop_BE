using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CofeeShop.Data.Entities;

namespace CofeeShop.Data.IRepositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task AddAsync(Employee employee);
        void Update (Employee employee);
        Task SaveChangesAsync();
    }
}
