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
        public DateTime Year { get; set; }

        public string Summary { get; set; }
        private bool rent = false;
        public bool Rent
        {
            get { return rent; }
            set { rent = value; }
        }

        public override string ToString()
        {
            return "Title: " + Title + "\nAuthor: " + Author + "\nGenre: " + Genre + "\nPublication year: " + Year + "\nSummary: " + Summary;
        }

        public static bool IsValidateTitle(string title, List<Book> bookList)
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

        public static bool IsValidateAuthor(string author)
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
                ';', '\'', '<', '>', '_', ',', '*', '+'
            };

            if (author.IndexOfAny(specialChar) != -1)
            {
                validAuthor = false;
                Console.Write("Error: Name could not contain special characters!! Press Esc to cancel or any other key to try again . . . ");
            }

            return validAuthor;
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
