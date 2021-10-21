using Atelier.Cats.DataAccess.Entities;
using Atelier.Cats.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atelier.Cats.WebApi.Filters
{
    public class GetWinnersFilterAttribute : SuccessResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await CheckResultAsync(context, next);

            var result = new List<WinnerResultDto>();

            (ActionResult.Value as List<Cat>).ForEach(challenge =>
            {
                result.Add
                (
                    new WinnerResultDto
                    {
                        AtelierId = challenge.AtelierId,
                        WinnerId = challenge.Id,
                        Url = challenge.Url,
                        Victories = challenge.ChallengesWinner.Count
                    }   
                );
            });

            ActionResult.Value = result;
            await next();
        }
    }
}
