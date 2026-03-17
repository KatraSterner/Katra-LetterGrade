namespace LetterGrade.Api.Controllers;

using Microsoft.AspNetCore.Mvc;

using Services;
using Core.Models;



[ApiController]
[Route("api/grades/calculate")]
public class GradesController(GradeCalculatorService gradeCalculatorService) : ControllerBase
{
    [HttpPost]
    public ActionResult<LetterGrade> CalculateGrade([FromBody] float grade)
    {
        if (grade < 0)
        {
            return BadRequest("Grade cannot be less than zero percent.");
        }

        var response = new LetterGrade
        {
            GradePercentage = grade,
            Letter = gradeCalculatorService.CalcLetterGrade(grade)
        };
        
        return Ok(response);
    }
}