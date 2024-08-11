﻿using System;
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
                    Console.WriteLine("\nMenu:\n1-Add a Book\n2-View All Books\n3-Update book details\n4-Delete a book\n5-Search for a Book\n6-Exit");
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
                            int updateBook = 1;
                            string updateTitle = Book.GetBookTitle(updateBook);
                            personalLibrary.UpdateBook(updateTitle, jsonFile, txtFile);
                            Console.WriteLine("---------------------------------");
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
            string title = "", author = "", summary = "";
            int publicationYear, publicationMonth;
            Genre genre = default;

            Console.WriteLine("Enter book information:\n");

            //Get title
            int addBook = 0;
            title = Book.GetBookTitle(addBook);
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
            genre = Book.GetGenre();
            Console.WriteLine("------------");


            //Get date
            Console.WriteLine("Date of Publication:");

            //year
            publicationYear = Book.GetYear();

            //Month
            publicationMonth = Book.GetMonth();

            DateTime date = new DateTime(publicationYear, publicationMonth, 1);

            Console.WriteLine("------------");

            //Get summary
            summary = Book.GetSummary();

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





    }
}
