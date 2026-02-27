using CofeeShop.Business.IServices;
using CofeeShop.Business.Models;
using CofeeShop.Data.Entities;
using CofeeShop.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CofeeShop.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            var employees = await _repository.GetAllAsync();

            return employees.Select(e => new EmployeeDto
            {
                Employeeid = e.Employeeid,
                Employeename = e.Employeename,
                Createdat = e.Createdat,
                Modifiedat = e.Modifiedat
            }).ToList();
        }

        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee == null) return null;

            return new EmployeeDto
            {
                Employeeid = employee.Employeeid,
                Employeename = employee.Employeename,
                Createdat = employee.Createdat,
                Modifiedat = employee.Modifiedat
            };
        }

        public async Task<EmployeeDto> CreateAsync(CreateEmployeeRequest request)
        {
            var employee = new Employee
            {
                Employeename = request.Employeename,
                Createdby = request.Createdby,
                Createdat = DateTime.Now,
                Isdeleted = false
            };

            await _repository.AddAsync(employee);
            await _repository.SaveChangesAsync();

            return new EmployeeDto
            {
                Employeeid = employee.Employeeid,
                Employeename = employee.Employeename,
                Createdat = employee.Createdat
            };
        }

        public async Task<EmployeeDto?> UpdateAsync(int id, UpdateEmployeeRequest request)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee == null) return null;

            employee.Employeename = request.Employeename;
            employee.Modifiedby = request.Modifiedby;
            employee.Modifiedat = DateTime.Now;

            _repository.Update(employee);
            await _repository.SaveChangesAsync();

            return new EmployeeDto
            {
                Employeeid = employee.Employeeid,
                Employeename = employee.Employeename,
                Createdat = employee.Createdat,
                Modifiedat = employee.Modifiedat
            };
        }

        public async Task<bool> DeleteAsync(int id, int? modifiedBy)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee == null) return false;

            employee.Isdeleted = true;
            employee.Modifiedby = modifiedBy;
            employee.Modifiedat = DateTime.Now;

            _repository.Update(employee);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
