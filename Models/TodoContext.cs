using Microsoft.EntityFrameworkCore;
using Planner.Models;
namespace PlannerBlazor.Models;

/// <summary>
/// Construtor De Conexão com o banco de dados
/// <summary>   
public class TodoContext : DbContext
{
    /// Cria a tabela de "Todo" com o nome "Todos"
    public DbSet<Todo> Todos => Set<Todo>();

    ///Cria a tabela de "Category" com o nome "Categories"
    public DbSet<Category> Categories => Set<Category>();

    public TodoContext(DbContextOptions<TodoContext> options) : base(options) {}

    /// <summary>
    /// Fluent API
    /// <summary>  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ///Titulo da tabela "Category" é requerida e com max 256 caracteres
        modelBuilder.Entity<Category>().Property(t => t.Description)
            .IsRequired()
            .HasMaxLength(256);       
        
        ///Titulo da tabela "Todo" é requerida e com max 100 caracteres
        modelBuilder.Entity<Todo>().Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(100);

        ///Titulo da tabela "Description" é requerida e com max 256 caracteres
        modelBuilder.Entity<Todo>().Property(t => t.Description)
            .IsRequired()
            .HasMaxLength(256);

        ///Se a tabela "Category" não for preenchida,adicionar estes dados default
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Description = "Trabalho" },
            new Category { Id = 2, Description = "Pessoal" },
            new Category { Id = 3, Description = "Outro" }
        );

    }
}
