using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;


namespace Personal_Library_Management_System
{

    public class PersonalLibrary : IPersonalLibrary
    {
        public List<Book> Books { set; get; }


        public void AddBook(Book book, string jsonFile, string txtFile)
        {

            if (book != null)
            {

                try
                {
                    Books = Load(jsonFile);
                    Books.Add(book);
                    var options = new JsonSerializerOptions();
                    options.WriteIndented = true;

                    string updatedJsonBooks = JsonSerializer.Serialize<List<Book>>(Books, options);

                    File.WriteAllText(jsonFile, updatedJsonBooks);

                    File.WriteAllText(txtFile, updatedJsonBooks);


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

        public void ViewAllBooks()
        {

            foreach (var book in Books)
            {
                Console.WriteLine(book.ToString());
                Console.WriteLine("<<<<<<<<<<>>>>>>>>>>>");
            }

        }

        public List<Book> Load(string filepath)
        {
            var bookJson = File.ReadAllText(filepath);

            Books = JsonSerializer.Deserialize<List<Book>>(bookJson);
            return Books;
        }

    }
}
