using System;
using System.Web.Http;
using BonusCodes.Services;

namespace BonusCodes.Controllers
{
    [RoutePrefix("api/bonus-code")]
    public class BonusCodesController : ApiController
    {
        private readonly IBonusCodesService bonusCodesService;

        public BonusCodesController(IBonusCodesService bonusCodesService)
        {
            if (bonusCodesService == null) throw new ArgumentNullException("bonusCodesService");
            this.bonusCodesService = bonusCodesService;
        }

        [HttpGet, Route("{code}")]
        public IHttpActionResult IsValid(string code)
        {
            var isValid = bonusCodesService.IsValid(code);
            if (!isValid)
                return Ok("not-valid");

            var alreadyExists = bonusCodesService.AlreadyExists(code);
            if (alreadyExists)
                return Ok("already-exists");

            bonusCodesService.Add(code);
            return Ok("added");
        }
    }
}
