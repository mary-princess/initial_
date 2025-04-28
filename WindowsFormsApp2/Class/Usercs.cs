using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Class
{
    public class Usercs
    {
        public string GlobalUser {  get; set; }

        public Image Profile {  get; set; }
        public string ImagePath { get; set; }
        public  DateTime DateTime { get; set; }
        public DateTime Birthdate { get; set; }

        public int Age { get; set; }

        public int CalculateAge(DateTime birthdate)
        {
            var today = DateTime.Today;
            var age = today.Year - Birthdate.Year;
            if (Birthdate > today.AddYears(-age))
                age--;
            return age;
        }

    }
}
