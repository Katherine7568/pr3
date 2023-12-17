using System;
using System.Collections.ObjectModel;

namespace Z3
{
    public class Book : IComparable<Book>, IComparer<Book>, ICloneable
    {
        public string Author { get; }
        public DateTime Date { get; }
        public string Title { get; }
        public double Price { get; }

        public Book(string author, DateTime date, string title, double price)
        {
            Author = author;
            Date = date;
            Title = title;
            Price = price;
        }

        public int CompareTo(Book other)
        {
            if (other == null) return 1;
            return Price.CompareTo(other.Price);
        }

        public int Compare(Book x, Book y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.Price.CompareTo(y.Price);
        }

        public object Clone()
        {
            // Реализация ICloneable - создание копии книги.
            return new Book(Author, Date, Title, Price);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<Book> bookCollection = new ObservableCollection<Book>();

            // Регистрируем метод на событие CollectionChanged
            bookCollection.CollectionChanged += BookCollectionChanged;

            // Добавляем элементы
            Book book1 = new Book("Достоевский", new DateTime(2023, 12, 3), "Преступление и наказание", 459.0);
            bookCollection.Add(book1);

            Book book2 = new Book("Булгаков", new DateTime(2023, 12, 2), "Мастер и Маргарита", 399.0);
            bookCollection.Add(book2);

            // Удаляем элемент
            bookCollection.Remove(book1);

            // Добавляем другие элементы
            Book book3 = new Book("Лермонтов", new DateTime(2023, 12, 1), "Герой нашего времени", 359.0);
            bookCollection.Add(book3);

            // Выводим коллекцию
            Console.WriteLine("Вывод коллекции:");
            foreach (var book in bookCollection)
            {
                Console.WriteLine($"{book.Author}, {book.Date}, {book.Title}, {book.Price}");
            }
        }

        static void BookCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("Добавлен элемент");
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Элемент удален");
            }
        }
    }
}



