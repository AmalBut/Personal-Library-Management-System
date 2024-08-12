using System;
using System.Collections.Generic;



namespace Personal_Library_Management_System
{
    public enum Genre
    {
        Poetry,
        Fiction,
        Nonfiction,
        Drama,
        Prose,
        Other
    }
    public class Book
    {

        public string Title { get; set; }
        public string Author { get; set; }
        public Genre Genre { get; set; }
        public string Year { get; set; }

        private bool isRent = false;
        public bool IsRent
        {
            get { return isRent; }
            set { isRent = value; }
        }
        public string Summary { get; set; }


        public override string ToString()
        {
            return "Title: " + Title + "\nAuthor: " + Author + "\nGenre: " + Genre + "\nPublication year: " + Year + "\nRent: " + IsRent + "\nSummary: " + Summary + "\n";
        }

        private static bool IsValidTitle(string title, List<Book> bookList)
        {
            bool validBook = true;
            bool bookFound = false;

            validBook = IsEmptyInput(title);

            string addedTitleLower = title.ToLower();
            foreach (var bookItem in bookList)
            {
                string currentTitleLower = bookItem.Title.ToLower();
                if (currentTitleLower.Equals(addedTitleLower))
                {
                    bookFound = true;
                    validBook = false;
                    break;
                }
            }


            if (bookFound)
            {
                validBook = false;
                Console.Write("\nError: Book is already exist!! Press Esc to cancel or any other key to try again . . . ");
            }

            return validBook;
        }


        public static bool IsValidAuthor(string author, int forUpdate = 0)
        {
            bool validAuthor = true;


            validAuthor = IsEmptyInput(author);

            if (author.Length == 1)
            {
                validAuthor = false;

                if (forUpdate == 1)
                {
                    Console.WriteLine("Error: There is no name of 1 character !!");
                }
                else
                {
                    Console.Write("\nError: There is no name of 1 character !! Press Esc to cancel or any other key to try again . . . ");
                }

            }


            foreach (char character in author)
            {
                bool isLetterOrSpace = (character >= 'A' && character <= 'Z') || (character >= 'a' && character <= 'z') || character == ' ';

                if (!isLetterOrSpace)
                {
                    validAuthor = false;

                    if (forUpdate == 1)
                    {
                        Console.WriteLine("Error: Name could not contain special characters!! ");
                    }
                    else
                    {
                        Console.Write("\nError: Name could not contain special characters!! Press Esc to cancel or any other key to try again . . . ");
                    }
                    break;
                }
            }

            return validAuthor;

        }

        public static bool IsValidDate(string numString, bool isYear)
        {
            bool validNum = true;
            validNum = IsEmptyInput(numString);

            int dateNumber;
            bool isNumber = int.TryParse(numString, out dateNumber);
            int fartherYear = DateTime.Now.Year + 1;
            bool isPositive = dateNumber > 0;
            if (isYear)
            {

                if (numString.Length < 4 && isNumber && isPositive)
                {
                    Console.Write("Warning: This a very past year. Try again...");
                    validNum = false;
                    Console.WriteLine();

                }

                if (!isPositive)
                {
                    Console.WriteLine($"Error: There is no negative year");
                    validNum = false;
                }

                if (dateNumber > fartherYear)
                {
                    Console.WriteLine($"Error: Cannot accept a year farther than {fartherYear}");
                    validNum = false;
                }
            }
            else
            {
                if ((dateNumber < 1 || dateNumber > 12) && isNumber)
                {
                    Console.WriteLine("Error: Invalid month!!");
                    validNum = false;
                }

            }

            if (!isNumber)
            {
                Console.WriteLine("Invalid choice!! Not a number");
                validNum = false;
            }

            return validNum;
        }

        public static bool IsEmptyInput(string userInput)
        {
            bool validString = true;
            string trimInput = userInput.Trim();
            if (userInput.Equals("") || trimInput.Equals(""))
            {
                validString = false;
                Console.Write("\nError: Must enter a value!! Press Esc to cancel or any other key to try again . . . ");
            }

            return validString;
        }

        public static string GetBookTitle(int addOrUpdate)
        {
            bool isValidTitle = true;
            string title = null;
            int add = 0, update = 1;

            do
            {
                Console.Write("Title: ");
                title = Console.ReadLine();
                if (addOrUpdate == add)
                {
                    isValidTitle = IsValidTitle(title, PersonalLibrary.Books);
                }
                else if (addOrUpdate == update)
                {

                    isValidTitle = IsEmptyInput(title);
                }

                if (!isValidTitle)
                {

                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        return "";
                    }
                    Console.WriteLine("\n");
                }

            } while (!isValidTitle);

            return title;
        }

        public static string GetBookAuthor()
        {
            bool isValidAuthor = true;
            string author = null;
            do
            {
                Console.Write("Author: ");
                author = Console.ReadLine();
                isValidAuthor = IsValidAuthor(author);

                if (!isValidAuthor)
                {
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        return null;
                    }
                    Console.WriteLine("\n");
                }

            } while (!isValidAuthor);

            return author;
        }

        public static Genre GetGenre(int forUpdate = 0)
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

            if (genreChoice.Equals("") && forUpdate == 1)
            {
                return genre;
            }

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

        public static int GetYear()
        {
            bool validYear = true;
            bool isYear = true;
            string stringYear = "";
            int publicationYear;
            do
            {
                Console.Write("Year: ");
                stringYear = Console.ReadLine();
                validYear = IsValidDate(stringYear, isYear);
            } while (!validYear);

            publicationYear = Int32.Parse(stringYear);

            return publicationYear;
        }


        public static int GetMonth()
        {
            bool validMonth = true;
            bool isYear = false;
            string stringMonth;
            int publicationMonth;
            do
            {
                Console.Write("Month: ");
                stringMonth = Console.ReadLine();
                validMonth = IsValidDate(stringMonth, isYear);
            } while (!validMonth);

            publicationMonth = Int32.Parse(stringMonth);
            return publicationMonth;
        }

        public static string GetSummary()
        {
            string hasSummary;  // "y" or "n"
            string summary = "";
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

            return summary;
        }

        public static bool GetRent(int forUpdate = 0)
        {
            bool rent = false;
            string stringRent = "";
            do
            {

                Console.Write("Rent: (y/n) ");

                stringRent = Console.ReadLine();

                if (stringRent.ToLower().Equals("y"))
                {
                    rent = true;
                }
                else if (stringRent.ToLower().Equals("n"))
                {
                    rent = false;
                }
                else
                {
                    Console.Write("Invalid input!! Enter (y/n): ");
                }

            } while (!stringRent.ToLower().Equals("y") && !stringRent.ToLower().Equals("n"));

            return rent;
        }



    }

}
