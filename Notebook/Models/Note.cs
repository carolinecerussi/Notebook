
using System.Collections.Generic;

namespace Notebook.Models
{
  public class Note
  {
    public Note()
    {
      this.JoinEntities = new HashSet<CategoryNote>();
    }
    public int NoteId { get; set; }
    public string Description { get; set; }
    public virtual ICollection<CategoryNote> JoinEntities { get; }
  }
}