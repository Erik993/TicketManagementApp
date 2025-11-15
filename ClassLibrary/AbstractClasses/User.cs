using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace AbtractClasses;

public abstract class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [MaxLength(100)]
    public string UserName { get; set; }

    //setter calls method to check if email has valid structure
    [Required]
    public string Email { get; set;}

    [Required]
    public bool IsActive { get; set; } 

    public User() { }

    //email is validated in contructor via SetEmail method
    public User(string name, string email, bool isactive)
    {
        UserName = name;
        SetEmail(email); 
        IsActive = isactive;
    }

    public void SetEmail(string input)
    {
        if(!IsValidEmail(input))
            throw new ArgumentException($"{input} is not valid email.");
        Email = input;
    }


    private bool IsValidEmail(string input)
    {
        try
        {
            var addr = new MailAddress(input);
            return addr.Address == input;
        }
        catch
        {
            return false;
        }

    }


    public override string ToString()
    {
        return $"ID: {UserId}, Name: {UserName}, Email: {Email}, is Active: {IsActive}";
    }

}

