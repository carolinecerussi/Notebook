using System.Collections.Generic;

namespace Notebook.Models
{
  public class Category
  {
    public Category()
    {
      this.JoinEntities = new HashSet<CategoryNote>();
    }

    public int CategoryId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<CategoryNote> JoinEntities { get; set; }
  }
  
}