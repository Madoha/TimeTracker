using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using TimeTracker.Data;
using TimeTracker.Models.Entities;
using TimeTracker.Models.Enums.Finance;

namespace TimeTracker.Repositories
{
    public class FinanceRepository
    {
        string connectionString;
        private readonly ApplicationDbContext dbContext;


        public FinanceRepository(string connectionString, ApplicationDbContext _dbContext)
        {
            this.connectionString = connectionString;
            this.dbContext = _dbContext;
        }

        public List<Finance> GetFinances()
        {
            var prodList = dbContext.Finance.ToList();
            foreach (var emp in prodList)
            {
                dbContext.Entry(emp).Reload();
            }
            //var f = dbContext.Product.ToList();
            return prodList;
        }
        public List<FinanceForGraph> GetProductsForGraph()
        {
            List<FinanceForGraph> financesForGraph = new List<FinanceForGraph>();

            financesForGraph = dbContext.Finance.GroupBy(p => p.Category)
                .Select(g => new FinanceForGraph
                {
                    Category = g.Key.ToString(),
                    Finances = g.Count()
                }).ToList();
            return financesForGraph;
        }
    }
}