using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;


namespace Personal_Library_Management_System
{

    public class PersonalLibrary : IPersonalLibrary
    {
        public static List<Book> Books { set; get; }


        public void AddBook(Book book, string jsonFile, string txtFile)
        {

            if (book != null)
            {

                try
                {
                    Books = Load(jsonFile);
                    Books.Add(book);
                    var options = new JsonSerializerOptions();
                    options.WriteIndented = true;

                    string updatedJsonBooks = JsonSerializer.Serialize<List<Book>>(Books, options);

                    File.WriteAllText(jsonFile, updatedJsonBooks);

                    File.WriteAllText(txtFile, updatedJsonBooks);


                }
                catch (FileNotFoundException notFound)
                {
                    Console.WriteLine("Text File not found");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void ViewAllBooks(string jsonFile)
        {
            List<Book> bookList = new List<Book>();
            bookList = Load(jsonFile);
            foreach (var book in bookList)
            {
                Console.WriteLine(book.ToString());
                Console.WriteLine("<<<<<<<<<<>>>>>>>>>>>");
            }
        }

        public void UpdateBook(string title)
        {
            List<Book> bookList = Books;
            bool bookFound = false;
            //bool validTitle = true;
            foreach (var book in bookList)
            {
                if (book.Title == title)
                {
                    Console.WriteLine("New title: ");
                    string newTitle = Book.GetBookTitle();
                    Console.WriteLine("New author: ");
                    Book.GetBookAuthor();
                    Console.WriteLine("New year: ");
                    Console.WriteLine("New rent: ");
                    Console.WriteLine("New summary: ");
                    bookFound = true;
                    break;
                }

            }

        }
        public List<Book> Load(string jsonFile)
        {
            var bookJson = File.ReadAllText(jsonFile);

            Books = JsonSerializer.Deserialize<List<Book>>(bookJson);
            return Books;
        }

    }
}
