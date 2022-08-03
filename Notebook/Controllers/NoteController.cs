using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Notebook.Models;
using System.Collections.Generic;
using System.Linq;

namespace Notebook.Controllers
{
  public class NotesController : Controller
  {
    private readonly NotebookContext _db;

    public NotesController(NotebookContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Notes.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Note note, int CategoryId)
    {
      _db.Notes.Add(note);
      _db.SaveChanges();
      if (CategoryId != 0)
      {
        _db.CategoryNote.Add(new CategoryNote() { CategoryId = CategoryId, NoteId = note.NoteId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisNote = _db.Notes
        .Include(note => note.JoinEntities)
        .ThenInclude(join => join.Category)
        .FirstOrDefault(note => note.NoteId == id);
      return View(thisNote);
    }

    public ActionResult Edit(int id)
    {
      var thisNote = _db.Notes.FirstOrDefault(note => note.NoteId == id);
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View(thisNote);
    }

    [HttpPost]
    public ActionResult Edit(Note note, int CategoryId)
    {
      if (CategoryId != 0)
      {
        _db.CategoryNote.Add(new CategoryNote() { CategoryId = CategoryId, NoteId = note.NoteId });
      }
      _db.Entry(note).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisNote = _db.Notes.FirstOrDefault(note => note.NoteId == id);
      return View(thisNote);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisNote = _db.Notes.FirstOrDefault(note => note.NoteId == id);
      _db.Notes.Remove(thisNote);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

     public ActionResult AddCategory(int id)
     {
      var thisNote = _db.Notes.FirstOrDefault(note => note.NoteId == id);
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View(thisNote);
     }

    [HttpPost]
     public ActionResult AddCategory(Note note, int CategoryId)
     {
      if (CategoryId != 0)
      {
        _db.CategoryNote.Add(new CategoryNote() { CategoryId = CategoryId, NoteId = note.NoteId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
     }
    
    [HttpPost]
    public ActionResult DeleteCategory(int joinId)
    {
      var joinEntry = _db.CategoryNote.FirstOrDefault(entry => entry.CategoryNoteId == joinId);
      _db.CategoryNote.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}