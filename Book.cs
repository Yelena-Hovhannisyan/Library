using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l
{
    public class Book
    {
        public static int Id = 0;
        public string Title { get;private set; }
        public string Author {  get; private set; }
        public Book(string title, string author)
        {
            Id += 1;
            Title = title;
            Author = author;
        }
    }
}
