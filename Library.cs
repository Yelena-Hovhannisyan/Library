using l;
using System;
using System.Collections.Generic;

namespace LibraryApp.Models
{
    public class Library
    {
        public Library()
        {
            clients = new HashSet<Client>();
            books = new HashSet<LibBook>();
            records = new Dictionary<Client, List<BorrowInfo>>();
        }
        public class BorrowInfo
        {
            public int id { get; }

            public int client_id { get; }
            public int book_id { get; }
            public DateTime BorrowDate { get; set; }
            public DateTime ReturnDate { get; set; }

            public BorrowInfo(int cid, int bid, DateTime borrow_date, DateTime return_date)
            {
                client_id = cid;
                book_id = bid;
                BorrowDate = borrow_date;
                ReturnDate = return_date;
            }
        }

        public class LibBook
        {
            static private int book_count = 0;
            public int id;
            public Book bookinfo;
            public int count;

            public LibBook(Book bookinfo, int count)
            {
                this.bookinfo = bookinfo;
                this.count = count;
            }

            public override int GetHashCode()
            {
                return id.GetHashCode();
            }
        }

        private HashSet<Client> clients;
        private HashSet<LibBook> books;
        private Dictionary<Client, List<BorrowInfo>> records;

        private int borrow_duration = 21;

        public LibBook Search(Book book)
        {
            foreach (var libbook in books)
            {
                // additional logical
                if (libbook.bookinfo == book)
                {
                    return libbook;
                }
            }

            return null;
        }


        private bool IsRegistered(Client client)
        {
            return clients.Contains(client);
        }

        private bool IsAvailable(LibBook lbook)
        {
            return lbook.count > 1;
        }

        public void borrow(Client client, Book book)
        {
            if (!IsRegistered(client))
            {
                Console.WriteLine("Client is not registered in library");
            }


            LibBook libbook = Search(book);

            if (libbook == null)
            {
                Console.WriteLine("Book is not available");

                return;
            }

            if (IsAvailable(libbook))
            {
                Console.WriteLine($"Borrow faile, book is no available {1}", book.Title);

                return;
            }

            BorrowInfo new_transactions = new BorrowInfo(client.Id, libbook.id, DateTime.Now, DateTime.Now.AddDays(borrow_duration));

            libbook.count -= 1;

            records[client].Add(new_transactions);

            Console.WriteLine($"Client {0} borrowed book {1}", client.Name, book.Title);
        }

        public void return_book(Client client, Book book)  // lots of errors
        {
            if (!IsRegistered(client))
            {
                Console.WriteLine("Client is not registered in library");
            }

            LibBook libbook = Search(book);

            if (libbook == null)
            {
                Console.WriteLine("Book is not available");

                return;
            }

            var client_transactions = records[client];

            foreach (var transaction in client_transactions)
            {
                if (transaction.book_id == libbook.id)
                {
                    records[client].Remove(transaction);
                    libbook.count += 1;

                    Console.WriteLine("Client returned book");

                    return;
                }
            }

            if (client_transactions.Count == 0)
            {
                records.Remove(client);
            }

            Console.WriteLine("User didnt borrow that book");
        }

        public void register(Client client)
        {
            clients.Add(client);

            Console.WriteLine($"Client {client.Name} registered");
        }


        public void unregister(Client client)
        {
            clients.Remove(client);

            Console.WriteLine($"Client {client.Name} unregistered");
        }

        public void add_book(Book book, int book_count)
        {
            LibBook libBook = new LibBook(book, book_count);

            books.Add(libBook);
        }
    }
}
