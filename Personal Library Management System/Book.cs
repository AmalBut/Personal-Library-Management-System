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
    }

}
