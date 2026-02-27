using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CofeeShop.Data.IRepositories
{
    public interface IReportRepository
    {
        Task<decimal> GetRevenueAsync(DateTime from, DateTime to);
        Task<int> GetCustomerCountAsync(DateTime from, DateTime to);
    }
}
