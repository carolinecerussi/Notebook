namespace Notebook.Models
{
  public class CategoryNote
  {
    public int CategoryNoteId { get; set; }
    public int NoteId { get; set; }
    public int CategoryId { get; set; }
    public virtual Note Note { get; set; }
    public virtual Category Category { get; set; }

  }
}