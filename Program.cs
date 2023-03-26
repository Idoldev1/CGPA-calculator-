 using System;
using System.Collections.Generic;

class Course {
    public string grade;
    public int creditHour;

    public Course(string grade, int creditHour) {
        this.grade = grade;
        this.creditHour = creditHour;
    }
}

class CGPACalculator {
    public static double CalculateCGPA(List<Course> courses) {
        int totalCreditHours = 0;
        double totalGradePoints = 0;

        foreach (Course course in courses) {
            int gradePoint = GetGradePoint(course.grade);
            totalCreditHours += course.creditHour;
            totalGradePoints += gradePoint * course.creditHour;
        }

        return totalGradePoints / totalCreditHours;
    }

    private static int GetGradePoint(string grade) {
        switch (grade) {
            case "A+": return 4;
            case "A": return 4;
            case "A-": return (int)3.67;
            case "B+": return (int)3.33;
            case "B": return 3;
            case "B-": return (int)2.67;
            case "C+": return (int)2.33;
            case "C": return 2;
            case "C-": return (int)1.67;
            case "D+": return (int)1.33;
            case "D": return 1;
            case "F": return 0;
            default: throw new ArgumentException("Invalid grade");
        }
    }
}

class Program {
    static void Main() {
        List<Course> courses = new List<Course>();

        Console.Write("Enter the number of courses: ");
        int numCourses = int.Parse(Console.ReadLine());

        for (int i = 0; i < numCourses; i++) {
            Console.Write($"Enter grade for course {i+1}: ");
            string grade = Console.ReadLine().ToUpper();

            Console.Write($"Enter credit hour for course {i+1}: ");
            int creditHour = int.Parse(Console.ReadLine());

            courses.Add(new Course(grade, creditHour));
        }

        double cgpa = CGPACalculator.CalculateCGPA(courses);

        Console.WriteLine($"Your CGPA is: {cgpa:F2}");
    }
} 