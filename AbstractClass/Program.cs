using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    class Program
    {
        static void Main(String[] args)
        {
            String title = Console.ReadLine();
            String author = Console.ReadLine();
            int price = Int32.Parse(Console.ReadLine());
            Book new_novel = new MyBook(title, author, price);
            new_novel.display();
        }
    }

    abstract class Book
    {

        protected String title;
        protected String author;

        public Book(String t, String a)
        {
            title = t;
            author = a;
        }
        public abstract void display();


    }

    class MyBook : Book
    {
        private int price;
        public MyBook(string t, string a, int p) : base(t, a)
        {
            price = p;
        }

        public override void display()
        {
            Console.WriteLine("Title: {0}\nAuthor: {1}\nPrice: {2}", title,author, price);
        }
    }
}
