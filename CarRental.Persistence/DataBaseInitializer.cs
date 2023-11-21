using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistence
{
    internal sealed class DataBaseInitializer(IServiceProvider serviceProvider)
    : BackgroundService
    {
        public const string ActivitySourceName = "Migrations";

        private readonly ActivitySource _activitySource = new(ActivitySourceName);

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<DataBaseContext>();

            await InitializeDatabaseAsync(dbContext, cancellationToken);
        }

        private async Task InitializeDatabaseAsync(DataBaseContext dbContext, CancellationToken cancellationToken)
        {
            var strategy = dbContext.Database.CreateExecutionStrategy();

            using var activity = _activitySource.StartActivity("Migrating catalog database", ActivityKind.Client);

            var sw = Stopwatch.StartNew();

            await strategy.ExecuteAsync(() => dbContext.Database.MigrateAsync(cancellationToken));
        }
    }
}
