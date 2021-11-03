﻿using Atelier.Cats.Application.Interfaces;
using Atelier.Cats.Contracts;
using Atelier.Cats.Domain.Entities;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atelier.Cats.Infrastructure.Presentation.Filters
{
    public class WinnersFilterAttribute : ResultFilterAttribute
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

            var result = new List<WinnerResultDto>();

            (actionResult.Value as IAtelierResponse<List<Cat>>)?
                .Content?
                .ForEach(challenge =>
                {
                    var fakeCatName = new Faker<WinnerResultDto>()
                        .RuleFor(x => x.Name, (f, u) => f.Name.FirstName())
                        .Generate()
                        .Name;

                    result.Add
                    (
                        new WinnerResultDto
                        {
                            AtelierId = challenge.AtelierId,
                            WinnerId = challenge.Id,
                            Name = fakeCatName,
                            Url = challenge.Url,
                            Votes = challenge.ChallengesWinner.Count()
                        }
                    );
                });

            actionResult.Value = result;
            await next();
        }
    }
}
