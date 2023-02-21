﻿namespace Api.SwaggerExamples.Requests.Items
{
    using System;
    using Application.Items.Commands.CreateItem;
    using Swashbuckle.AspNetCore.Filters;

    public class CreateItemRequestExample : IExamplesProvider<CreateItemCommand>
    {
        private const int Ten = 10;

        public CreateItemCommand GetExamples()
            => new CreateItemCommand
            {
                Title = "Some really expensive item",
                Description = "This item was found in 1980.",
                StartingPrice = 10000,
                MinIncrease = 1000,
                StartTime = DateTime.UtcNow.AddMinutes(Ten),
                EndTime = DateTime.UtcNow.AddDays(Ten),
                SubCategoryId = Guid.Parse("5AB7CAEF-9B24-4B6D-A7A5-08D7DFB08A49")
            };
    }
}