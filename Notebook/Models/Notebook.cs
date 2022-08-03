using Microsoft.EntityFrameworkCore;

namespace Notebook.Models
{
  public class NotebookContext : DbContext
  {
    public DbSet<Category> Categories { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<CategoryNote> CategoryNote { get; set; }

    public NotebookContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}