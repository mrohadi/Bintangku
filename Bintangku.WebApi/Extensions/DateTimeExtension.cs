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

        public static int CalculateAgeAnak(this DateTime dob)
        {
            var today = DateTime.Today;
            var age = today.Month - dob.Month;
            if(dob.Date > today.AddMonths(-age)) 
                age--;
            return age;
        }
    }
}