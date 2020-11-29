using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

//1. Создать необобщенную коллекцию ArrayList.
//   a.Заполните ее 5-ю случайными целыми числами
//   b.Добавьте к ней строку
//   c.Добавьте объект типа Student
//   d.Удалите заданный элемент
//   e.Выведите количество элементов и коллекцию на консоль.
//   f.Выполните поиск в коллекции значения
//2. Создать обобщенную коллекцию в соответствии с вариантом задания и заполнить ее данными, тип которых определяется вариантом задания (колонка – первый тип).
//   a.Вывести коллекцию на консоль
//   b.Удалите из коллекции n последовательных элементов
//   c.Добавьте другие элементы(используйте все возможные методы добавления для вашего типа коллекции).
//   d.Создайте вторую коллекцию(см.таблицу) и заполните ее данными из первой коллекции.
//   e.Выведите вторую коллекцию на консоль.В случае не совпадения количества параметров(например, LinkedList<T> и Dictionary<Tkey, TValue>), 
//    при нехватке - генерируйте ключи, в случае избыточности – оставляйте TValue.
//   f.Найдите во второй коллекции заданное значение.
//   3. Повторите задание п.2 для пользовательского типа данных(в качестве типа T возьмите любой свой класс из лабораторной №5 (Наследование…. ). 
//    Не забывайте о необходимости реализации интерфейсов(IComparable, ICompare,….). При выводе коллекции используйте цикл foreach.
//   4. Создайте объект наблюдаемой коллекции ObservableCollection<T>.
//    Создайте произвольный метод и зарегистрируйте его на событие CollectionChange.
//    Напишите демонстрацию с добавлением и удалением элементов.В качестве
//типа T используйте свой класс из лабораторной №5 Наследование….

//   Вариант: LinkedList<T> char HashSet<T>

