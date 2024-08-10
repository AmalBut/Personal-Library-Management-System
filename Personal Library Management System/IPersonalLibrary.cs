using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Library_Management_System
{
    public interface IPersonalLibrary
    {
        void AddBook(Book book, string filepath);

        List<Book> Load(string filepath);
        /* List<Book> GetAllBooks();
         void UpdateBook(Book book, string title);
         void DeleteBook(string title);
         Book SearchForBook(string title = "", string author = "");
         void Save(List<Book> books, string filepath);*/
        //
    }
}
