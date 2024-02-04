using Microsoft.AspNetCore.SignalR;
using TimeTracker.Data;
using TimeTracker.Repositories;

namespace TimeTracker.Hubs
{
    public class DashboardHub : Hub
    {
        FinanceRepository financeRepository;
        private readonly ApplicationDbContext dbContext;

        public DashboardHub(IConfiguration configuration, ApplicationDbContext _dbContext)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            dbContext = _dbContext;
            financeRepository = new FinanceRepository(connectionString, dbContext);
        }

        public async Task SendFinances()
        {
            var finances = financeRepository.GetFinances();
            await Clients.All.SendAsync("ReceivedFinances", finances);

            var financeForGraph = financeRepository.GetProductsForGraph();
            await Clients.All.SendAsync("ReceivedFinancesForGraph", financeForGraph);
        }
    }
}