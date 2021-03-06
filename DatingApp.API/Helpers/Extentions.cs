using Microsoft.AspNetCore.Http;
using System;

namespace DatingApp.API.Helpers
{
    public static class Extentions
    {
        // public static void AddApplicationError (this HttpResponse response, string message) {
        //     response.Headers.Add ("Application-Error", message);
        //     response.Headers.Add ("Access-Control-Expose-Headers", "Application-Error");
        //     response.Headers.Add ("Access-Control-Allow-Origin", "*");
        // }
        public static void AddApplicationError(this HttpResponse responce, string message)
        {
            responce.Headers.Add("Application-Error", message);
            responce.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            responce.Headers.Add("Access-Control-Allow-Origin", "*");
        }
        public static int CalculateAge(this DateTime dateTime)
        {
            var age = DateTime.Today.Year - dateTime.Year;
            if (dateTime.AddYears(age) > DateTime.Today)
                age--;

            return age;
        }
    }
}