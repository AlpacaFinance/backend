using AlpacaFinanceApp.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpacaFinanceApp.Data.Mapping
{
    internal class OperationMap : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.ToTable("Operation")
                .HasKey(o => o.UserId);
            
            builder.Property(o => o.UserId)
                .HasColumnName("OperationId")
                .ValueGeneratedOnAdd();

            builder.Property(u => u.UserId)
                .HasColumnName("UserId")
                .ValueGeneratedOnAdd();

            builder.Property(o => o.Currency)
                .HasColumnName("Currency")
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(o => o.Amount)
                .HasColumnName("Amount")
                .HasColumnType("decimal(11,2)")
                .IsRequired();

            builder.Property(o => o.RateType)
                .HasColumnName("RateType")
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(o => o.InterestRate)
                .HasColumnName("InterestRate")
                .HasColumnType("decimal(11,2)")
                .IsRequired();

            builder.Property(u => u.OperationDate)
                .HasColumnName("OperationDate")
                .IsRequired();

            // fk
            builder.HasOne(u => u.User)
                .WithMany(u => u.History)
                .HasForeignKey(u => u.UserId)
                .HasConstraintName("FK_Operation_User")
                .IsRequired();
        }
    }
}
