using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int PageCount { get; set; }

        public Book(int id, string title, string author, int year, int pageCount)
        {
            Id = id;
            Title = title;
            Author = author;
            Year = year;
            PageCount = pageCount;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"[{Id}] {Title} - {Author} ({Year}) - {PageCount} səhifə");
        }
    }

    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Book> BorrowedBooks { get; set; }

        public Member(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
            BorrowedBooks = new List<Book>();
        }

        public void BorrowBook(Book book)
        {
            if (BorrowedBooks.Count < 3)
            {
                BorrowedBooks.Add(book);
                Console.WriteLine($"Kitab götürüldü: {book.Title}");
            }
            else
            {
                Console.WriteLine("Maksimum 3 kitab götürə bilərsiniz!");
            }
        }

        public void ReturnBook(int bookId)
        {
            Book bookToRemove = null;
            foreach (var book in BorrowedBooks)
            {
                if (book.Id == bookId)
                {
                    bookToRemove = book;
                    break;
                }
            }

            if (bookToRemove != null)
            {
                BorrowedBooks.Remove(bookToRemove);
                Console.WriteLine($"Kitab qaytarıldı: {bookToRemove.Title}");
            }
        }

        public void DisplayBorrowedBooks()
        {
            if (BorrowedBooks.Count == 0)
            {
                Console.WriteLine("Borc kitab yoxdur");
            }
            else
            {
                Console.WriteLine($"{Name} tərəfindən götürülən kitablar:");
                foreach (var book in BorrowedBooks)
                {
                    book.DisplayInfo();
                }
            }
        }
    }

    public class Library<T>
    {
        public List<T> Items { get; set; }
        public string Name { get; set; }

        public Library(string name)
        {
            Name = name;
            Items = new List<T>();
        }

        public void Add(T item)
        {
            Items.Add(item);
            Console.WriteLine("Əlavə edildi");
        }

        public void Remove(T item)
        {
            Items.Remove(item);
            Console.WriteLine("Silindi");
        }

        public List<T> GetAll() => Items;

        public int Count() => Items.Count;

        public T FindByIndex(int index)
        {
            if (index >= 0 && index < Items.Count)
                return Items[index];
            return default;
        }
    }

    public class BookManager
    {
        public List<Book> Books { get; set; }
        public Dictionary<string, List<Book>> BooksByAuthor { get; set; }
        public Queue<string> WaitingQueue { get; set; }
        public Stack<Book> RecentlyReturned { get; set; }

        public BookManager()
        {
            Books = new List<Book>();
            BooksByAuthor = new Dictionary<string, List<Book>>();
            WaitingQueue = new Queue<string>();
            RecentlyReturned = new Stack<Book>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
            if (!BooksByAuthor.ContainsKey(book.Author))
            {
                BooksByAuthor[book.Author] = new List<Book>();
            }
            BooksByAuthor[book.Author].Add(book);
        }

        public Book SearchByTitle(string title)
        {
            foreach (var book in Books)
            {
                if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                    return book;
            }
            return null;
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            if (BooksByAuthor.ContainsKey(author))
                return BooksByAuthor[author];
            return new List<Book>();
        }

        public void AddToWaitingQueue(string memberName)
        {
            WaitingQueue.Enqueue(memberName);
            Console.WriteLine($"{memberName} növbəyə əlavə olundu");
        }

        public string ServeNextInQueue()
        {
            if (WaitingQueue.Count > 0)
                return WaitingQueue.Dequeue();
            return null;
        }

        public void ReturnBook(Book book)
        {
            RecentlyReturned.Push(book);
            Console.WriteLine($"Kitab qəbul edildi: {book.Title}");
        }

        public Book GetLastReturnedBook()
        {
            if (RecentlyReturned.Count > 0)
                return RecentlyReturned.Peek();
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Book b1 = new Book(1, "Martin Eden", "Jack London", 1909, 400);
            Book b2 = new Book(2, "1984", "George Orwell", 1949, 328);
            Book b3 = new Book(3, "Animal Farm", "George Orwell", 1945, 112);
            Book b4 = new Book(4, "Ağ Gəmi", "Cingiz Aytmatov", 1970, 200);
            Book b5 = new Book(5, "Qırıq Budaq", "Elçin", 1998, 350);

            Console.WriteLine("--- Kitab Məlumatları ---");
            b1.DisplayInfo();
            b2.DisplayInfo();
            b3.DisplayInfo();
            b4.DisplayInfo();
            b5.DisplayInfo();

            Console.WriteLine("\n--- Generic Library Testi ---");
            Library<Book> myLibrary = new Library<Book>("Milli Kitabxana");
            myLibrary.Add(b1); myLibrary.Add(b2); myLibrary.Add(b3); myLibrary.Add(b4); myLibrary.Add(b5);

            Console.WriteLine($"Kitab sayı: {myLibrary.Count()}");
            Console.WriteLine("İndeks 0-dakı kitab:");
            myLibrary.FindByIndex(0).DisplayInfo();

            Console.WriteLine("\n--- Üzv Əməliyyatları ---");
            Member m1 = new Member(1, "Ali Məmmədov", "ali@mail.com");
            m1.BorrowBook(b1);
            m1.BorrowBook(b2);
            m1.DisplayBorrowedBooks();
            m1.ReturnBook(1);
            m1.DisplayBorrowedBooks();

            m1.BorrowBook(b3);
            m1.BorrowBook(b4);
            m1.BorrowBook(b5); 

            Console.WriteLine("\n--- Müəllifə görə axtarış ---");
            BookManager manager = new BookManager();
            manager.AddBook(b1); manager.AddBook(b2); manager.AddBook(b3); manager.AddBook(b4); manager.AddBook(b5);

            var orwellBooks = manager.GetBooksByAuthor("George Orwell");
            Console.WriteLine($"George Orwell kitabları ({orwellBooks.Count}):");
            orwellBooks.ForEach(b => b.DisplayInfo());

            Console.WriteLine("\n--- Növbə Testi ---");
            manager.AddToWaitingQueue("Nigar");
            manager.AddToWaitingQueue("Rəşad");
            manager.AddToWaitingQueue("Səbinə");
            Console.WriteLine($"Növbədə say: {manager.WaitingQueue.Count}");
            Console.WriteLine($"Xidmət edilir: {manager.ServeNextInQueue()}");
            Console.WriteLine($"Qalan say: {manager.WaitingQueue.Count}");

            Console.WriteLine("\n--- Stack (Son qaytarılanlar) ---");
            manager.ReturnBook(b1);
            manager.ReturnBook(b2);
            manager.ReturnBook(b3);
            Console.WriteLine($"Son qaytarılan: {manager.GetLastReturnedBook()?.Title}");
            manager.RecentlyReturned.Pop();
            Console.WriteLine($"1 kitab çıxdıqdan sonra sonuncu: {manager.GetLastReturnedBook()?.Title}");

            Console.WriteLine("\n--- Başlığa görə axtarış ---");
            Book found = manager.SearchByTitle("1984");
            if (found != null) found.DisplayInfo();

            Book notFound = manager.SearchByTitle("Harry Potter");
            if (notFound == null) Console.WriteLine("Harry Potter tapılmadı.");

            Console.WriteLine("\n--- Statistika ---");
            Console.WriteLine($"Ümumi kitab: {manager.Books.Count}");

            int minYear = manager.Books[0].Year;
            int maxYear = manager.Books[0].Year;
            foreach (var b in manager.Books)
            {
                if (b.Year < minYear) minYear = b.Year;
                if (b.Year > maxYear) maxYear = b.Year;
            }
            Console.WriteLine($"Ən köhnə kitabın ili: {minYear}");
            Console.WriteLine($"Ən yeni kitabın ili: {maxYear}");
        }
    }
}