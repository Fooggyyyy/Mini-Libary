using System;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;

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
}

[Serializable]
public class Author
{
    private string? Name;
    private string? Surname;
    public string NameA => Name;
    public string SurNameA => Surname;
    public Author(string? Name, string? Surname)
    {
        this.Name = Name;
        this.Surname = Surname;
    }
}

[Serializable]
public class Libary 
{
    private List<Book> books;
    static int OneObj = 0;
    public Libary()
    {
        OneObj++;
        books = new List<Book>();
        if (OneObj != 1)
            throw new Exception("Только один экзампляр класса!!!");
    }
    public void Add(Book book)
    {
        books.Add(book);
    }

    public void AddMore(Book[] book)
    {
        for(int i = 0; i < book.Length; i++) 
            Add(book[i]);
    }
    public void Clear()
    {
        books.Clear();
    }
    public void Remove(Book book)
    {
        books.Remove(book);
    }
    public List<Book> GetBooks()
    {
        return books;
    }

    public List<Book> GetBookOnYear(int year)
    {
        JArray books = JArray.Parse(File.ReadAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json"));

        var BooksYear = books.Where(b => (int)b["YearB"] == year)
            .Select(b => new Book(
                               (string?)b["TitleB"],
                               (int)b["YearB"],
                               new Author(
                                   (string?)b["AuthorB"]["NameA"],
                                   (string?)b["AuthorB"]["SurNameA"]
                               )
                           ))
                           .Distinct(new BookComparer())
                           .ToList();
        return BooksYear;
    }

    public List<Book> GetBookOnAuthor(Author author)
    {
        JArray books = JArray.Parse(File.ReadAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json"));

        var BooksAuthor = books.Where(b => (string)b["AuthorB"]["NameA"] == author.NameA
                                           && (string)b["AuthorB"]["SurNameA"] == author.SurNameA)
                               .Select(b => new Book(
                                   (string?)b["TitleB"],
                                   (int)b["YearB"],
                                   new Author(
                                       (string?)b["AuthorB"]["NameA"],
                                       (string?)b["AuthorB"]["SurNameA"]
                                   )
                               ))
                               .Distinct(new BookComparer())
                               .ToList();
        return BooksAuthor;
    }

    public List<Book> GetBookOnTitle(string title)
    {
        JArray books = JArray.Parse(File.ReadAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json"));

        var BooksTitle = books.Where(b => (string)b["TitleB"] == title)
                              .Select(b => new Book(
                                   (string?)b["TitleB"],
                                   (int)b["YearB"],
                                   new Author(
                                       (string?)b["AuthorB"]["NameA"],
                                       (string?)b["AuthorB"]["SurNameA"]
                                   )
                               ))
                              .Distinct(new BookComparer())
                               .ToList();

        return BooksTitle;
    }

    public List<Book> GetBookOnAuthorSurname(string surname)
    {
        JArray books = JArray.Parse(File.ReadAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json"));

        var BooksSurname = books.Where(b => (string)b["AuthorB"]["SurNameA"] == surname)
                                .Select(b => new Book(
                                    (string?)b["TitleB"],
                                    (int)b["YearB"],
                                    new Author(
                                        (string?)b["AuthorB"]["NameA"],
                                        (string?)b["AuthorB"]["SurNameA"]
                                    )
                                ))
                                .Distinct(new BookComparer())
                                .ToList();

        return BooksSurname;
    }

    public List<Book> GetBookOnYearRange(int startYear, int endYear)
    {
        JArray books = JArray.Parse(File.ReadAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json"));

        var BooksRange = books.Where(b => (int)b["YearB"] >= startYear && (int)b["YearB"] <= endYear)
                              .Select(b => new Book(
                                   (string?)b["TitleB"],
                                   (int)b["YearB"],
                                   new Author(
                                       (string?)b["AuthorB"]["NameA"],
                                       (string?)b["AuthorB"]["SurNameA"]
                                   )
                               ))
                              .Distinct(new BookComparer())
                              .ToList();

        return BooksRange;
    }

    public List<Book> GetBookOnAuthorAndYear(Author author, int year)
    {
        JArray books = JArray.Parse(File.ReadAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json"));

        var BooksAuthorAndYear = books.Where(b => (string)b["AuthorB"]["NameA"] == author.NameA
                                                 && (string)b["AuthorB"]["SurNameA"] == author.SurNameA
                                                 && (int)b["YearB"] == year)
                                      .Select(b => new Book(
                                           (string?)b["TitleB"],
                                           (int)b["YearB"],
                                           new Author(
                                               (string?)b["AuthorB"]["NameA"],
                                               (string?)b["AuthorB"]["SurNameA"]
                                           )
                                       ))
                                      .Distinct(new BookComparer())
                                      .ToList();

        return BooksAuthorAndYear;
    }

}
public class BookComparer : IEqualityComparer<Book>
{
    public bool Equals(Book x, Book y)
    {
        if (x == null || y == null) return false;

        return x.TitleB == y.TitleB && x.YearB == y.YearB && x.AuthorB.NameA == y.AuthorB.NameA
            && x.AuthorB.SurNameA == y.AuthorB.SurNameA;
    }

    public int GetHashCode(Book obj)
    {
        if (obj == null) return 0;

        int hashTitle = obj.TitleB == null ? 0 : obj.TitleB.GetHashCode();
        int hashYear = obj.YearB.GetHashCode();
        int hashAuthorName = obj.AuthorB.NameA == null ? 0 : obj.AuthorB.NameA.GetHashCode();
        int hashAuthorSurname = obj.AuthorB.SurNameA == null ? 0 : obj.AuthorB.SurNameA.GetHashCode();

        return hashTitle ^ hashYear ^ hashAuthorName ^ hashAuthorSurname;
    }
}
public class Reader
{
    private string Name;
}
public static class Programm
{   
    public static void PrintList(List<Book> books)
    {
        foreach (Book book in books)
        {
            Console.WriteLine($"Название книги: {book.TitleB}");
            Console.WriteLine($"Год выпуска: {book.YearB}");
            Console.WriteLine($"Автор: {book.AuthorB.NameA} {book.AuthorB.SurNameA}");
            Console.WriteLine("");
        }
    }
    public static void Main(string[] args)
    {
        Libary libary = new Libary();

        Author Dostoevsky = new Author("Федор", "Достоевский");
        Author Pushkin = new Author("Александр", "Пушкин");
        Author Gogol = new Author("Николай", "Гоголь");
        Author Tolstoy = new Author("Лев", "Толстой");
        Author Turgenev = new Author("Иван", "Тургенев");
        Author Chekhov = new Author("Антон", "Чехов");
        Author Mayakovsky = new Author("Владимир", "Маяковский");
        Author Herzen = new Author("Александр", "Герцен");
        Author Goncharov = new Author("Иван", "Гончаров");
        Author Lermontov = new Author("Михаил", "Лермонтов");
        Author Blok = new Author("Александр", "Блок");
        Author Pasternak = new Author("Борис", "Пастернак");
        Author Akhmatova = new Author("Анна", "Ахматова");
        Author Nekrasov = new Author("Николай", "Некрасов");
        Author Solzhenitsyn = new Author("Александр", "Солженицын");
        Author Bulgakov = new Author("Михаил", "Булгаков");

        // Создание книг
        Book[] books = new Book[]
        {
            new Book("Идиот", 1869, Dostoevsky),
            new Book("Идиот", 1869, Dostoevsky),
            new Book("Идиот", 1869, Dostoevsky),
            new Book("Идиот", 1869, Dostoevsky),
            new Book("Идиот", 1869, Dostoevsky),
            new Book("Преступление и наказание", 1866, Dostoevsky),
            new Book("Преступление и наказание", 1866, Dostoevsky),
            new Book("Преступление и наказание", 1866, Dostoevsky),
            new Book("Преступление и наказание", 1866, Dostoevsky),
            new Book("Преступление и наказание", 1866, Dostoevsky),

            new Book("Евгений Онегин", 1833, Pushkin),
            new Book("Евгений Онегин", 1833, Pushkin),
            new Book("Евгений Онегин", 1833, Pushkin),
            new Book("Евгений Онегин", 1833, Pushkin),
            new Book("Евгений Онегин", 1833, Pushkin),
            new Book("Медный всадник", 1837, Pushkin),
            new Book("Медный всадник", 1837, Pushkin),
            new Book("Медный всадник", 1837, Pushkin),
            new Book("Медный всадник", 1837, Pushkin),
            new Book("Медный всадник", 1837, Pushkin),

            new Book("Мертвые души", 1842, Gogol),
            new Book("Мертвые души", 1842, Gogol),
            new Book("Мертвые души", 1842, Gogol),
            new Book("Мертвые души", 1842, Gogol),
            new Book("Мертвые души", 1842, Gogol),
            new Book("Шинель", 1842, Gogol),
            new Book("Шинель", 1842, Gogol),
            new Book("Шинель", 1842, Gogol),
            new Book("Шинель", 1842, Gogol),
            new Book("Шинель", 1842, Gogol),

            new Book("Война и мир", 1869, Tolstoy),
            new Book("Война и мир", 1869, Tolstoy),
            new Book("Война и мир", 1869, Tolstoy),
            new Book("Война и мир", 1869, Tolstoy),
            new Book("Война и мир", 1869, Tolstoy),
            new Book("Анна Каренина", 1877, Tolstoy),
            new Book("Анна Каренина", 1877, Tolstoy),
            new Book("Анна Каренина", 1877, Tolstoy),
            new Book("Анна Каренина", 1877, Tolstoy),
            new Book("Анна Каренина", 1877, Tolstoy),

            new Book("Отцы и дети", 1862, Turgenev),
            new Book("Отцы и дети", 1862, Turgenev),
            new Book("Отцы и дети", 1862, Turgenev),
            new Book("Отцы и дети", 1862, Turgenev),
            new Book("Отцы и дети", 1862, Turgenev),
            new Book("Месяц в деревне", 1855, Turgenev),
            new Book("Месяц в деревне", 1855, Turgenev),
            new Book("Месяц в деревне", 1855, Turgenev),
            new Book("Месяц в деревне", 1855, Turgenev),
            new Book("Месяц в деревне", 1855, Turgenev),

            new Book("Вишневый сад", 1904, Chekhov),
            new Book("Вишневый сад", 1904, Chekhov),
            new Book("Вишневый сад", 1904, Chekhov),
            new Book("Вишневый сад", 1904, Chekhov),
            new Book("Вишневый сад", 1904, Chekhov),
            new Book("Чайка", 1896, Chekhov),
            new Book("Чайка", 1896, Chekhov),
            new Book("Чайка", 1896, Chekhov),
            new Book("Чайка", 1896, Chekhov),
            new Book("Чайка", 1896, Chekhov),

            new Book("Облака над Кремлем", 1925, Mayakovsky),
            new Book("Облака над Кремлем", 1925, Mayakovsky),
            new Book("Облака над Кремлем", 1925, Mayakovsky),
            new Book("Облака над Кремлем", 1925, Mayakovsky),
            new Book("Облака над Кремлем", 1925, Mayakovsky),

            new Book("Сердце звезды", 1935, Herzen),
            new Book("Сердце звезды", 1935, Herzen),
            new Book("Сердце звезды", 1935, Herzen),
            new Book("Сердце звезды", 1935, Herzen),
            new Book("Сердце звезды", 1935, Herzen),

            new Book("Обломов", 1859, Goncharov),
            new Book("Обломов", 1859, Goncharov),
            new Book("Обломов", 1859, Goncharov),
            new Book("Обломов", 1859, Goncharov),
            new Book("Обломов", 1859, Goncharov),

            new Book("Герой нашего времени", 1840, Lermontov),
            new Book("Герой нашего времени", 1840, Lermontov),
            new Book("Герой нашего времени", 1840, Lermontov),
            new Book("Герой нашего времени", 1840, Lermontov),
            new Book("Герой нашего времени", 1840, Lermontov),

            new Book("Двенадцать", 1918, Blok),
            new Book("Двенадцать", 1918, Blok),
            new Book("Двенадцать", 1918, Blok),
            new Book("Двенадцать", 1918, Blok),
            new Book("Двенадцать", 1918, Blok),

            new Book("Доктор Живаго", 1957, Pasternak),
            new Book("Доктор Живаго", 1957, Pasternak),
            new Book("Доктор Живаго", 1957, Pasternak),
            new Book("Доктор Живаго", 1957, Pasternak),
            new Book("Доктор Живаго", 1957, Pasternak),

            new Book("Реквием", 1935, Akhmatova),
            new Book("Реквием", 1935, Akhmatova),
            new Book("Реквием", 1935, Akhmatova),
            new Book("Реквием", 1935, Akhmatova),
            new Book("Реквием", 1935, Akhmatova),

            new Book("Кому на Руси жить хорошо", 1866, Nekrasov),
            new Book("Кому на Руси жить хорошо", 1866, Nekrasov),
            new Book("Кому на Руси жить хорошо", 1866, Nekrasov),
            new Book("Кому на Руси жить хорошо", 1866, Nekrasov),
            new Book("Кому на Руси жить хорошо", 1866, Nekrasov),

            new Book("Архипелаг ГУЛАГ", 1973, Solzhenitsyn),
            new Book("Архипелаг ГУЛАГ", 1973, Solzhenitsyn),
            new Book("Архипелаг ГУЛАГ", 1973, Solzhenitsyn),
            new Book("Архипелаг ГУЛАГ", 1973, Solzhenitsyn),
            new Book("Архипелаг ГУЛАГ", 1973, Solzhenitsyn),

            new Book("Мастер и Маргарита", 1967, Bulgakov),
            new Book("Мастер и Маргарита", 1967, Bulgakov),
            new Book("Мастер и Маргарита", 1967, Bulgakov),
            new Book("Мастер и Маргарита", 1967, Bulgakov),
            new Book("Мастер и Маргарита", 1967, Bulgakov)
        };
        libary.AddMore(books);

        var booksJSON = libary.GetBooks();
        string json = JsonConvert.SerializeObject(booksJSON, Formatting.Indented);

        File.WriteAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json", json);
        libary.Clear(); //Очищаем память

        List<Book> booksByYear = libary.GetBookOnYear(1967);
        Console.WriteLine("Книги за 1967 год:");
        PrintList(booksByYear);

        List<Book> booksByAuthor = libary.GetBookOnAuthor(Pushkin);
        Console.WriteLine("\nКниги автора Александра Пушкина:");
        PrintList(booksByAuthor);

        List<Book> booksByTitle = libary.GetBookOnTitle("Мастер и Маргарита");
        Console.WriteLine("\nКниги с названием 'Мастер и Маргарита':");
        PrintList(booksByTitle);

        List<Book> booksByAuthorSurname = libary.GetBookOnAuthorSurname("Булгаков");
        Console.WriteLine("\nКниги с фамилией 'Булгаков':");
        PrintList(booksByAuthorSurname);

        // Пример вызова функции GetBookOnYearRange
        List<Book> booksByYearRange = libary.GetBookOnYearRange(1900, 1980);
        Console.WriteLine("\nКниги с диапазоном годов 1900-1980:");
        PrintList(booksByYearRange);

    }
}