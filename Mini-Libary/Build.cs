using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Libary
{
    public static class Build
    {
        public static void BuildLibary(Libary libary)
        {
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

            libary.Clear();

        }
    }
}
