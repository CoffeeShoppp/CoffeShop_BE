using CofeeShop.Business.IServices;
using CofeeShop.Business.Models;
using CofeeShop.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CofeeShop.Business.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repository;

        public ReportService(IReportRepository repository)
        {
            _repository = repository;
        }

        public async Task<RevenueDto> GetRevenueAsync(DateTime from, DateTime to)
        {
            var total = await _repository.GetRevenueAsync(from, to);

            return new RevenueDto
            {
                From = from,
                To = to,
                TotalRevenue = total
            };
        }

        public async Task<CustomerCountDto> GetCustomerCountAsync(DateTime from, DateTime to)
        {
            var total = await _repository.GetCustomerCountAsync(from, to);

            return new CustomerCountDto
            {
                From = from,
                To = to,
                TotalCustomers = total
            };
        }
    }
}
