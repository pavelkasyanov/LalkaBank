using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DAO.Implementation;
using DAO.Interafaces;

namespace WebApp.Models.Validators
{
    public class PassportDateValidator : ValidationAttribute
    {
        private readonly ICreditDAO _creditDao = new CreditDAO();

        public PassportDateValidator()
        {
            ErrorMessage = "Invalid date format";
        }

        public PassportDateValidator(string ErrorMessage)
        {
            this.ErrorMessage = ErrorMessage;
        }

        public override bool IsValid(object value)
        {
            DateTime dtout;
            if (DateTime.TryParse(value?.ToString() ?? "", out dtout))
            {
                return dtout >= _creditDao.GetTimeTable().Date;
            }

            return false;
        }
    }
}