using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l
{
    public class Client
    {
        private static int client_counts = 0;
        public int Id;
        public string Name {  get; set; }
        public string Email {  get; set; }
        public Client(string name,string email)
        {
            Id = client_counts;
            client_counts += 1;

            Name = name;
            Email = email;
        }

        public override int GetHashCode() 
        {
            return Id.GetHashCode();  
        }
    }
}
