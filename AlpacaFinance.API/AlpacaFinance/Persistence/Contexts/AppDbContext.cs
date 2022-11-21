using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AlpacaFinance.API.AlpacaFinance.Persistence.Contexts;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }


    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Operacion> Operacions { get; set; }
    public DbSet<RateType> RateTypes { get; set; }
    public DbSet<Divisa> Divisas { get; set; }
    public DbSet<CashFlow> CashFlows { get; set; }
    public DbSet<GracePeriod> GracePeriods { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        //Table Creation

        builder.Entity<Usuario>().ToTable("Usuarios");
        builder.Entity<RateType>().ToTable("RateTypes");
        builder.Entity<Divisa>().ToTable("Divisas");
        builder.Entity<GracePeriod>().ToTable("GracePeriods");
        builder.Entity<CashFlow>().ToTable("CashFlows");
        builder.Entity<Operacion>().ToTable("Operacions");

        //Property Creation

        //Usuario
        builder.Entity<Usuario>().HasKey(p => p.Id);
        builder.Entity<Usuario>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Usuario>().Property(p => p.Name).IsRequired().HasMaxLength(75);
        builder.Entity<Usuario>().Property(p => p.DNI).IsRequired().HasMaxLength(8);
        builder.Entity<Usuario>().Property(p => p.Email).IsRequired().HasMaxLength(50);
        builder.Entity<Usuario>().Property(p => p.Direction).IsRequired().HasMaxLength(100);
        builder.Entity<Usuario>().Property(p => p.Country).IsRequired().HasMaxLength(30);
        builder.Entity<Usuario>().Property(p => p.Password).IsRequired().HasMaxLength(50);
        builder.Entity<Usuario>().Property(p => p.Telephone).IsRequired().HasMaxLength(15);
        builder.Entity<Usuario>().Property(p => p.ImageURL);

        //Operacion
        builder.Entity<Operacion>().HasKey(p => p.Id);
        builder.Entity<Operacion>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Operacion>().Property(p => p.Percentage).IsRequired();
        builder.Entity<Operacion>().Property(p => p.Import).IsRequired();
        builder.Entity<Operacion>().Property(p => p.Date).IsRequired();

        //RateType
        builder.Entity<RateType>().HasKey(p => p.Id);
        builder.Entity<RateType>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<RateType>().Property(p => p.NameType).IsRequired().HasMaxLength(50);

        //CashFlow
        builder.Entity<CashFlow>().HasKey(p => p.Id);
        builder.Entity<CashFlow>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<CashFlow>().Property(p => p.ActivityType).IsRequired().HasMaxLength(100);
        builder.Entity<CashFlow>().Property(p => p.MonthlyFlow).IsRequired();
        builder.Entity<CashFlow>().Property(p => p.ActivityDescription).IsRequired().HasMaxLength(500);

        //Divisa
        builder.Entity<Divisa>().HasKey(p => p.Id);
        builder.Entity<Divisa>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Divisa>().Property(p => p.NameDivisa).IsRequired().HasMaxLength(50);

        //GracePeriod
        builder.Entity<GracePeriod>().HasKey(p => p.Id);
        builder.Entity<GracePeriod>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<GracePeriod>().Property(p => p.Period).IsRequired();
        builder.Entity<GracePeriod>().Property(p => p.InitialDebt).IsRequired();
        builder.Entity<GracePeriod>().Property(p => p.MonthlyFactor).IsRequired();
        builder.Entity<GracePeriod>().Property(p => p.PreviousDebt).IsRequired();
        builder.Entity<GracePeriod>().Property(p => p.MonthlyPayment).IsRequired();
        builder.Entity<GracePeriod>().Property(p => p.FinalDebt).IsRequired();

        //Relationship Creation

        //Operacion-Usuario
        builder.Entity<Operacion>()
            .HasOne(p => p.Usuario)
            .WithMany(p => p.OperacionUsuario)
            .HasForeignKey(p=>p.UsuarioId);

        //Operacion-RateType
        builder.Entity<Operacion>()
            .HasOne(p => p.RateType)
            .WithMany(p => p.OperacionRateType)
            .HasForeignKey(p => p.RateTypeId);

        //Operacion-GracePeriod
        builder.Entity<Operacion>()
            .HasOne(p => p.GracePeriod)
            .WithMany(p => p.Operacions)
            .HasForeignKey(p => p.GracePeriodId);

        //Operacion-CashFlow
        builder.Entity<Operacion>()
            .HasOne(p => p.CashFlow)
            .WithMany(p => p.Operacions)
            .HasForeignKey(p => p.CashFlowId);

        //Operacion-Divisa
        builder.Entity<Operacion>()
            .HasOne(p => p.Divisa)
            .WithMany(p => p.OperacionDivisa)
            .HasForeignKey(p => p.DivisaId);

        //Apply Naming Conventions
        builder.UseSnakeCaseNamingConvention();
    }
}
