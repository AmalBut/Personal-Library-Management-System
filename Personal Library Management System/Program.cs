using System;
using System.Collections.Generic;
using System.IO;


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
                PersonalLibrary personalLibrary = new PersonalLibrary();
                string jsonFile = "C:\\Users\\Microsoft\\OneDrive\\سطح المكتب\\Library\\Personal-Library-Management-System\\Personal Library Management System\\Personal Library Management System\\Books.json";
                string txtFile = "C:\\Users\\Microsoft\\OneDrive\\سطح المكتب\\Library\\Personal-Library-Management-System\\Personal Library Management System\\Personal Library Management System\\Books.txt";
                personalLibrary.Load(jsonFile);
                do
                {
                    Console.WriteLine("Menu:\n1-Add a Book\n2-View All Books\n3-Update book details\n4-Delete a book\n5-Search for a Book\n6-Exit");
                    Console.Write("\nEnter your choice: ");
                    choice = Console.ReadLine();


                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("\n<<<-------- Add Book -------->>>\n");
                            Book book = GetBookData(PersonalLibrary.Books);
                            personalLibrary.AddBook(book, jsonFile, txtFile);
                            Console.WriteLine("---------------------------------");
                            break;

                        case "2":
                            Console.WriteLine("\n<<<-------- View All Books -------->>>\n");
                            personalLibrary.ViewAllBooks(jsonFile);
                            break;

                        case "3":
                            Console.WriteLine("\n<<<-------- Update Book Details -------->>>\n");
                            Console.WriteLine("Enter the title of the book you wish to update: ");
                            string updateTiltle = Book.GetBookTitle();
                            personalLibrary.UpdateBook(updateTiltle);
                            break;

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
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        static Book GetBookData(List<Book> bookList)
        {
            string title = "", author = "", summary = "", stringYear = "", stringMonth = "";
            int publicationYear, publicationMonth;
            string hasSummary;
            Genre genre = default;

            Console.WriteLine("Enter book information:\n");

            //Get title
            title = Book.GetBookTitle();
            if (title == null)
            {
                return null;
            }
            Console.WriteLine("------------");

            //Get author
            author = Book.GetBookAuthor();
            if (author == null)
            {
                return null;
            }
            Console.WriteLine("------------");


            //Get genre
            Console.Write("Genre:\n");
            genre = ChooseGenre();
            Console.WriteLine("------------");


            //Get date
            Console.WriteLine("Date of Publication:");

            //year
            bool validYear = true;
            bool isYear = true;

            do
            {
                Console.Write("Year: ");
                stringYear = Console.ReadLine();
                validYear = Book.IsValidDate(stringYear, isYear);
                Console.WriteLine();
            } while (!validYear);

            publicationYear = Int32.Parse(stringYear);

            //Month
            bool validMonth = true;
            isYear = false;

            do
            {
                Console.WriteLine();
                Console.Write("Month: ");
                stringMonth = Console.ReadLine();
                validMonth = Book.IsValidDate(stringMonth, isYear);
            } while (!validMonth);

            publicationMonth = Int32.Parse(stringMonth);

            DateTime date = new DateTime(publicationYear, publicationMonth, 1);

            Console.WriteLine("------------");

            //Get summary
            Console.Write("Do you want to add a summary? (y/n): ");

            do
            {
                hasSummary = Console.ReadLine();
                if (hasSummary.ToLower().Equals("y"))
                {
                    Console.Write("\nSummary: ");
                    summary = Console.ReadLine();
                }
                else if (hasSummary.ToLower().Equals("n"))
                {
                    break;
                }
                else
                {
                    Console.Write("Invalid input!! Enter (y/n): ");
                }

            } while (!hasSummary.ToLower().Equals("y") && !hasSummary.ToLower().Equals("n"));

            //Create a book object
            Book book = new Book()
            {
                Title = title,
                Author = author,
                Genre = genre,
                Year = date.Year + "-" + date.Month,
                Summary = summary
            };

            return book;
        }

        static Genre ChooseGenre()
        {
            int numOfGenres = 0;
            string genreChoice;
            Genre genre = default;

            //Display genre options
            foreach (var item in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{(int)item + 1}-{item}");
                numOfGenres++;
            }

            //Get user choice
            Console.Write("\nChoose a genre by its number: ");
            genreChoice = Console.ReadLine();
            int genreNumber;
            bool isNumber = int.TryParse(genreChoice, out genreNumber);

            //Validate the user choice
            while (genreNumber < 1 || genreNumber > numOfGenres || !isNumber)
            {
                Console.Write("\nInvalid choice!! Enter another choice: ");
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
            Console.WriteLine(genre);
            return genre;
        }



    }
}
