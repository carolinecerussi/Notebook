using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Notebook.Models;
using System;
using MySql.Data.MySqlClient;


namespace Notebook.Tests
{
  [TestClass]
  public class NoteTests : IDisposable
  {

    public void Dispose()
    {
      Note.ClearAll();
    }

    public NoteTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=to_do_list_test;";
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_NoteList()
    {
      //Arrange
      List<Note> newList = new List<Note> { };

      //Act
      List<Note> result = Note.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Save_SavesToDatabase_NoteList()
    {
      //Arrange
      Note testNote = new Note("Mow the lawn");

      //Act
      testNote.Save();
      List<Note> result = Note.GetAll();
      List<Note> testList = new List<Note>{testNote};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsNotes_NoteList()
    {
      //Arrange
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Note newNote1 = new Note(description01);
      newNote1.Save();
      Note newNote2 = new Note(description02);
      newNote2.Save();
      List<Note> newList = new List<Note> { newNote1, newNote2 };

      //Act
      List<Note> result = Note.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
    [TestMethod]
    public void Find_ReturnsCorrectNoteFromDatabase_Note()
    {
      //Arrange
      Note newNote = new Note("Mow the lawn");
      newNote.Save();
      Note newNote2 = new Note("Wash dishes");
      newNote2.Save();

      //Act
      Note foundNote = Note.Find(newNote.Id);

      //Assert
      Assert.AreEqual(newNote, foundNote);
    }


    [TestMethod]
    public void NoteConstructor_CreatesInstanceOfNote_Note()
    {
      Note newNote = new Note("test");
      Assert.AreEqual(typeof(Note), newNote.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      //Arrange
      string description = "Walk the dog";

      //Act
      Note newNote = new Note(description);
      string result = newNote.Description;

      //Assert
      Assert.AreEqual(description, result);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      //Arrange
      string description = "Walk the dog";
      Note newNote = new Note(description);

      //Act
      string updatedDescription = "Do the dishes";
      newNote.Description = updatedDescription;
      string result = newNote.Description;

      //Assert
      Assert.AreEqual(updatedDescription, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_NoteList()
    {
      // Arrange
      List<Note> newList = new List<Note> { };

      // Act
      List<Note> result = Note.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }
    

    [TestMethod]
    public void GetId_NotesInstantiateWithAnIdAndGetterReturns_Int()
    {
      //Arrange
      string description = "Walk the dog";
      Note newNote = new Note(description);

      //Act
      int result = newNote.Id;

      //Assert
      Assert.AreEqual(1, result);
    }

  
  }
}