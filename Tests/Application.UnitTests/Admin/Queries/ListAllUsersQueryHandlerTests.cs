﻿namespace Application.UnitTests.Admin.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Admin.Queries.List;
    using AuctionSystem.Infrastructure.Identity;
    using AutoMapper;
    using Common.Interfaces;
    using Common.Models;
    using Domain.Entities;
    using FluentAssertions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Setup;
    using Xunit;

    [Collection("QueryCollection")]
    public class ListAllUsersQueryHandlerTests
    {
        private readonly IAuctionSystemDbContext context;
        private readonly IMapper mapper;
        private readonly IUserManager userManagerService;
        private readonly Mock<UserManager<AuctionUser>> mockedUserManager;

        public ListAllUsersQueryHandlerTests(QueryTestFixture fixture)
        {
            this.context = fixture.Context;
            this.mapper = fixture.Mapper;
            this.mockedUserManager = IdentityMocker.GetMockedUserManager();

            this.userManagerService = new UserManagerService(
                this.mockedUserManager.Object,
                IdentityMocker.GetMockedRoleManager().Object,
                this.context);
        }

        [Fact]
        public async Task GetUsers_Should_Return_Correct_Count()
        {
            this.mockedUserManager
                .Setup(x => x.GetUsersInRoleAsync(AppConstants.AdministratorRole))
                .ReturnsAsync(new List<AuctionUser> { new AuctionUser { Id = Guid.NewGuid().ToString() } });
            var handler = new ListAllUsersQueryHandler(this.context, this.mapper, this.userManagerService);

            var result = await handler.Handle(new ListAllUsersQuery(), CancellationToken.None);

            result
                .Should()
                .BeOfType<PagedResponse<ListAllUsersResponseModel>>();

            result
                .Data
                .Should()
                .HaveCount(await this.context.Users.CountAsync());
        }
    }
}