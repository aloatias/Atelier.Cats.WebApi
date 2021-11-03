using Atelier.Cats.Application.Interfaces;
using Atelier.Cats.Contracts;
using Atelier.Cats.Domain.Entities;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace Atelier.Cats.Infrastructure.Presentation.Filters
{
    public class ContendersFilterAttribute : ResultFilterAttribute
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

            var partialResult = actionResult.Value as Tuple<Cat, Cat>;

            var fakeCatNames = new Faker<WinnerResultDto>()
                    .RuleFor(x => x.Name, (f, u) => f.Name.FirstName())
                    .Generate(2);

            var result = new ContendersCoupleDto
            {
                ContenderOne = new ContenderDto
                {
                    Id = partialResult.Item1.Id,
                    AtelierId = partialResult.Item1.AtelierId,
                    Name = fakeCatNames[0].Name,
                    Url = partialResult.Item1.Url
                },

                ContenderTwo = new ContenderDto
                {
                    Id = partialResult.Item2.Id,
                    AtelierId = partialResult.Item2.AtelierId,
                    Name = fakeCatNames[1].Name,
                    Url = partialResult.Item2.Url
                }
            };

            actionResult.Value = result;
            await next();
        }
    }
}
