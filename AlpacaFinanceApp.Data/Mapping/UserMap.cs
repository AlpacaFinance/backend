using AlpacaFinanceApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpacaFinanceApp.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User")
                .HasKey(u => u.UserId);
            
            builder.Property(u => u.UserId)
                .HasColumnName("UserId")
                .ValueGeneratedOnAdd();
            
            builder.Property(u => u.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();
            
            builder.Property(u => u.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(u => u.DocumentType)
                .HasColumnName("DocumentType")
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(u => u.DocumentNumber)
                .HasColumnName("DocumentNumber")
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("Email")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(u => u.Country)
                .HasColumnName("Country")
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(u => u.RegisterDate)
                .HasColumnName("ResgisterAt")
                //.ValueGeneratedOnAdd()
                .IsRequired();
        }
    }
}
