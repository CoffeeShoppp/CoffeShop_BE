using CofeeShop.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CofeeShop.Data.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly AppDbContext _context;

        public ReportRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> GetRevenueAsync(DateTime from, DateTime to)
        {
            return await _context.Payments
                .Where(x =>
                    x.Paymenttime >= from &&
                    x.Paymenttime <= to &&
                    x.Status == "Paid")
                .SumAsync(x => x.Amount ?? 0);
        }

        public async Task<int> GetCustomerCountAsync(DateTime from, DateTime to)
        {
            return await _context.Orders
                .Where(x =>
                    x.Ordertime >= from &&
                    x.Ordertime <= to &&
                    x.Status == "Completed" &&
                    x.Customerid != null &&
                    x.Isdeleted != true)
                .Select(x => x.Customerid)
                .Distinct()
                .CountAsync();
        }
    }
}
