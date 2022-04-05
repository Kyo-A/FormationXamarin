using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormationXamForms.Models
{
    public class ContactModel
    {
        [PrimaryKey, AutoIncrement]
        public int Num { get; set; }
        [MaxLength(255)]
        public string FirstName { get; set; }
        [MaxLength(255)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return FirstName.ToString();
        }
    }
}
