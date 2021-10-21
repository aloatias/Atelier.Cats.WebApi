using Atelier.Cats.DataAccess.Entities;
using Atelier.Cats.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Atelier.Cats.WebApi.Filters
{
    public class GetCatFilterAttribute : SuccessResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await CheckResultAsync(context, next);

            var partialResult = ActionResult.Value as Cat;
            var result = new CatDto
            {
                Id = partialResult.Id,
                AtelierId = partialResult.AtelierId,
                Url = partialResult.Url,
                CreationDate = partialResult.CreationDate,
                LastUpdate = partialResult.LastUpdate
            };

            ActionResult.Value = result;
            await next();
        }
    }
}
