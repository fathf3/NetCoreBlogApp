﻿using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace BlogApp.Service.Extensions
{
    public static class FluentValidationExtensions
    {
        public static void AddModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
