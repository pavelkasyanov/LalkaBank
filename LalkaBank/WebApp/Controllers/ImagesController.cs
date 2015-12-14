using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.Interfaces;

namespace WebApp.Controllers
{
    public class ImagesController : Controller
    {
        private readonly IPassportService _passportService;

        public ImagesController(IPassportService passportService)
        {
            _passportService = passportService;
        }

        // GET: Images
        public ActionResult PasportImage(Guid id)
        {
            var passport = _passportService.Get(id);
            if (passport == null)
            {
                return HttpNotFound("passport image not fount");
            }

            var image = passport.Image;

            return File(image, "image/jpg");
        }
    }
}