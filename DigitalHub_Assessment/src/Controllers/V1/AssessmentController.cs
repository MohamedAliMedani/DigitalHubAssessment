using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.Controllers;
using src.GenericRepo;
using src.Helpers;
using src.Model;
using src.ModelDTO;

namespace Assessment.Controllers.V1
{
    [ApiVersion("1.0")]
    public class AssessmentController : ApiBaseController
    {
        private readonly ResponseDTO _responseDTO;
        private readonly IGRepository<AssessmentQuestion> _assessmentQuestionRepo;
        private readonly ILogger<AssessmentController> _logger;
        private readonly InstabugBackendContext _db;

        public AssessmentController(ILogger<AssessmentController> logger, InstabugBackendContext db,
         IHttpContextAccessor context, IGRepository<AssessmentQuestion> assessmentQuestionRepo)
        {
            _responseDTO = new ResponseDTO();
            _logger = logger;
            _db = db;
            _assessmentQuestionRepo = assessmentQuestionRepo;
        }

        [HttpGet("{enrolId}")]
        public async Task<ResponseDTO> Get(ulong enrolId)
        {
            try
            {
                var questions = await _assessmentQuestionRepo.GetAll()
                    .Include(q => q.AssessmentQuestionsRelations)
                    .Include(q => q.AssessmentOptions)
                    .Include(q => q.AssessmentMatches)
                    .Include(q => q.AssessmentTexts)
                    .Include(q => q.AssessmentTrueFalses)
                    .Where(q => q.AssessmentQuestionsRelations.Any(qr => qr.QuestionId == enrolId))
                    .Select(q => new AssessmentDTO
                    {
                        Id = q.Id,
                        Type = q.Type,
                        Answer = q.Type == "ms" ? string.Join(",", q.AssessmentOptions.Where(x => x.Correct).Select(x => x.Id)) :
                        q.Type == "mc" ? string.Join(",", q.AssessmentOptions.FirstOrDefault(x => x.Correct).Id) :
                        q.Type == "match" ? string.Join(",", q.AssessmentMatches.Select(m => new { question = m.QuestionId, answer = m.Answer }).ToList()) :
                        q.Type == "fill" ? string.Join(",", q.AssessmentMatches.Select(m => new { question = m.QuestionId, answer = m.Answer }).ToList()) :
                        q.Type == "long" ? string.Join(",", q.AssessmentTexts.Select(x => x.Answer)) :
                        q.Type == "short" ? string.Join(",", q.AssessmentTexts.Select(x => x.Answer)) :
                        q.Type == "true_false" ? string.Join(",", q.AssessmentTrueFalses.FirstOrDefault().IsTrue == 1 ? "True" : "False") :
                        null
                    })
                    .ToListAsync();

                _responseDTO.Result = questions;
                _responseDTO.StatusEnum = StatusEnum.Success;
                _responseDTO.Message = "AssessmentsRetrievedSuccessfully";
            }
            catch (Exception ex)
            {
                _responseDTO.Result = null;
                _responseDTO.StatusEnum = StatusEnum.Exception;
                _responseDTO.Message = "anErrorOccurredPleaseContactSystemAdministrator";
                _logger.LogError(ex, ex.Message, (ex != null && ex.InnerException != null ? ex.InnerException.Message : ""));
            }
            return _responseDTO;
        }
    }
}