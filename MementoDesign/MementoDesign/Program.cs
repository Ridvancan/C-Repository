using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoDesign
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Book
    {

        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
    }

    class Memento
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
    }
    public Memento CreateUndo()
    {
        return new Memento(_isbn, _title, _author, _lastEdited);
    }

    public void RestoreFromUndo(Memento memento)
    {
        _title = memento.Title;
        _isbn = memento.Isbn;
        _lastEdited = memento.LastEdited;
        _author = memento.Author;


    }
    class CareTaker
    {
        public Memento memento { get; set; }
    }
}
