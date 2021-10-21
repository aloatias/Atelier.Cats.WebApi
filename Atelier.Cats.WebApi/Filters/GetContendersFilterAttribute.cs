using Atelier.Cats.DataAccess.Entities;
using Atelier.Cats.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace Atelier.Cats.WebApi.Filters
{
    public class GetContendersFilterAttribute : SuccessResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await CheckResultAsync(context, next);

            var partialResult = ActionResult.Value as Tuple<Cat, Cat>;
            var result = new ContendersCoupleDto
            {
                ContenderOne = new ContenderDto
                {
                    Id = partialResult.Item1.Id,
                    AtelierId = partialResult.Item1.AtelierId,
                    Url = partialResult.Item1.Url
                },

                ContenderTwo = new ContenderDto
                {
                    Id = partialResult.Item2.Id,
                    AtelierId = partialResult.Item2.AtelierId,
                    Url = partialResult.Item2.Url
                }
            };

            ActionResult.Value = result;
            await next();
        }
    }
}
