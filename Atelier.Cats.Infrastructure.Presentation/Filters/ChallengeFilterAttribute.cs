using Atelier.Cats.Contracts;
using Atelier.Cats.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Atelier.Cats.Infrastructure.Presentation.Filters
{
    public class ChallengeFilterAttribute : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var actionResult = context.Result as ObjectResult;
            if (actionResult?.Value == null
                || actionResult?.StatusCode < 200
                || actionResult?.StatusCode >= 300)
            {
                await next();
                return;
            }

            var partialResult = actionResult.Value as Challenge;
            var result = new ChallengeDto
            {
                Id = partialResult.Id,
                ChallengerOneId = partialResult.ChallengerOneId,
                ChallengerTwoId = partialResult.ChallengerTwoId,
                WinnerId = partialResult.WinnerId,
                VoteDate = partialResult.VoteDate
            };

            actionResult.Value = result;
            await next();
        }
    }
}
