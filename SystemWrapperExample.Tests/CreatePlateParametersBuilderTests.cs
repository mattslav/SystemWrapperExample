using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using NUnit.Framework;
using NSubstitute;
using Ploeh.AutoFixture;
using Progenity.Test.Utility;

namespace SystemWrapperExample.Tests
{
    public class CreatePlateParametersBuilderTests : BaseTest
    {
        private CreatePlateParametersBuilder _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new CreatePlateParametersBuilder();
        }

        [Test, CategoryUnit]
        public void MyTestMethod()
        {
            var barcode = Fixture.Create<string>();

            var expectedValue = new CreatePlateParameters
            {
                Barcode = barcode,
                Active = true,
                CreatedBy = "System",
                CreatedTimestamp = DateTime.Now
            };

            const int dateTimeAllowedDifferenceInMilliseconds = 5000;

            _sut.Build(barcode)
                .ShouldBeEquivalentTo(expectedValue, options =>
                    options.Using<DateTime>(ctx => ctx.Subject.Should().BeCloseTo(ctx.Expectation, dateTimeAllowedDifferenceInMilliseconds)).WhenTypeIs<DateTime>()
                    );
        }
    }
}
