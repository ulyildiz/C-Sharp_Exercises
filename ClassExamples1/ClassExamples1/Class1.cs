namespace ClassExamples1
{
    public class Student
    {
        public string StudentID { get; set; } = "00000000";
        public bool StudentActivity { get; set; } = true; // true = active, false = inactive  
        public string Name { get; set; } = "";
        public sbyte Grade { get; set; } = 0; // 1-4  
        public string Department { get; set; } = "";
        public string Faculty { get; set; } = "";
        public double GPA { get; set; } = 0.0; // 0.0 - 4.0
        public List<ValueTuple<string, double, double>> ActiveCourses { get; private set; } = new List<ValueTuple<string, double, double>>(); // Course name, course grade, course weight
        public List<ValueTuple<string, double, double>> PassedCourses { get; private set; } = new List<ValueTuple<string, double, double>>();
        public string EntryTime { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        public Student() { } // Default constructor

        public Student (string studentID, string name, sbyte grade, string department, string faculty)
        {
            StudentID = studentID;
            Name = name;
            Grade = grade;
            Department = department;
            Faculty = faculty;
        }

        public Student(string studentID, string name, sbyte grade, string department, string faculty, List<ValueTuple<string, double, double>> passedCourses)
        {
            StudentID = studentID;
            Name = name;
            Grade = grade;
            Department = department;
            Faculty = faculty;
            PassedCourses = passedCourses;
        }

        public Student(string studentID, string name, sbyte grade, string department, string faculty, List<ValueTuple<string, double, double>> passedCourses, List<ValueTuple<string, double, double>> activeCourses)
        {
            StudentID = studentID;
            Name = name;
            Grade = grade;
            Department = department;
            Faculty = faculty;
            PassedCourses = passedCourses;
            ActiveCourses = activeCourses;
        }


        public double checkGPA()
        {
            if (StudentActivity)
            {
                if (PassedCourses.Count > 0)
                {
                    GPA = PassedCourses.Sum(course => course.Item2 * course.Item3) / PassedCourses.Sum(course => course.Item3);
                }
                else
                {
                    GPA = 0.0;
                }
            }
            return GPA;
        }
        public bool EnrollCourse(string courseName, double courseWeight)
        {
            if (StudentActivity && !ActiveCourses.Any(course => course.Item1 == courseName))
            {
                ActiveCourses.Add(ValueTuple.Create(courseName, -1.0, courseWeight));
                return true;
            }
            return false;
        }
        public bool PassedCourse(string courseName, double courseGrade)
        {
            if (StudentActivity && ActiveCourses.Any(course => course.Item1 == courseName))
            {
                PassedCourses.Add(ValueTuple.Create(courseName, courseGrade, ActiveCourses.First(course => course.Item1 == courseName).Item3));
                ActiveCourses.RemoveAll(course => course.Item1 == courseName);
                GPA = PassedCourses.Sum(course => course.Item2 * course.Item3) / PassedCourses.Sum(course => course.Item3);
                return true;
            }
            return false;
        }

        public void ChangeStudentActivity()
        {
            StudentActivity = !StudentActivity;
        }
    }
}
