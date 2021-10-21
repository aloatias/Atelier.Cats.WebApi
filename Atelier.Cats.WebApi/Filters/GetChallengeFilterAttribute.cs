using Atelier.Cats.DataAccess.Entities;
using Atelier.Cats.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Atelier.Cats.WebApi.Filters
{
    public class GetChallengeFilterAttribute : SuccessResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await CheckResultAsync(context, next);

            var partialResult = ActionResult.Value as Challenge;
            var result = new ChallengeDto
            {
                Id = partialResult.Id,
                ChallengerOneId = partialResult.ChallengerOneId,
                ChallengerTwoId = partialResult.ChallengerTwoId,
                WinnerId = partialResult.WinnerId,
                VoteDate = partialResult.VoteDate
            };

            ActionResult.Value = result;
            await next();
        }
    }
}
