// See https://aka.ms/new-console-template for more information

public delegate void GradeAddedDelegate(object sender, EventArgs args);

public class InMemoryBook : Book
{
    private List<double> grades;

    public const string CATEGORY = "Science";

    public InMemoryBook(string name) : base(name)
    {
        // grades = new List<double>();
        Name = name;
    }

    public override void AddGrade(double grade)
    {
        if (grade <= 100 && grade >= 0)
        {
            grades.Add(grade);
            if (GradeAdded != null)
            {
                GradeAdded(this, new EventArgs());
            }
        }
        else
        {
            throw new ArgumentException($"Invalid {nameof(grade)}");
        }
    }

    public override event GradeAddedDelegate GradeAdded;

    public override Statistics GetStatistics()
    {
        var result = new Statistics();

        // foreach (var grade in grades)
        // {
        //     if (grade < result.Low)
        //     {
        //         result.Low = grade;
        //     }
        //     result.High = Math.Max(grade, result.High);
        //     result.Average += grade;
        // }
        // result.Average /= grades.Count;

        for (var i = 0; i < grades.Count; i++)
        {
            result.Add(grades[i]);
        }

        return result;
    }
}