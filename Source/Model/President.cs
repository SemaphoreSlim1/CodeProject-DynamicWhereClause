using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class President
    {
        public Guid ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }  
        public int PresidentNumber { get; set; }
        public DateTime TookOffice { get; set; }
        public DateTime LeftOffice { get; set; }
        public Boolean IsAlive { get; set; }

        public String Party { get; set; }
        public IEnumerable<Term> Terms { get; set; }

        public President(String firstName, String lastName)            
        {
            this.ID = Guid.NewGuid();
            this.FirstName = firstName;
            this.LastName = lastName;
            this.IsAlive = false;
        }
    }

    public class Term
    {
        public int Number { get; set; }
        public int StartYear { get; set; }

        public Term(int number, int startYear)
        {
            Number = number;
            StartYear = startYear;
        }
    }
}
