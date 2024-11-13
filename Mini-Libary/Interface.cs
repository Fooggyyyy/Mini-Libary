using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Libary
{
    public static class Interface
    {
        private static List<Reader> readers = new List<Reader>();
        public static void InterfaceMethod()
        {
            Console.WriteLine("Пет-проект \"Libary\"");
            while (true)
            {
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1 - Отобразаить книги в библиотеке");
                Console.WriteLine("2 - Поиск книги");
                Console.WriteLine("3 - Действия с читателями");
                Console.WriteLine("4 - Отчистить консоль");
                Console.WriteLine("5 - Выход");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        DisplayAllBook();
                        break;
                    case 2:
                        bool flag = true;
                        while(flag)
                        {
                            Console.WriteLine("Вы попали в поиск книг. Выберите какими способами вы будете искать книгу");
                            Console.WriteLine("1 - По году выпуска");
                            Console.WriteLine("2 - По названию книги");
                            Console.WriteLine("3 - По фамилии автора");
                            Console.WriteLine("4 - По диапозону годов выпуска");
                            Console.WriteLine("5 - Выход из поиска книг");

                            int choice_searchBook = Convert.ToInt32(Console.ReadLine());
                            switch (choice_searchBook)
                            {
                                case 1:
                                    Console.WriteLine("Введите год поиска: ");
                                    int year = Convert.ToInt32(Console.ReadLine());
                                    Libary.GetBookOnYear(year);
                                    break;
                                case 2:
                                    Console.WriteLine("Введите название книги: ");
                                    string? title = Console.ReadLine();
                                    title = title.ToLower();
                                    Libary.GetBookOnTitle(title);
                                    break;
                                case 3:
                                    Console.WriteLine("Введите фамилию автора: ");
                                    string? surname = Console.ReadLine();
                                    surname = surname.ToLower();
                                    Libary.GetBookOnAuthorSurname(surname);
                                    break;
                                case 4:
                                    Console.WriteLine("Введите нижний предел поиска: ");
                                    int first_year = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Введите верхний предел поиска");
                                    int last_year = Convert.ToInt32(Console.ReadLine());
                                    Libary.GetBookOnYearRange(first_year, last_year);
                                    break;
                                case 5:
                                    flag = false;
                                    break;
                                default:
                                    Console.WriteLine("Вы ввели не корректное значение!!!");
                                    break;
                            }
                            
                        }
                        break;
                    case 3:
                        bool readerFlag = true;
                        while (readerFlag)
                        {
                            Console.WriteLine("Выберите действие для работы с читателями: ");
                            Console.WriteLine("1 - Добавить читателя");
                            Console.WriteLine("2 - Взять книгу(для конкретного читателя)");
                            Console.WriteLine("3 - Вернуть книгу(для конкретного читателя)");
                            Console.WriteLine("4 - Показать все книги(для конкретного читателя)");
                            Console.WriteLine("5 - Показать баланс(для конкретного читателя)");
                            Console.WriteLine("6 - Показать полную информацию о читателе");
                            Console.WriteLine("7 - Показать всех читателей");
                            Console.WriteLine("8 - Вернуться в главное меню");
                            int readerChoice = Convert.ToInt32(Console.ReadLine());

                            switch (readerChoice)
                            {
                                case 1:
                                    Console.WriteLine("Введите имя читателя: ");
                                    string? readerName = Console.ReadLine();
                                    Console.WriteLine("Введите начальную сумму денег у читателя: ");
                                    int readerMoney = Convert.ToInt32(Console.ReadLine());
                                    readers.Add(ReaderFactory.CreateReader(readerName, readerMoney));
                                    break;

                                case 2:
                                    Console.WriteLine("Введите имя читателя: ");
                                    string? takeReaderName = Console.ReadLine();
                                    Reader? takeReader = readers.FirstOrDefault(r => r.name == takeReaderName);

                                    if (takeReader != null)
                                    {
                                        Console.WriteLine("Введите название книги: ");
                                        string? bookTitle = Console.ReadLine();
                                        Console.WriteLine("Введите фамилию автора: ");
                                        string? authorSurname = Console.ReadLine();
                                        takeReader.TakeBook(bookTitle, authorSurname);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Читатель не найден.");
                                    }
                                    break;

                                case 3:
                                    Console.WriteLine("Введите имя читателя: ");
                                    string? returnReaderName = Console.ReadLine();
                                    Reader? returnReader = readers.FirstOrDefault(r => r.name == returnReaderName);

                                    if (returnReader != null)
                                    {
                                        Console.WriteLine("Введите название книги: ");
                                        string? returnBookTitle = Console.ReadLine();
                                        returnReader.BackBook(returnBookTitle);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Читатель не найден.");
                                    }
                                    break;

                                case 4:
                                    Console.WriteLine("Введите имя читателя: ");
                                    string? showBooksReaderName = Console.ReadLine();
                                    Reader? showBooksReader = readers.FirstOrDefault(r => r.name == showBooksReaderName);

                                    if (showBooksReader != null)
                                    {
                                        showBooksReader.DisplayBooks();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Читатель не найден.");
                                    }
                                    break;

                                case 5:
                                    Console.WriteLine("Введите имя читателя: ");
                                    string? balanceReaderName = Console.ReadLine();
                                    Reader? balanceReader = readers.FirstOrDefault(r => r.name == balanceReaderName);

                                    if (balanceReader != null)
                                    {
                                        balanceReader.DisplayBalance();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Читатель не найден.");
                                    }
                                    break;

                                case 6:
                                    Console.WriteLine("Введите имя читателя: ");
                                    string? infoReaderName = Console.ReadLine();
                                    Reader? infoReader = readers.FirstOrDefault(r => r.name == infoReaderName);

                                    if (infoReader != null)
                                    {
                                        infoReader.DisplayInfoReader();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Читатель не найден.");
                                    }
                                    break;

                                case 7:
                                    Console.WriteLine("Информация про всех читателей: ");
                                    Console.WriteLine(" ");
                                    foreach(var reader in readers)
                                    {
                                        reader.DisplayInfoReader();
                                        Console.WriteLine("");
                                    }
                                    break;

                                case 8:
                                    readerFlag = false;
                                    break;

                                default:
                                    Console.WriteLine("Вы ввели не корректное значение!!!");
                                    break;
                            }
                        }
                        break;
                    case 4:
                        Console.Clear();
                        break;
                    case 5:
                        Console.WriteLine("Вы вышли с проекта!!!");
                        return;
                    default:
                        Console.WriteLine("Вы ввели не корректное действие!!!");
                        break;
                       
                        
                }
            }
        }

        private static void DisplayAllBook()
        {
            JArray books = JArray.Parse(File.ReadAllText("C:\\Users\\user\\source\\repos\\Mini-Libary\\libary.json"));
            var Books = books.Select(b => new Book(
                                               (string?)b["TitleB"],
                                               (int)b["YearB"],
                                               new Author(
                                                   (string?)b["AuthorB"]["NameA"],
                                                   (string?)b["AuthorB"]["SurNameA"]
                                               )
                                           )).ToList();
            foreach (var book in Books)
            {
                book.DisplayInfo();
            }
        }
    }
}
