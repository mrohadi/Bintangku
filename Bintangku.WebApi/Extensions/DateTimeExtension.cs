using System;

namespace Bintangku.Data.Extensions
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// Extension method to calculate the age of the nakes user
        /// </summary>
        /// <param name="dob">Date of Birth</param>
        /// <returns>Nakes age</returns>
        public static int CalculateAge(this DateTime dob)
        {
            var today = DateTime.Today;
            var age = today.Year - dob.Year;
            if (dob.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}