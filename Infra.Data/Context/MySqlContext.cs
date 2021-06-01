using StoneChallenge_Payslip.Domain.Entities;
using StoneChallenge_Payslip.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace StoneChallenge_Payslip.Infra.Data.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {

        }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(new EmployeeMap().Configure);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                string connectionString = "Server = localhost; Port = 3306; user = root; password = M36nbp7@1; database = StoneChallengePayslipDB";
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), opt =>
                {
                    opt.CommandTimeout(180);
                    opt.EnableRetryOnFailure(5);
                });
            }
        }
    }
}
