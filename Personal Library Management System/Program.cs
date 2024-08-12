using System;
using System.Collections.Generic;
using System.IO;


namespace Personal_Library_Management_System
{
    public class Program
    {
        public static Book bookObject = new Book();
        static void Main(string[] args)
        {
            try
            {
                string choice;
                Console.WriteLine("Welcome to your Personal Libaray");
                Console.WriteLine("---------------------------------");
                PersonalLibrary personalLibrary = new PersonalLibrary();

                string jsonFile = "Books.json";
                string txtFile = "Books.txt";
                personalLibrary.Load(jsonFile);
                do
                {
                    Console.WriteLine("a");
                    Console.WriteLine("Menu:\n1-Add a Book\n2-View All Books\n3-Update Book Details\n4-Delete a Book\n5-Search for a Book\n6-Rent a Book\n7-View All Rent Books\n8-Exit");
                    Console.Write("\nEnter your choice: ");
                    choice = Console.ReadLine();
                    int updateBook = 1;

                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("\n<<<-------- Add Book -------->>>\n");
                            Book book = personalLibrary.GetBookData(PersonalLibrary.Books);
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
                            string updateTitle = bookObject.GetBookTitle(updateBook);
                            personalLibrary.UpdateBook(updateTitle, jsonFile, txtFile);
                            Console.WriteLine("---------------------------------");
                            break;

                        case "4":
                            Console.WriteLine("\n<<<-------- Delete a Book -------->>>\n");
                            Console.WriteLine("Enter the title of the book you wish to delete: ");
                            string deleteTitle = bookObject.GetBookTitle(updateBook);
                            personalLibrary.DeleteBook(deleteTitle, jsonFile, txtFile);
                            Console.WriteLine("---------------------------------");
                            break;

                        case "5":
                            Console.WriteLine("\n<<<-------- Search for a Book -------->>>\n");
                            Console.WriteLine("Enter title or author or both of the book you are looking for\nPress Enter if you want to skip one of them\n");
                            personalLibrary.StartSearch(jsonFile);
                            Console.WriteLine("---------------------------------");

                            break;

                        case "6":
                            Console.WriteLine("\n<<<-------- Rent a Book -------->>>\n");
                            Console.WriteLine("Enter the title of the book you wish to Rent: ");
                            string rentTitle = bookObject.GetBookTitle(updateBook);
                            personalLibrary.RentBook(rentTitle, jsonFile, txtFile);
                            Console.WriteLine("---------------------------------");
                            break;

                        case "7":
                            Console.WriteLine("\n<<<-------- View All Rent Books -------->>>\n");
                            personalLibrary.ViewAllRentBooks(jsonFile);
                            Console.WriteLine("---------------------------------");
                            break;


                        case "8":
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



    }
}