namespace lab_10_1_
{
    class Student
    {
        public string Name;
        public string Group;
        public string Course;
        public string Specialty;
        public Student(string name, string course, string group, string speciality)
        {
            Name = name;
            Course = course;
            Group = group;
            Specialty = speciality;
        }
        public override string ToString()
        {
            return "~~~Student~~~\nName: " + Name + "\nCourse: " + Course + "\nGroup: " + Group + "\nSpesiality: " + Specialty + "\n~~~~~~~~~";
        }
    }
    abstract class GeneralInfo
    {
        public string Country { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        public string Cover { get; set; }
    }
    class Book : GeneralInfo
    {
        public string TitleOfBook { get; set; }
        public Book(string title, string country, int year, int pages, string cover)
        {
            TitleOfBook = title;
            Country = country;
            Year = year;
            Pages = pages;
            Cover = cover;
        }
        public override string ToString()
        {
            return "~~~~~~~~~~Information about book~~~~~~~~~~\nTitle: " + TitleOfBook + "\nYear: " + Year + "\nPages: " + Pages + "\nCountry: " + Country;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("~~~~~~~~~~ArrayList~~~~~~~~~~");
            ArrayList arrlist = new ArrayList();
            Random rand = new Random();
            for (int i = 0; i < 0; i++)
            {
                arrlist.Add(rand.Next(10, 99));
            }
            arrlist.Add("string");
            Student stud = new Student("Harry Potter", "1", "Gryffindor", "Magic");
            arrlist.Add(stud);
            foreach (object x in arrlist)
            {
                if (x is Student)
                {
                    Console.WriteLine(x.ToString());
                }
                else
                {
                    Console.WriteLine(x);
                }
            }
            arrlist.RemoveAt(0);
            Console.WriteLine("\nAfter delition: ");
            foreach (object x in arrlist)
            {
                if (x is Student)
                {
                    Console.WriteLine(x.ToString());
                }
                else
                {
                    Console.WriteLine(x);
                }
            }
            Console.WriteLine("\nNumber of elements: " + arrlist.Count); //Count это свойство, Capacity это число элементов, которые могут жраниться в ArrayList
            Console.WriteLine("\nCheck for availability: ");
            Console.WriteLine("Student?........." + arrlist.Contains(stud));
            Console.WriteLine("1?........." + arrlist.Contains(1));


            Console.WriteLine("\n\n~~~~~~~~~~LinkedList~~~~~~~~~~");
            LinkedList<char> linklist = new LinkedList<char>();
            linklist.AddFirst('b');
            linklist.AddFirst('a');
            linklist.AddLast('c');
            linklist.AddLast('f');
            linklist.AddBefore(linklist.Last, 'd');
            linklist.AddAfter(linklist.Last, 'g');
            linklist.AddBefore(linklist.Last.Previous, 'e');
            foreach (char x in linklist)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("Deleting first 2 elements: ");
            for (int i = 0; i < 2; i++)
            {
                linklist.RemoveFirst();
            }
            foreach (char x in linklist)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("Deleting last but one: ");
            linklist.Remove(linklist.Last.Previous);
            foreach (char x in linklist)
            {
                Console.WriteLine(x);
            }


            Console.WriteLine("\n\n~~~~~~~~~~HashSet~~~~~~~~~~");
            HashSet<char> hset = new HashSet<char>(); //неупорядоченный список различающихся элементов
            foreach (char x in linklist)
            {
                hset.Add(x);
            }
            foreach (char x in linklist)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\nCheck for availability: ");
            Console.WriteLine("c?........." + hset.Contains('c'));
            Console.WriteLine("w?........." + hset.Contains('w'));


            Console.WriteLine("\n\n~~~~~~~~~~LinkedList for book~~~~~~~~~~");
            Book book1 = new Book("Harry Potter and the Prisoner of Azkaban", "United Kingdom", 1999, 464, "hard");
            Book book2 = new Book("Harry Potter and the Half-Blood Prince", "United Kingdom", 2005, 607, "hard");
            Book book3 = new Book("Harry Potter and the Philosopher's Stone", "United Kingdom", 1997, 332, "hard");
            Book book4 = new Book("Harry Potter and the Goblet of Fire", "United Kingdom", 2000, 636, "hard");
            LinkedList<Book> linkbook = new LinkedList<Book>();
            linkbook.AddFirst(book1);
            linkbook.AddLast(book4);
            linkbook.AddAfter(linkbook.First, book2);
            linkbook.AddBefore(linkbook.Last, book3);
            foreach (Book x in linkbook)
            {
                Console.WriteLine(x.ToString());
            }
            Console.WriteLine("\n\nDeleting first 2 elements: ");
            for (int i = 0; i < 2; i++)
            {
                linkbook.RemoveFirst();
            }
            foreach (Book x in linkbook)
            {
                Console.WriteLine(x.ToString());
            }

            Console.WriteLine("\n\n~~~~~~~~~~HashSet for book~~~~~~~~~~");
            HashSet<Book> hashbook = new HashSet<Book>();
            foreach (Book x in hashbook)
            {
                Console.WriteLine(x.ToString());
            }
            Console.WriteLine("\nCheck for availability: ");
            Console.WriteLine("book1?........." + hashbook.Contains(book1));
            Console.WriteLine("book4?........." + hashbook.Contains(book4));


            Console.WriteLine("\n\n~~~~~~~~~~ObservableCollection<T>~~~~~~~~~~");
            ObservableCollection<Book> books = new ObservableCollection<Book>(); //похож на список List за тем исключением, что позволяет известить внешние объекты о том, что коллекция была изменена
            books.CollectionChanged += Books_CollectionChanged;
            void Books_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    Book addbook = e.NewItems[0] as Book;
                    Console.WriteLine("\nNew object was added: \n" + addbook.ToString());
                }
                else
                {
                    if (e.Action == NotifyCollectionChangedAction.Remove)
                    {
                        Book delbook = e.OldItems[0] as Book;
                        Console.WriteLine("\nObgect was deleted: \n" + delbook.ToString());
                    }
                }
            }
            books.Add(book1);
            books.Add(book2);
            books.Add(book3);
            books.Add(book4);
            books.RemoveAt(1);
        }
    }
}
