using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Libary
{
    [Serializable]
    public class Book
    {
        private string? Title;
        public string? TitleB => Title;


        private int Year;
        public int YearB => Year;


        Author author;
        public Author AuthorB => author;

        public Book(string? Title, int Year, Author author)
        {
            this.Title = Title;
            this.Year = Year;
            this.author = author;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Название: {Title}");
            Console.WriteLine($"Год выпуска: {Year}");
            Console.WriteLine($"Автор: {author.NameA} {author.SurNameA}");
            Console.WriteLine(" ");
        }
    }

    [Serializable]
    public class Author
    {
        private string? Name;
        private string? Surname;

        public string? NameA => Name;
        public string? SurNameA => Surname;

        public Author(string? Name, string? Surname)
        {
            this.Name = Name;
            this.Surname = Surname;
        }
    }
}
