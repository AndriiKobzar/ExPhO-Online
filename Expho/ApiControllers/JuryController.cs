using System.Collections.Generic;
using System.Web.Http;
using ExPho.Core.Helpers;
using ExPhO.Core.Entities;
using System.Net.Http;
using System.Net;

namespace ExPho
{
    public class JuryController : ApiController
    {
        JuryHelper _helper = new JuryHelper();

        [HttpGet]
        [Route("jury/all")]
        public List<Jury> GetAllJuries(int olympiadId)
        {
            return _helper.GetAllByOlympiad(olympiadId);
        }

        [HttpPost]
        [Route("jury/mark")]
        public HttpResponseMessage PutMark(PutMarkModel model)
        {
            _helper.PutMark(model.olympiadId, model.teamId, model.problemId, model.mark);
            return new HttpResponseMessage((HttpStatusCode)200);
        }
    }

    public class PutMarkModel
    {
        public int olympiadId { get; set; }
        public int teamId { get; set; }
        public int problemId { get; set; }
        public double mark { get; set; }
    }
}