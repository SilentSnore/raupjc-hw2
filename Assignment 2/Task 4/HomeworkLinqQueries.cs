using System.Collections.Generic;
using System.Linq;
using Task_1;

namespace Task_4
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            return intArray
                .GroupBy(number => number)
                .OrderBy(group => group.Key)
                .Select(group => "Broj " + group.Key + " ponavlja se " + group.Count() + " puta")
                .ToArray();
        }

        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray
                .Where(university => university.Students.All(student => student.Gender.Equals(Gender.Male)))
                .ToArray();
        }

        public static University[] Linq2_2(University[] universityArray)
        {
            return universityArray
                .Where(university => university.Students.Count() < universityArray.Average(uni => uni.Students.Count()))
                .ToArray();
        }

        public static Student[] Linq2_3(University[] universityArray)
        {
            return universityArray
                .SelectMany(uni => uni.Students)
                .Distinct()
                .ToArray();
        }

        public static Student[] Linq2_4(University[] universityArray)
        {
            return universityArray
                .Where(uni =>
                    uni.Students.All(student => student.Gender.Equals(Gender.Male)) ||
                    uni.Students.All(s => s.Gender.Equals(Gender.Female)))
                .SelectMany(uni => uni.Students)
                .Distinct()
                .ToArray();
        }

        public static Student[] Linq2_5(University[] universityArray)
        {
            return universityArray
                .SelectMany(uni => uni.Students)
                .GroupBy(student => student)
                .Select(group => new
                {
                    Stud = group.Key,
                    Counter = group.Count()
                })
                .Where(s => s.Counter >= 2)
                .Select(s => s.Stud)
                .ToArray();
        }
    }
}
