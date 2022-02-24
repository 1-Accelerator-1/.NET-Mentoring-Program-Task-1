using System;
using System.Linq;
using System.Net.Mail;

namespace ClassLibrary
{
    internal class StringService : IStringService
    {
        public string GetFormattedString(string username)
        {
            username = username.Trim();

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("username", "Value cannot be null.");
            }

            if (!IsEmail(username) && !IsFullName(username))
            {
                throw new ArgumentException("Username is not email or full name.");
            }

            if (IsFullName(username))
            {
                var fullNameArray = username.Split(' ');

                var firstName = fullNameArray[0];
                var lastName = fullNameArray[1];

                firstName = firstName.Replace(firstName[0].ToString(), firstName[0].ToString().ToUpper());
                lastName = lastName.Replace(lastName[0].ToString(), lastName[0].ToString().ToUpper());

                var formattedFullName = firstName + " " + lastName;

                return $"Hello, {formattedFullName}";
            }

            return $"Hello, {username}";
        }

        private bool IsEmail(string email)
        {
            var trimmedEmail = email.Trim();

            try
            {
                var emailAddress = new MailAddress(trimmedEmail);
                return emailAddress.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        private bool IsFullName(string username)
        {
            var trimmedFullName = username.Trim();

            return trimmedFullName.Contains(" ") && !trimmedFullName.Any(char.IsDigit);
        }
    }
}
