using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l
{

    internal class Program
    {
        static void Main()
        {
            Client client = new Client("Elena", "yelenahovhannisya@gmail.com");
            Client client2 = new Client("Lika", "yelenahovhannisya@g.com");
            Book book1 = new Book("Anush", "Tumanyan");
            Library lib = new Library();
            lib.add_book(book1, 3);
 
        }
    }
}
