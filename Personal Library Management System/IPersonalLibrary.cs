using System;
using System.Collections.Generic;

namespace Personal_Library_Management_System
{
    public interface IPersonalLibrary
    {
        void AddBook(Book book, string jsonFile, string txtFile);
        void ViewAllBooks(string jsonFile);

        void UpdateBook(string title, string jsonFile, string txtFile);



        void DeleteBook(string title, string jsonFile, string txtFile);

        List<Book> SearchForBook(string jsonFile, string title = "", string author = "");

        void SaveInFiles(string jsonFile, string txtFile);
        List<Book> Load(string jsonFile);

        void RentBook(string title, string jsonFile, string txtFile);
        void ViewAllRentBooks(string jsonFile);

    }
}
