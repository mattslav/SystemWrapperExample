using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemInterface;
using FluentAssertions;
using NUnit.Framework;
using NSubstitute;
using Ploeh.AutoFixture;
using Progenity.Test.Utility;

namespace SystemWrapperExample.Tests
{
    public class CreatePlateParametersBuilderWithWrappersTests : BaseTest
    {
        private CreatePlateParametersBuilderWithWrappers _sut;
        private IDateTime _mockDateTime;

        [SetUp]
        public void SetUp()
        {
            _mockDateTime = Substitute.For<IDateTime>();
            _sut = new CreatePlateParametersBuilderWithWrappers(_mockDateTime);
        }

        [Test, CategoryUnit]
        public void TheCurrentTimeIsRetrieved()
        {
            _sut.Build(Fixture.Create<string>());

            var notUsed = _mockDateTime
                .Received()
                .Now;
        }

        [Test, CategoryUnit]
        public void MyTestMethod()
        {
            var barcode = Fixture.Create<string>();
            var currentTime = Fixture.Create<DateTime>();

            _mockDateTime
                .Now.DateTimeInstance
                .Returns(currentTime);

            var expectedValue = new CreatePlateParameters
            {
                Barcode = barcode,
                Active = true,
                CreatedBy = "System",
                CreatedTimestamp = currentTime
            };
            
            _sut.Build(barcode)
                .ShouldBeEquivalentTo(expectedValue);
        }
    }
}
