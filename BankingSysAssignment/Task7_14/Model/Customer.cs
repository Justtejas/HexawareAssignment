using System.Text.RegularExpressions;

namespace Task7_14.Model
{
    internal class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private string emailAddress { get; set; }
        public string EmailAddress
        {
            get { return emailAddress; }
            set
            {
                if (IsValidEmail(value))
                {
                    emailAddress = value;
                }
                else
                {
                    throw new ArgumentException("Invalid email address format.");
                }
            }
        }
        private string phoneNumber { get; set; }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (IsValidPhoneNumber(value))
                {
                    phoneNumber = value;
                }
                else
                {
                    throw new ArgumentException("Phone number must be a 10-digit number.");
                }
            }
        }
        public string Address { get; set; }

        public Customer() { }
        public Customer(int custID, string firstName, string lastName, string email, string phoneNumber, string address)
        {
            CustomerID = custID;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
        private bool IsValidPhoneNumber(string phone)
        {
        string pattern = @"^\d{10}$";
        return Regex.IsMatch(phone, pattern);
        }
        public override string ToString()
        {
            return $"CustomerID: {CustomerID} \t First Name: {FirstName} \t Last Name: {LastName} \t Email: {EmailAddress} \t Phone Number: {PhoneNumber} \t Address: {Address}";
        }

    }
}
