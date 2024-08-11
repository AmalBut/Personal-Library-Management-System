using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private bool rent = false;
        public bool Rent
        {
            get { return rent; }
            set { rent = value; }
        }
        public string Summary { get; set; }


        public override string ToString()
        {
            return "Title: " + Title + "\nAuthor: " + Author + "\nGenre: " + Genre + "\nPublication year: " + Year + "\nRent: " + Rent + "\nSummary: " + Summary + "\n";
        }

        public static bool IsValidTitle(string title, List<Book> bookList)
        {
            bool validBook = true;
            bool bookFound = false;

            validBook = IsEmptyString(title);

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
                Console.Write("Error: Book is already exist!! Press Esc to cancel or any other key to try again . . . ");
            }

            return validBook;
        }

        public static bool IsValidAuthor(string author)
        {
            bool validAuthor = true;


            validAuthor = IsEmptyString(author);

            if (author.Length == 1)
            {
                validAuthor = false;
                Console.Write("Error: There is no name of 1 character !! Press Esc to cancel or any other key to try again . . . ");
            }

            char[] specialChar = {
                '\\', '|', '!', '#', '$', '%', '&', '/', '(', ')',
                '=', '?', '»', '«', '@', '£', '§', '€', '{', '}',
                ';', '\'', '<', '>', ',', '*', '+'
            };

            if (author.IndexOfAny(specialChar) != -1)
            {
                validAuthor = false;
                Console.Write("Error: Name could not contain special characters!! Press Esc to cancel or any other key to try again . . . ");
            }

            return validAuthor;
        }

        public static bool IsValidDate(string numString, bool isYear)
        {
            bool validNum = true;
            validNum = IsEmptyString(numString);

            int dateNumber;
            bool isNumber = int.TryParse(numString, out dateNumber);
            int fartherYear = DateTime.Now.Year + 1;
            bool isPositive = dateNumber > 0;
            if (isYear)
            {

                if (numString.Length < 4 && isNumber && isPositive)
                {
                    Console.Write("Warning: This a very past year. If you want to modify it press Esc, or press any key to continue . . . ");

                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        validNum = false;
                    }
                    else
                    {
                        validNum = true;
                    }
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

        public static bool IsEmptyString(string userInput)
        {
            bool validString = true;
            string trimInput = userInput.Trim();
            if (userInput.Equals("") || trimInput.Equals(""))
            {
                validString = false;
                Console.Write("Error: Must enter a value!! Press Esc to cancel or any other key to try again . . . ");
            }

            return validString;
        }



    }

}
