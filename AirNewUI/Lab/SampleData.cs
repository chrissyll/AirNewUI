using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirNewUI.Lab
{
    static class SampleData
    {
        public static List<Student> Students { get; set; }

        public static void Seed()
        {
            Students = new List<Student>()
            {
                new Student { Id = 1, Name = "John", Age = 24, HasMarried = true },
                new Student { Id = 2, Name = "Owen", Age = 23, HasMarried = false },
                new Student { Id = 3, Name = "Joanna", Age = 32, HasMarried = true },
                new Student { Id = 4, Name = "Catherine", Age = 38, HasMarried = true },
                new Student { Id = 5, Name = "Tommy", Age = 21, HasMarried = false },
                new Student { Id = 6, Name = "Leo", Age = 31, HasMarried = false },
                new Student { Id = 7, Name = "Amy", Age = 26, HasMarried = false },
                new Student { Id = 8, Name = "Emily", Age = 28, HasMarried = true }
            };
        }
    }
}
