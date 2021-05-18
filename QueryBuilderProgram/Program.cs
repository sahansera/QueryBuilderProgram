using System;
using System.Collections.Generic;
using System.Linq;

namespace QueryBuilderProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<User>
            {
                new() {Gender = Gender.Male, IsActive = true, Age = 25},
                new() {Gender = Gender.Male, IsActive = false, Age = 21},
                new() {Gender = Gender.Female, IsActive = false, Age = 50},
                new() {Gender = Gender.Female, IsActive = true, Age = 29},
            };

            var maleOver25s = users
                .WhichAreActive()
                .WithGender(Gender.Male)
                .WithAgeGreaterThan(25)
                .ToList();
            
            Console.WriteLine(maleOver25s.Count);
        }
    }
    
    public static class UserPredicates
    {
        public static IEnumerable<User> WithGender(this IEnumerable<User> users, Gender gender) => users.Where(u => u.Gender == gender);
        public static IEnumerable<User> WhichAreActive(this IEnumerable<User> users) => users.Where(u => u.IsActive);
        public static IEnumerable<User> WithAgeGreaterThan(this IEnumerable<User> users, int age) => users.Where(user => user.Age >= age);
    }

    public enum Gender
    {
        Male,
        Female
    }

    public class User
    {
        public Gender Gender { get; set; }
        public bool IsActive { get; set; }
        public int Age { get; set; }
    }
}