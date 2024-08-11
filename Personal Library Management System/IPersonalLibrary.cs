using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Library_Management_System
{
    public interface IPersonalLibrary
    {
        void AddBook(Book book, string jsonFile, string txtFile);
        void ViewAllBooks();
        List<Book> Load(string filepath);
        /*void RentBook(Book book);
         * 
         void UpdateBook(Book book, string title);
         void DeleteBook(string title);
         Book SearchForBook(string title = "", string author = "");
         void Save(List<Book> books, string filepath);*/
        //
    }
}
