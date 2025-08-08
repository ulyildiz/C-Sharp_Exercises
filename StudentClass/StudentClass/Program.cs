class Student
{
    public string name { get; set; }
    public string surname;
    public string IDnumber;
    public string email;
    public string enrollmentDate;
    public string faculty;
    public string major;
    private double gpa;
    public List<string> activeCourses;

    public void AddCourse(string course)
    {
        activeCourses.Add(course);
    }
    public void RemoveCourse(string course)
    {
        activeCourses.Remove(course);
    }

}

class Program
{
    public void Main()
    {
        Student ali = new Student();

        ali.name = "Ali";
        ali.surname = "Yıldız";

        Student mehmet = new Student();

        mehmet.name = "Mehmet";
        mehmet.surname = "Yılmaz";

        Student ayse = new Student();
    
        ayse.name = "Ayşe";
        ayse.surname = "Demir";
    }
}