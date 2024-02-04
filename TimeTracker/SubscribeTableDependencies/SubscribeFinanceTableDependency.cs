using TableDependency.SqlClient;
using TimeTracker.Hubs;
using TimeTracker.Models.Entities;


namespace TimeTracker.SubscribeTableDependencies
{
    public class SubscribeFinanceTableDependency : ISubscribeTableDependency
    {
        SqlTableDependency<Finance> tableDependency;
        DashboardHub dashboardHub;

        public SubscribeFinanceTableDependency(DashboardHub dashboardHub)
        {
            this.dashboardHub = dashboardHub;
        }

        public void SubscribeTableDependency(string connectionString)
        {
            tableDependency = new SqlTableDependency<Finance>(connectionString);
            tableDependency.OnChanged += TableDependency_OnChanged;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();
        }

        private async void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Finance> e)
        {
            if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
                await dashboardHub.SendFinances();
            }
        }

        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(Finance)} SqlTableDependency error: {e.Error.Message}");
        }
    }
}