
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
    public string NoteTitle { get; set; }
    public string NoteContent {get;set;}
    public string NoteDate {get;set;}
    public virtual ICollection<CategoryNote> JoinEntities { get; }
  }
}

