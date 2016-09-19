using System.Collections.Generic;
using Expho.Core.Entities;
using Expho.Core.Helpers;

namespace Expho
{
    public class JuryController : ApiController
    {
        JuryHelper _helper = new JuryHelper();

        public List<Jury> GetAllJuries(int olympiadId)
        {
            return _helper.GetAllByOlympiad(olympiadId);
        }

        [HttpPost]
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