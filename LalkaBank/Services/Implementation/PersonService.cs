using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using DAO;
using DAO.Implemenation;
using DAO.Interafaces;
using Services.Interfaces;

namespace Services.Implemenations
{
    public class PersonService : IPersonService
    {
        [Obsolete("use other constructor")]
        public PersonService()
        {
            _passportDao = new PassportDAO();
            _personDao = new PersonDAO();
        }

        public PersonService(IPersonDAO personDao, IPassportDAO passportDao)
        {
            _personDao = personDao;
            _passportDao = passportDao;
        }

        public bool Create(Person person)
        {
            try
            {
                _personDao.CreateOrUpdate(person);

                _personDao.SaveToBase();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Person Get(Guid id)
        {
            try
            {
                return _personDao.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                _personDao.Delete(id);

                _personDao.SaveToBase();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Person> GetList()
        {
            try
            {
                return _personDao.GetList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool RegisterUser(Person person, Passport passport)
        {
            try
            {
                var pers = _personDao.Get(person.Id);
                if (pers != null)
                {
                    person.PassportId = pers.PassportId;
                    _personDao.Update(person);

                    var pass = _passportDao.Get(pers.PassportId);

                    passport.Id = pass.Id;
                    _passportDao.CreateOrUpdate(passport);

                    return true;
                }

                passport.Id = Guid.NewGuid();
                person.PassportId = passport.Id;

                _passportDao.CreateOrUpdate(passport);
                _personDao.CreateOrUpdate(person);

                _personDao.SaveToBase();

                return true;
            }
            catch (DbEntityValidationException e)
            {
                //foreach (var eve in e.EntityValidationErrors)
                //{
                //    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                //        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                //    foreach (var ve in eve.ValidationErrors)
                //    {
                //        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                //            ve.PropertyName, ve.ErrorMessage);
                //    }
                //}

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IsUserRegister(Guid userId)
        {
            var t = _personDao.Get(userId);
            return t != null;
        }

        private readonly IPersonDAO _personDao;
        private readonly IPassportDAO _passportDao;
    }
}
