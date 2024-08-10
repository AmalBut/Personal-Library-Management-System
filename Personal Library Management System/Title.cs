using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Library_Management_System
{
    public class Title
    {

        public static bool ValidateTitle(string title, List<Book> bookList)
        {
            bool validBook = true;
            bool bookFound = false;
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

            string trimTitle = title.Trim();
            if (title.Equals("") || trimTitle.Equals(""))
            {
                validBook = false;
                Console.Write("Must enter a title !! Press Esc to cancel or any other key to try again . . . ");
            }

            if (bookFound)
            {
                validBook = false;
                Console.Write("Book is already exist!! Press Esc to cancel or any other key to try again . . . ");
            }

            return validBook;
        }
    }
}
