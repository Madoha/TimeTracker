using System.Data;
using TimeTracker.Models.Entities;

namespace TimeTracker.Repositories.Interfaces
{
    public interface FinanceRepository
    {
        List<Finance> GetFinances();
    }
}
