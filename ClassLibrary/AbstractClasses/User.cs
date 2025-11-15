using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AbtractClasses;

    public abstract class User
    {
        private int _userId;
        private string _userName = string.Empty; // default value is empty string
        private string _email = string.Empty; // // default value is empty string
        private bool _isActive;
        

        public int UserId 
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        //setter calls method to check if email has valid structure
        public string Email
        {
            get { return _email; }
            set
            {
                if (!CheckEmail(value))
                {
                    //if incorrect email, throw exception
                    throw new ArgumentException($"{value} is not valid email.");
                }
                _email = value;
            }
        }

        public bool IsActive 
        {
            get { return _isActive; }
            set { _isActive = value;} 
        }

        public User() {}
        public User(int id, string name, string email, bool isactive) 
        {
            UserId = id;
            UserName = name;
            Email = email; // setter check if email is valid, if no, exception is thrown and object is not created
            IsActive = isactive;
        }

       
        public override string ToString()
        {
            return $"ID: {UserId}, Name: {UserName}, Email: {Email}, is Active: {IsActive}";
        }
        

        //private method that uses regular expression to check email
        //is called in Email property setter
        //returns true if email matches pattern, otherwise false
        private bool CheckEmail(string input)
        {
            // check if there are 1+ char then @ symbol,
            // then 1+ char . (dot) symbol and 1+ char
            string pattern = @"^\w+@\w+\.\w+$";
            return Regex.IsMatch(input, pattern);
        }
       
    }

