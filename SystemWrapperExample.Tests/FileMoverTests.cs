using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FluentAssertions;
using NUnit.Framework;
using NSubstitute;
using Ploeh.AutoFixture;
using Progenity.Test.Utility;

namespace SystemWrapperExample.Tests
{
    public class FileMoverTests : BaseTest
    {
        private FileMover _sut;
        private const string SourceDirectory = @"C:\Temp\testing";
        private static readonly string DestinationDirectory = $@"{SourceDirectory}\moved";

        [SetUp]
        public void SetUp()
        {
            _sut = new FileMover();
            Directory.CreateDirectory(SourceDirectory);
            Directory.CreateDirectory(DestinationDirectory);
        }

        [TearDown]
        public void TearDown()
        {
            Directory.Delete(DestinationDirectory, true);
            Directory.Delete(SourceDirectory, true);
        }

        [Test, CategoryIntegration]
        public void VerifyTheFileWasMoved()
        {
            var fileName = "foo.txt";
            var filePath = $@"{SourceDirectory}\{fileName}";
            File.Create(filePath).Close();
            _sut.Move(filePath, DestinationDirectory);

            Directory.EnumerateFiles(DestinationDirectory, fileName)
                .Any()
                .Should()
                .BeTrue();
        }
    }
}
