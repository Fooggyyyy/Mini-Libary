using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Libary
{
    public class Reader
    {
        private string? Name;
        private int Money;
        private List<Book> BooksList;

        public string? name => Name;
        public Reader(string? Name, int Money)
        {
            this.Name = Name;
            this.Money = Money;
            BooksList = new List<Book>();
        }

        public void TakeBook(string Title, string AuthorSurName)
        {
            try
            {
                if (BooksList.Count >= 5)
                    throw new Exception("Взято слишком много книг. Читатель не может брать более 5 книг");
                if (Money < 20)
                    throw new Exception("Слишком мало денег! Цена каждой книги 20 рублей");

                JArray books = JArray.Parse(File.ReadAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json"));

                var temp = books
                    .Where(b => ((string)b["TitleB"]).ToLower() == Title.ToLower() && ((string)b["AuthorB"]["SurNameA"]).ToLower() == AuthorSurName.ToLower())
                    .Select(b => new Book(
                        (string?)b["TitleB"],
                        (int)b["YearB"],
                        new Author(
                            (string?)b["AuthorB"]["NameA"],
                            (string?)b["AuthorB"]["SurNameA"]
                        )
                    ))
                    .Distinct(new BookComparer())
                    .Take(1)
                    .ToList();

                if (temp.Count == 0)
                {
                    Console.WriteLine("Данной книги нет");
                }
                else
                {
                    BooksList.AddRange(temp);

                    int indexToRemove = books.ToList().FindIndex(b =>
                        ((string)b["TitleB"]).ToLower() == Title.ToLower() &&
                        ((string)b["AuthorB"]["SurNameA"]).ToLower() == AuthorSurName.ToLower());

                    books.RemoveAt(indexToRemove);
                    File.WriteAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json", books.ToString());
                    Money -= 20;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        public void TakeBook(string Title)
        {
            try
            {
                if (BooksList.Count >= 5)
                    throw new Exception("Взято слишком много книг. Читатель не может брать более 5 книг");
                if (Money < 20)
                    throw new Exception("Слишком мало денег! Цена каждой книги 20 рублей");

                JArray books = JArray.Parse(File.ReadAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json"));

                var temp = books
                    .Where(b => ((string)b["TitleB"]).ToLower() == Title.ToLower())
                    .Select(b => new Book(
                        (string?)b["TitleB"],
                        (int)b["YearB"],
                        new Author(
                            (string?)b["AuthorB"]["NameA"],
                            (string?)b["AuthorB"]["SurNameA"]
                        )
                    ))
                    .Distinct(new BookComparer())
                    .Take(1)
                    .ToList();

                if (temp.Count == 0)
                {
                    Console.WriteLine("Данной книги нет");
                }
                else
                {
                    BooksList.AddRange(temp);

                    int indexToRemove = books.ToList().FindIndex(b =>
                        ((string)b["TitleB"]).ToLower() == Title.ToLower());

                    books.RemoveAt(indexToRemove);
                    File.WriteAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json", books.ToString());
                    Money -= 20;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        public void BackBook(string Title, string AuthorSurName)
        {
            try
            {
                var booksToReturn = BooksList.Where(book => book.TitleB.ToLower() == Title.ToLower() && book.AuthorB.SurNameA.ToLower() == AuthorSurName.ToLower()).ToList();

                if (booksToReturn.Count == 0)
                {
                    Console.WriteLine($"Данной книги нет у пользователя {Name}");
                    return;
                }

                JArray books = JArray.Parse(File.ReadAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json"));

                Book bookToReturn = booksToReturn.First();
                books.Add(new JObject
                {
                    ["TitleB"] = bookToReturn.TitleB,
                    ["YearB"] = bookToReturn.YearB,
                    ["AuthorB"] = new JObject
                    {
                        ["NameA"] = bookToReturn.AuthorB.NameA,
                        ["SurNameA"] = bookToReturn.AuthorB.SurNameA
                    }
                });

                BooksList.Remove(bookToReturn);

                File.WriteAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json", books.ToString());

                Money += 20;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        public void BackBook(string Title)
        {
            try
            {
                var booksToReturn = BooksList.Where(book => book.TitleB.ToLower() == Title.ToLower()).ToList();

                if (booksToReturn.Count == 0)
                {
                    Console.WriteLine($"Данной книги нет у пользователя {Name}");
                    return;
                }

                JArray books = JArray.Parse(File.ReadAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json"));

                Book bookToReturn = booksToReturn.First();
                books.Add(new JObject
                {
                    ["TitleB"] = bookToReturn.TitleB,
                    ["YearB"] = bookToReturn.YearB,
                    ["AuthorB"] = new JObject
                    {
                        ["NameA"] = bookToReturn.AuthorB.NameA,
                        ["SurNameA"] = bookToReturn.AuthorB.SurNameA
                    }
                });

                BooksList.Remove(bookToReturn);

                File.WriteAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json", books.ToString());

                Money += 20;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        public void TakeBook(Book book)
        {
            try
            {
                if (BooksList.Count > 5)
                    throw new Exception("Взято слишком много книг. Читатель не может брать более 5 книг");
                if (Money < 20)
                    throw new Exception("Слишком мало денег!!! Цена каждой книги 20 рублей");
                JArray books = JArray.Parse(File.ReadAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json"));
                var temp = books.Where(b => (string)b["TitleB"] == book.TitleB && (string)b["AuthorB"]["SurNameA"] == book.AuthorB.SurNameA)
                                  .Select(b => new Book(
                                       (string?)b["TitleB"],
                                       (int)b["YearB"],
                                       new Author(
                                           (string?)b["AuthorB"]["NameA"],
                                           (string?)b["AuthorB"]["SurNameA"]
                                       )
                                   ))
                                  .Distinct(new BookComparer())
                                  .Take(1)
                                  .ToList();
                if (temp.Count == 0)
                {
                    Console.WriteLine("Данной книги нет");
                }
                else
                {
                    BooksList.AddRange(temp);

                    int indexToRemove = books.ToList().FindIndex(b =>
                        (string)b["TitleB"] == book.TitleB && (string)b["AuthorB"]["SurNameA"] == book.AuthorB.SurNameA);

                    books.RemoveAt(indexToRemove);

                    File.WriteAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json", books.ToString());
                    Money -= 20;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        public void BackBook(Book book)
        {
            try
            {
                var booksToReturn = BooksList.Where(Book => Book.TitleB == book.TitleB 
                && Book.AuthorB.SurNameA == book.AuthorB.SurNameA).ToList();

                if (booksToReturn.Count == 0)
                {
                    Console.WriteLine($"Данной книги нет у пользователя {Name}");
                    return;
                }

                JArray books = JArray.Parse(File.ReadAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json"));

                Book bookToReturn = booksToReturn.First();
                books.Add(new JObject
                {
                    ["TitleB"] = bookToReturn.TitleB,
                    ["YearB"] = bookToReturn.YearB,
                    ["AuthorB"] = new JObject
                    {
                        ["NameA"] = bookToReturn.AuthorB.NameA,
                        ["SurNameA"] = bookToReturn.AuthorB.SurNameA
                    }
                });

                BooksList.Remove(bookToReturn);

                File.WriteAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json", books.ToString());

                Money += 20;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        public void DisplayBooks()
        {
            Console.WriteLine($"Все книги {Name}: ");
            foreach (Book book in BooksList)
            {
                book.DisplayInfo();
            }
        }

        public void DisplayBalance()
        {
            Console.WriteLine($"Баланс {Name}: {Money}");
        }

        public void DisplayInfoReader()
        {
            Console.WriteLine($"Имя: {Name}");
            Console.WriteLine($"Все книги {Name}: ");
            Console.WriteLine($"Баланс {Name}: {Money}");
            foreach (Book book in BooksList)
            {
                book.DisplayInfo();
            }
        }
    }

    public static class ReaderFactory
    {
        public static Reader CreateReader(string Name, int Money)
        {
            return new Reader(Name, Money);
        }
    }
}
