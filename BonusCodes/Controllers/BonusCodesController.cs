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

        [HttpPost, Route]
        public IHttpActionResult IsValid( [FromBody] string bonusCode)
        {
            if (bonusCode == null)
                return BadRequest();

            try
            {
                var isValid = bonusCodesService.IsValid(bonusCode);
                if (!isValid)
                    return Ok("not-valid");

                var alreadyExists = bonusCodesService.AlreadyExists(bonusCode);
                if (alreadyExists)
                    return Ok("already-exists");

                bonusCodesService.Add(bonusCode);
                return Ok("added");
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
