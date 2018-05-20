using System;

namespace CrudApi.Models
{
    public class Person
    {

        public int PersonId { get; set; }
        
        public string Name { get; set; }
     
        public string DocumentNumber { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        public string Address { get; set; }
        
        public bool IsEmployed { get; set; }

        public decimal Income { get; set; }
    }
}
