namespace LetterGrade.Api.Services;

public class GradeCalculatorService
{
    public string CalcLetterGrade(float gradePercentage)
    {
        if (gradePercentage < 0)
        {
            return "Invalid Grade Percentage. Grade cannot be below 0.";
        }

        string letterGrade = gradePercentage switch
        {
            >= 90 => "A",
            >= 80 => "B",
            >= 70 => "C",
            >= 60 => "D",
            _ => "F"
        };
        
        return letterGrade;
    }
}