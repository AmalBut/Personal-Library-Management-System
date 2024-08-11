using System;
using System.Collections.Generic;

namespace Personal_Library_Management_System
{
    public interface IPersonalLibrary
    {
        void AddBook(Book book, string jsonFile, string txtFile);
        void ViewAllBooks(string jsonFile);

        void UpdateBook(string title);
        List<Book> Load(string jsonFile);
        /*void RentBook(Book book);     
         void DeleteBook(string title);
         Book SearchForBook(string title = "", string author = "");
         void Save(List<Book> books, string filepath);*/
        //
    }
}
