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
            List<Book> bookList = Load(jsonFile);
            bool bookFound = false;
            string oldBook = "";
            string modifiedBook = "";
            foreach (var book in bookList)
            {
                if (book.Title.Equals(title))
                {
                    oldBook = book.ToString();
                    Console.WriteLine("----------------------");
                    Console.WriteLine("Enter new book information:\nPress enter if you want to skip any field");

                    UpdateTitle(book, bookList);

                    Console.WriteLine("------------");

                    UpdateAuthor(book);

                    Console.WriteLine("------------");

                    Console.WriteLine("Enter genre:");
                    int forUpdate = 1;
                    Genre newGenre = Book.GetGenre(forUpdate);

                    if (!newGenre.Equals(default))
                    {
                        book.Genre = newGenre;
                    }


                    Console.WriteLine("------------");

                    int newYear = Book.GetYear();

                    Console.WriteLine("------------");

                    int newMonth = Book.GetMonth();

                    DateTime date = new DateTime(newYear, newMonth, 1);
                    book.Year = date.Year + "-" + date.Month;

                    Console.WriteLine("------------");

                    bool newRent = Book.GetRent(forUpdate);


                    Console.WriteLine("------------");


                    Console.WriteLine("Enter summary:");
                    string summaryToUpdate = Console.ReadLine();
                    if (!summaryToUpdate.Equals(""))
                    {
                        book.Summary = Book.GetSummary();
                    }

                    Console.WriteLine("------------");
                    modifiedBook = book.ToString();

                    bookFound = true;
                    break;
                }
            }


            if (bookFound)
            {
                string save = "";
                Console.Write("Do you want to save changes ? (y/n): ");
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
                        Console.WriteLine("Sorry! No modification was done");
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

            }
        }


        public void DeleteBook(string title, string jsonFile, string txtFile)
        {
            List<Book> bookList = Load(jsonFile);
            bool bookFound = false;

            foreach (var book in bookList)
            {
                if (book.Title.Equals(title))
                {

                    bookList.Remove(book);
                    bookFound = true;
                    break;
                }
            }


            if (bookFound)
            {
                string save = "";
                Console.Write("Do you want to save changes ? (y/n): ");
                do
                {
                    save = Console.ReadLine();
                    if (save.ToLower().Equals("y"))
                    {
                        Books = bookList;
                        SaveInFiles(jsonFile, txtFile);
                        Console.WriteLine($"Book {title} was deleted successfully");

                    }
                    else if (save.ToLower().Equals("n"))
                    {
                        Console.WriteLine("Sorry! No deletion was done");
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
                Console.WriteLine("Sorry! Book not found to be deleted.");

            }
        }

        public void RentBook(string title, string jsonFile, string txtFile)
        {
            List<Book> bookList = Load(jsonFile);
            bool bookFound = false;

            foreach (var book in bookList)
            {
                if (book.Title.Equals(title) && !book.IsRent)
                {

                    book.IsRent = true;
                    bookFound = true;
                    break;
                }
            }

            if (bookFound)
            {
                string save = "";
                Console.Write("Do you want to ensure renting ? (y/n): ");
                do
                {
                    save = Console.ReadLine();
                    if (save.ToLower().Equals("y"))
                    {
                        Books = bookList;
                        SaveInFiles(jsonFile, txtFile);
                        Console.WriteLine($"Book {title} was Rent successfully");

                    }
                    else if (save.ToLower().Equals("n"))
                    {
                        Console.WriteLine("Sorry! No Rent was done");
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
                Console.WriteLine("Sorry! Book not found to be deleted.");

            }

        }

        public void ViewAllRentBooks(string jsonFile)
        {
            Books = Load(jsonFile);
            List<Book> rentList = new List<Book>();
            bool rentFound = false;
            foreach (var book in Books)
            {
                if (book.IsRent)
                {
                    Console.WriteLine(book.ToString());
                    Console.WriteLine("<<<<<<<<<<>>>>>>>>>>>");
                    rentFound = true;
                }
            }

            if (!rentFound)
            {
                Console.WriteLine("No Rent books to view");
            }
        }

        public List<Book> SearchForBook(string jsonFile, string title = "", string author = "")
        {
            List<Book> bookList = Load(jsonFile);
            //   Book searchedBook = null;
            List<Book> searchedBookList = new List<Book>();
            bool emptyTitle = title.Equals("");
            bool emptyAuthor = author.Equals("");

            foreach (var book in bookList)
            {
                bool isAuthorSubstring = book.Author.Contains(author);
                bool isTitleSubstring = book.Title.Contains(title);

                if (isTitleSubstring && emptyAuthor && !emptyTitle)
                {
                    searchedBookList.Add(book);

                }
                else if (isAuthorSubstring && !emptyAuthor && emptyTitle)
                {
                    searchedBookList.Add(book);
                }
                else if (isTitleSubstring && isAuthorSubstring && !emptyTitle && !emptyAuthor)
                {
                    searchedBookList.Add(book);

                }
            }
            return searchedBookList;
        }

        public void StartSearch(string jsonFile)
        {
            string searchTitle = "", searchAuthor = "";
            do
            {
                Console.Write("Title: ");
                searchTitle = Console.ReadLine();
                Console.WriteLine("------------");
                Console.Write("Author: ");
                searchAuthor = Console.ReadLine();
                Console.WriteLine("------------");

                if (searchTitle.Equals("") && searchAuthor.Equals(""))
                {
                    Console.WriteLine("Error: At least one field must be entered. Try Again\n");
                }
            } while (searchTitle.Equals("") && searchAuthor.Equals(""));


            List<Book> searchedBooks = SearchForBook(jsonFile, searchTitle, searchAuthor);
            if (searchedBooks.Count == 0)
            {
                Console.WriteLine("Book not found");
            }
            else
            {
                Console.WriteLine("The book/s found:\n");
                foreach (var foundBook in searchedBooks)
                {
                    Console.WriteLine("Title: " + foundBook.Title + "\nAuthor: " + foundBook.Author + "\nGenre: " + foundBook.Genre + "\nPublication year: " + foundBook.Year + "\nSummary: " + foundBook.Summary);
                    Console.WriteLine("<<<<<<<<<<>>>>>>>>>>>");
                }
            }
        }

        private bool CanUpdateTitle(string titleToUpdate, List<Book> bookList)
        {
            bool canUpdate = true;
            bool bookFound = false;

            string TitleLower = titleToUpdate.ToLower();
            foreach (var bookItem in bookList)
            {
                string currentTitleLower = bookItem.Title.ToLower();
                if (currentTitleLower.Equals(TitleLower))
                {
                    bookFound = true;
                    canUpdate = false;
                    break;
                }
            }


            if (bookFound)
            {
                bookFound = false;
                Console.Write("Error: Book is already exist!! Try again . . . ");
            }
            return canUpdate;

        }



        private void UpdateTitle(Book book, List<Book> bookList)
        {
            bool isValidTitle = true;

            do
            {
                Console.WriteLine("\nEnter title: ");
                string titleToUpdate = Console.ReadLine();
                if (!titleToUpdate.Equals(""))
                {
                    if (!book.Title.Equals(titleToUpdate))
                    {
                        isValidTitle = CanUpdateTitle(titleToUpdate, bookList);

                    }
                    if (isValidTitle)
                    {
                        book.Title = titleToUpdate;
                    }
                }

            } while (!isValidTitle);

        }

        private void UpdateAuthor(Book book)
        {
            bool isValidTitle = true;
            int forUpdate = 1;
            do
            {
                Console.WriteLine("\nEnter author: ");
                string authorToUpdate = Console.ReadLine();
                if (!authorToUpdate.Equals(""))
                {
                    isValidTitle = Book.IsValidAuthor(authorToUpdate, forUpdate);

                    if (isValidTitle)
                    {
                        book.Title = authorToUpdate;
                    }
                }

            } while (!isValidTitle);

        }



        public List<Book> Load(string jsonFile)
        {
            if (!File.Exists(jsonFile))
            {
                throw new FileNotFoundException("File Not Found");
            }
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
