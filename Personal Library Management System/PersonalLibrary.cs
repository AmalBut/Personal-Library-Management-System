using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Xml.Linq;


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
                    SaveInFiles(jsonFile, txtFile);

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

        public void UpdateBook(string title, string jsonFile, string txtFile)
        {
            List<Book> bookList = Books;
            bool bookFound = false;
            string oldBook = "";
            string modifiedBook = "";
            //bool validTitle = true;
            foreach (var book in bookList)
            {
                if (book.Title == title)
                {
                    oldBook = book.ToString();
                    Console.WriteLine("----------------------");
                    Console.WriteLine("Enter new book information: ");
                    int addBook = 0;
                    book.Title = Book.GetBookTitle(addBook);
                    Console.WriteLine("------------");
                    book.Author = Book.GetBookAuthor();
                    Console.WriteLine("------------");
                    book.Genre = Book.GetGenre();
                    Console.WriteLine("------------");
                    int newYear = Book.GetYear();
                    Console.WriteLine("------------");
                    int newMonth = Book.GetMonth();
                    DateTime date = new DateTime(newYear, newMonth, 1);
                    book.Year = date.Year + "-" + date.Month;
                    Console.WriteLine("------------");
                    book.Rent = Book.GetRent();
                    Console.WriteLine("------------");
                    book.Summary = Book.GetSummary();
                    Console.WriteLine("------------");
                    modifiedBook = book.ToString();

                    bookFound = true;
                    break;
                }
            }


            if (bookFound)
            {
                string save = "";
                Console.WriteLine("Do you want to save changes ? (y/n)");
                do
                {
                    save = Console.ReadLine();
                    if (save.ToLower().Equals("y"))
                    {
                        Books = bookList;
                        SaveInFiles(jsonFile, txtFile);
                        Console.WriteLine("<<<<<<<<<<>>>>>>>>>>>");
                        Console.WriteLine("Book Before Update:\n" + oldBook);
                        Console.WriteLine("<<<<<<<<<<>>>>>>>>>>>");
                        Console.WriteLine("Book After Update:\n" + modifiedBook);

                    }
                    else if (save.ToLower().Equals("n"))
                    {
                        Console.WriteLine("Sorry! No modification done");
                        Console.WriteLine("---------------------------------");
                        break;
                    }
                    else
                    {
                        Console.Write("Invalid input!! Enter (y/n): ");
                    }

                } while (!save.ToLower().Equals("y") && !save.ToLower().Equals("n"));

            }
            else
            {
                Console.WriteLine("Sorry! Book not found to be modified.");
                Console.WriteLine("---------------------------------");

            }



        }
        public List<Book> Load(string jsonFile)
        {
            var bookJson = File.ReadAllText(jsonFile);

            Books = JsonSerializer.Deserialize<List<Book>>(bookJson);
            return Books;
        }

        public void SaveInFiles(string jsonFile, string txtFile)
        {
            var options = new JsonSerializerOptions();
            options.WriteIndented = true;

            string updatedJsonBooks = JsonSerializer.Serialize<List<Book>>(Books, options);

            File.WriteAllText(jsonFile, updatedJsonBooks);

            File.WriteAllText(txtFile, updatedJsonBooks);
        }

    }
}
