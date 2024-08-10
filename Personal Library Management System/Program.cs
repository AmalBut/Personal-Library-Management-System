using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Library_Management_System
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string choice;
                Console.WriteLine("Welcome to your Personal Libaray");
                Console.WriteLine("---------------------------------");
                PersonalLibrary pl = new PersonalLibrary();
                string jsonFile = "D:\\Jaffal\\Stage 2\\csharp\\Personal Library Management System\\Personal Library Management System\\Books.json";

                pl.Load(jsonFile);
                do
                {
                    Console.WriteLine("Menu:\n1-Add a Book\n2-View All Books\n3-Update a Book\n4-Delete a book\n5-Search for a Book\n6-Exit");
                    Console.Write("\nEnter your choice: ");
                    choice = Console.ReadLine();


                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("\n<<<-------- Add Book -------->>>\n");
                            Book book = GetBookData(pl.Books);
                            pl.AddBook(book, jsonFile);
                            break;

                        case "2": break;
                        case "3": break;
                        case "4": break;
                        case "5": break;
                        case "6":
                            Console.WriteLine("Thank you for using Personal Library. Have a great day and happy reading :) ");
                            System.Environment.Exit(0); break;

                        default:
                            Console.WriteLine("Invalid choice !!... Try Again");
                            Console.WriteLine("---------------------------------");
                            break;
                    }

                } while (true);

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }

        }

        public static Book GetBookData(List<Book> bookList)
        {
            string title = "", author = "", summary = "";
            int publicationYear, publicationMonth;
            string hasSummary;
            Genre genre = default;

            Console.WriteLine("Enter book information:\n");

            bool validBook = true;
            bool esc = false;
            do
            {
                Console.Write("Title: ");
                title = Console.ReadLine();
                validBook = Book.IsValidateTitle(title, bookList);
                if (!validBook)
                {

                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        esc = true;
                        break;
                    }
                    Console.WriteLine("\n");
                }

            } while (!validBook);

            if (esc)
            {
                return null;
            }


            /////////////////////////////////

            bool validAuthor = true;
            esc = false;
            do
            {
                Console.Write("Author: ");
                author = Console.ReadLine();
                validAuthor = Book.IsValidateAuthor(author);
                if (!validAuthor)
                {

                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        esc = true;
                        break;
                    }
                    Console.WriteLine("\n");
                }

            } while (!validAuthor);

            if (esc)
            {
                return null;
            }


            /////////////////////////////////
            Console.Write("Genre:\n");
            genre = ChooseGenre();

            //////////////////////////////////

            Console.Write("Year of Publication: ");

            publicationYear = Int32.Parse(Console.ReadLine());
            publicationMonth = Int32.Parse(Console.ReadLine());
            int fartherYear = DateTime.Now.Year + 1;
            if (publicationYear > fartherYear)
            {
                Console.WriteLine($"Error: Cannot enter a year further than {fartherYear}");
                publicationYear = Int32.Parse(Console.ReadLine());
            }

            DateTime date = new DateTime(publicationYear, publicationMonth, 1);

            //string dateFormat = "yyyy-MM";
            //Console.WriteLine(d.ToString(dateFormat));

            Console.Write("\nDo you want to add a summary? (y/n)");
            hasSummary = Console.ReadLine();

            if (hasSummary.ToLower().Equals("y"))
            {
                Console.Write("\nSummary: ");
                summary = Console.ReadLine();
            }

            Book book = new Book()
            {
                Title = title,
                Author = author,
                Genre = genre,
                Year = date,
                Summary = summary
            };


            return book;
        }

        public static Genre ChooseGenre()
        {
            int numOfGenres = 0;
            string genreChoice;
            Genre genre = default;

            foreach (var item in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{(int)item + 1}-{item}");
                numOfGenres++;
            }

            genreChoice = Console.ReadLine();
            int genreNumber;
            bool isNumber = int.TryParse(genreChoice, out genreNumber);

            while (genreNumber < 1 || genreNumber > numOfGenres || !isNumber)
            {
                Console.WriteLine("Invalid choices!! try again");
                genreChoice = Console.ReadLine();
                isNumber = int.TryParse(genreChoice, out genreNumber);
            }

            foreach (var item in Enum.GetValues(typeof(Genre)))
            {
                if ((int)item + 1 == Int32.Parse(genreChoice))
                {
                    genre = (Genre)item;
                    break;
                }
            }
            return genre;
        }


    }
}
