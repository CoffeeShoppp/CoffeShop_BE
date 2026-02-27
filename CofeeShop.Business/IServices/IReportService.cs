using CofeeShop.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CofeeShop.Business.IServices
{
    public interface IReportService
    {
        Task<RevenueDto> GetRevenueAsync(DateTime from, DateTime to);
        Task<CustomerCountDto> GetCustomerCountAsync(DateTime from, DateTime to);
    }
}
