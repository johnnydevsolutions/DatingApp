using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingBack.Extensions
{
    public static class DateTimeExtensions
    {
       /*  public static int CalculateAge(this DateTime dob)
        {
            var today = DateTime.UtcNow;
            var age = today.Year - dob.Year;
            if (dob > today.AddYears(-age)) age--;
            return age;
        } */

        public static int CalculateAge(this DateOnly dateOfBirth)
        {
            var today = DateOnly.FromDateTime(DateTime.Now.Date);
            var age = today.Year - dateOfBirth.Year;

            if (dateOfBirth.AddYears(age) > today)
            {
                age--;
            }

            return age;
        }
    }
}