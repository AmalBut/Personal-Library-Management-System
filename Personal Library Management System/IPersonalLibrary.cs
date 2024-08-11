using System;
using System.Collections.Generic;

namespace Personal_Library_Management_System
{
    public interface IPersonalLibrary
    {
        void AddBook(Book book, string jsonFile, string txtFile);
        void ViewAllBooks(string jsonFile);

        void UpdateBook(string title, string jsonFile, string txtFile);

        void SaveInFiles(string jsonFile, string txtFile);

        void DeleteBook(string title, string jsonFile, string txtFile);
        List<Book> Load(string jsonFile);
        /*void RentBook(Book book);     
        
         Book SearchForBook(string title = "", string author = "");
         */
        //
    }
}
