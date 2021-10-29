using Atelier.Cats.Contracts;
using Atelier.Cats.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Atelier.Cats.Infrastructure.Presentation.Filters
{
    public class CatFilterAttribute : ResultFilterAttribute
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

            var partialResult = actionResult.Value as Cat;
            var result = new CatDto
            {
                Id = partialResult.Id,
                AtelierId = partialResult.AtelierId,
                Url = partialResult.Url,
                CreationDate = partialResult.CreationDate,
                LastUpdate = partialResult.LastUpdate
            };

            actionResult.Value = result;
            await next();
        }
    }
}
