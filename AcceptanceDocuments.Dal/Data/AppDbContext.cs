using AcceptanceDocuments.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace AcceptanceDocuments.Dal.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Documentt> Documents => Set<Documentt>();
    public DbSet<DocumentType> DocumentTypes => Set<DocumentType>();
    public DbSet<DocumentFieldDefinition> DocumentFieldDefinitions => Set<DocumentFieldDefinition>();
    public DbSet<DocumentFieldValue> DocumentFieldValues => Set<DocumentFieldValue>();
    public DbSet<DocumentTypeFieldDefinition> DocumentTypeFieldDefinitions => Set<DocumentTypeFieldDefinition>();
}

