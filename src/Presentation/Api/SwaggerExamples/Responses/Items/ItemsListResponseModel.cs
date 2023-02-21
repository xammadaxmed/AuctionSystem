﻿namespace Api.SwaggerExamples.Responses.Items
{
    using System;
    using System.Collections.Generic;
    using Application.Common.Models;
    using Application.Items.Queries.List;
    using Application.Pictures;
    using Swashbuckle.AspNetCore.Filters;

    public class ItemsListResponseModel : IExamplesProvider<PagedResponse<ListItemsResponseModel>>
    {
        public PagedResponse<ListItemsResponseModel> GetExamples()
            => new PagedResponse<ListItemsResponseModel>
            {
                PageNumber = 1,
                PageSize = 3,
                Data = new List<ListItemsResponseModel>
                {
                    new ListItemsResponseModel
                    {
                        Id = Guid.NewGuid(),
                        Title = "Some random title 1",
                        Description = "Some random description 1",
                        StartingPrice = 500m,
                        MinIncrease = 10m,
                        StartTime = DateTime.UtcNow.AddDays(20),
                        EndTime = DateTime.UtcNow.AddDays(21),
                        UserId = Guid.NewGuid().ToString(),
                        UserFullName = "test@test.com",
                        Pictures = new List<PictureResponseModel>
                        {
                            new PictureResponseModel { Id = Guid.NewGuid(), Url = "Some example url here" }
                        }
                    },
                    new ListItemsResponseModel
                    {
                        Id = Guid.NewGuid(),
                        Title = "Some random title 2",
                        Description = "Some random description 1",
                        StartingPrice = 500m,
                        MinIncrease = 10m,
                        StartTime = DateTime.UtcNow.AddDays(50),
                        EndTime = DateTime.UtcNow.AddDays(55),
                        UserId = Guid.NewGuid().ToString(),
                        UserFullName = "test1@test.com",
                        Pictures = new List<PictureResponseModel>
                        {
                            new PictureResponseModel { Id = Guid.NewGuid(), Url = "Some example url here 2" }
                        }
                    },
                    new ListItemsResponseModel
                    {
                        Id = Guid.NewGuid(),
                        Title = "Some random title 3",
                        Description = "Some random description 1",
                        StartingPrice = 500m,
                        MinIncrease = 10m,
                        StartTime = DateTime.UtcNow.AddDays(100),
                        EndTime = DateTime.UtcNow.AddDays(110),
                        UserId = Guid.NewGuid().ToString(),
                        UserFullName = "test2@test.com"
                    }
                }
            };
    }
}