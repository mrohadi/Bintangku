using System;

namespace Bintangku.WebApi.Extensions
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

        /// <summary>
        /// Extension method to calculate child age
        /// </summary>
        /// <param name="dob">Date of birth child</param>
        /// <returns>Age of children</returns>
        public static int CalculateAgeAnak(this DateTime dob)
        {
            var today = DateTime.Today;
            var month = today.Month - dob.Month;
            var year = (today.Year - dob.Year) * 12;
            var age = month + year;
            return age;
        }
    }
}