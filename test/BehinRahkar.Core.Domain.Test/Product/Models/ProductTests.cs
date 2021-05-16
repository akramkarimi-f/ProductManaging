using BehinRahkar.Domain.AggregatesModel.ProductAggregate;
using BehinRahkar.Domain.Exceptions;
using FluentAssertions;
using System;
using Xunit;

namespace BehinRahkar.Domain.Test
{
    public class ProductTests
    {
        [Fact]
        public void RightSenario()
        {
            var product = new Product("483158", "name", 123, "photo", "356fghfgu567df");

            product.Code.Should().Be("483158");
            product.Name.Should().Be("name");
            product.Price.Value.Should().Be(123);
            product.Photo.FileName.Should().Be("photo");
            product.ModifierUserId.Should().Be("356fghfgu567df");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void RightSenario_PhotoIsNullOrEmpty(string photo)
        {
            var product = new Product("483158", "name", 123, photo);

            product.Code.Should().Be("483158");
            product.Name.Should().Be("name");
            product.Price.Value.Should().Be(123);
            product.Photo.Should().Be(null);
            product.ModifierUserId.Should().Be(null);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void CodeShouldNotBeNullOrEmpty(string code)
        {
            Assert.Throws<ArgumentIsNullOrEmptyException>(() => new Product(code, "name", 123, null));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void NameShouldNotBeNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentIsNullOrEmptyException>(() => new Product("48313158", name, 123, null));
        }

    }
}
