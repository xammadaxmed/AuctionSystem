﻿namespace Application.UnitTests.Mappings
{
    using Application.Admin.Queries.List;
    using Application.Bids.Commands.CreateBid;
    using Application.Bids.Queries.Details;
    using Application.Categories.Queries.List;
    using Application.Items.Commands.CreateItem;
    using Application.Items.Queries.Details;
    using Application.Items.Queries.List;
    using Application.Pictures;
    using Application.Pictures.Queries;
    using AutoMapper;
    using Domain.Entities;
    using FluentAssertions;
    using Xunit;

    public class MappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IMapper mapper;

        public MappingTests(MappingTestsFixture fixture)
        {
            this.mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldMap_AuctionUser_To_ListAllUsersResponseModel()
        {
            var entity = new AuctionUser();

            var result = this.mapper.Map<ListAllUsersResponseModel>(entity);

            result.Should().NotBeNull();
            result.Should().BeOfType<ListAllUsersResponseModel>();
        }

        [Fact]
        public void ShouldMap_Bid_To_GetHighestBidDetailsResponseModel()
        {
            var entity = new Bid();

            var result = this.mapper.Map<GetHighestBidDetailsResponseModel>(entity);

            result.Should().NotBeNull();
            result.Should().BeOfType<GetHighestBidDetailsResponseModel>();
        }

        [Fact]
        public void ShouldMap_Category_To_ListCategoriesResponseModel()
        {
            var entity = new Category();

            var result = this.mapper.Map<ListCategoriesResponseModel>(entity);

            result.Should().NotBeNull();
            result.Should().BeOfType<ListCategoriesResponseModel>();
        }

        [Fact]
        public void ShouldMap_CreateBidCommand_To_Bid()
        {
            var entity = new CreateBidCommand();

            var result = this.mapper.Map<Bid>(entity);

            result.Should().NotBeNull();
            result.Should().BeOfType<Bid>();
        }

        [Fact]
        public void ShouldMap_CreateItemCommand_To_Item()
        {
            var entity = new CreateItemCommand();

            var result = this.mapper.Map<Item>(entity);

            result.Should().NotBeNull();
            result.Should().BeOfType<Item>();
        }

        [Fact]
        public void ShouldMap_Item_To_ListItemDetailsResponseModel()
        {
            var entity = new Item();

            var result = this.mapper.Map<ItemDetailsResponseModel>(entity);

            result.Should().NotBeNull();
            result.Should().BeOfType<ItemDetailsResponseModel>();
        }

        [Fact]
        public void ShouldMap_Item_To_ListItemsResponseModel()
        {
            var entity = new Item();

            var result = this.mapper.Map<ListItemsResponseModel>(entity);

            result.Should().NotBeNull();
            result.Should().BeOfType<ListItemsResponseModel>();
        }

        [Fact]
        public void ShouldMap_Picture_To_PictureDetailsResponseModel()
        {
            var entity = new Picture();

            var result = this.mapper.Map<PictureDetailsResponseModel>(entity);

            result.Should().NotBeNull();
            result.Should().BeOfType<PictureDetailsResponseModel>();
        }

        [Fact]
        public void ShouldMap_Picture_To_PictureResponseModel()
        {
            var entity = new Picture();

            var result = this.mapper.Map<PictureResponseModel>(entity);

            result.Should().NotBeNull();
            result.Should().BeOfType<PictureResponseModel>();
        }

        [Fact]
        public void ShouldMap_SubCategory_To_SubCategoriesDto()
        {
            var entity = new SubCategory();

            var result = this.mapper.Map<SubCategoriesDto>(entity);

            result.Should().NotBeNull();
            result.Should().BeOfType<SubCategoriesDto>();
        }
    }
}