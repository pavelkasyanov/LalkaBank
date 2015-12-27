using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.Interfaces;

namespace WebApp.Controllers
{
    [Authorize]
    public class ImagesController : Controller
    {
        private readonly IPassportService _passportService;
        private readonly IRequestService _requestService;

        public ImagesController(IPassportService passportService, 
            IRequestService requestService)
        {
            _passportService = passportService;
            _requestService = requestService;
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

        public ActionResult Garantor(Guid id)
        {
            var request = _requestService.Get(id);
            if (request == null)
            {
                return HttpNotFound("passport image not fount");
            }

            var image = request.GuarantorImage;
            
            return File(image, "image/jpg");
        }

        public ActionResult Income(Guid id)
        {
            var request = _requestService.Get(id);
            if (request == null)
            {
                return HttpNotFound("passport image not fount");
            }

            var image = request.IncomeImage;

            return File(image, "image/jpg");
        }
    }
}