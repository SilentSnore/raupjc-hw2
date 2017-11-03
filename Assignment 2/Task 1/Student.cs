namespace Task_1
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }
        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public bool Equals(Student other)
        {
            if (object.ReferenceEquals(other, null)) return false;
            return this.Jmbag.Equals(other.Jmbag);
        }

        public override bool Equals(object obj)
        {
            var otherStudent = obj as Student;
            if (object.ReferenceEquals(otherStudent, null)) return false;
            return this.Jmbag.Equals(otherStudent.Jmbag);
        }

        public override int GetHashCode()
        {
            return this.Jmbag.GetHashCode();
        }

        public static bool operator ==(Student leftStudent, Student rightStudent)
        {
            if (object.ReferenceEquals(leftStudent, null) || object.ReferenceEquals(rightStudent, null)) return false;
            return leftStudent.Jmbag.Equals(rightStudent.Jmbag);
        }

        public static bool operator !=(Student leftStudent, Student rightStudent)
        {
            if (object.ReferenceEquals(leftStudent, null) || object.ReferenceEquals(rightStudent, null)) return false;
            return !leftStudent.Jmbag.Equals(rightStudent.Jmbag);
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
