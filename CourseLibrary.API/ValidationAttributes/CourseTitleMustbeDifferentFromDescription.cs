using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.ValidationAttributes
{
    public class CourseTitleMustbeDifferentFromDescription : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var course = (Models.CourseForCreateDto)validationContext.ObjectInstance;
            if (course.Title == course.Description)
            {
                return new ValidationResult("The discription and title cannot be same", new[] { "courseForCreateDto" });
            }
            return ValidationResult.Success;
        }
    }
}
