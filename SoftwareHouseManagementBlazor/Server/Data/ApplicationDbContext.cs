using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SoftwareHouseManagementBlazor.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = SoftwareHouseManagementBlazor.Server.Models.Task;

namespace SoftwareHouseManagementBlazor.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<Worker>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Responsibilities> Responsibilities { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<HoursWorked> HoursWorked { get; set; }
        public DbSet<Access> Accesses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
