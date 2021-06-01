using StoneChallenge_Payslip.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoneChallenge_Payslip.Infra.Data.Mapping
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name");

            builder.Property(x => x.Identification)
                .IsRequired()
               .HasColumnName("Identification"); 

            builder.Property(x => x.Admission)
                .IsRequired()
                .HasColumnName("Admission");

            builder.Property(x => x.Salary)
                .IsRequired()
                .HasColumnName("Salary");

            builder.Property(x => x.LastName)
               .HasColumnName("LastName");

            builder.Property(x => x.Department)
                .HasColumnName("Department");

            builder.Property(x => x.HealthPlan)
                .HasColumnName("HealthPlan");

            builder.Property(x => x.DentalPlan)
                .HasColumnName("DentalPlan");

            builder.Property(x => x.CommuterBenefits)
                .HasColumnName("CommuterBenefits");
        }
    }
}
