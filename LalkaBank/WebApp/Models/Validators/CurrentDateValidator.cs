using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DAO.Implementation;
using DAO.Interafaces;
using Services.Implemenations;
using Services.Interfaces;

namespace WebApp.Models.Validators
{
    public class BirthDateValidator : ValidationAttribute
    {
        private readonly ICreditDAO _creditDao = new CreditDAO();

        public BirthDateValidator()
        {
            ErrorMessage = "Invalid date format";
        }

        public BirthDateValidator(string ErrorMessage)
        {
            this.ErrorMessage = ErrorMessage;
        }

        public override bool IsValid(object value)
        {
            DateTime dtout;
            if (DateTime.TryParse(value?.ToString() ?? "", out dtout))
            {
                return dtout <= _creditDao.GetTimeTable().Date;
            }

            return false;
        }
    }
}