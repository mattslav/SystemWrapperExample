using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemInterface.IO;
using FluentAssertions;
using NUnit.Framework;
using NSubstitute;
using Ploeh.AutoFixture;
using Progenity.Test.Utility;

namespace SystemWrapperExample.Tests
{
    public class FileMoverWithWrappersTests : BaseTest
    {
        private FileMoverWithWrappers _sut;
        private IDirectory _mockDirectory;
        private IPath _mockPath;
        private IFile _mockFile;

        [SetUp]
        public void SetUp()
        {
            _mockDirectory = Substitute.For<IDirectory>();
            _mockPath = Substitute.For<IPath>();
            _mockFile = Substitute.For<IFile>();
            _sut = new FileMoverWithWrappers(_mockDirectory, _mockPath, _mockFile);
        }

        [Test, CategoryUnit]
        public void TheDestinationDirectoryIsCreated()
        {
            var destinationDirectory = Fixture.Create<string>();

            _sut.Move(Fixture.Create<string>(), destinationDirectory);

            _mockDirectory
                .Received()
                .CreateDirectory(destinationDirectory);
        }

        [Test, CategoryUnit]
        public void TheFileNameIsRetrieved()
        {
            var filePath = Fixture.Create<string>();

            _sut.Move(filePath, Fixture.Create<string>());

            _mockPath
                .Received()
                .GetFileName(filePath);
        }

        [Test, CategoryUnit]
        public void TheFileIsMoved()
        {
            var fileName = Fixture.Create<string>();
            var filePath = Fixture.Create<string>();
            var destinationDirectory = Fixture.Create<string>();

            _mockPath
                .GetFileName(Arg.Any<string>())
                .Returns(fileName);

            _sut.Move(filePath, destinationDirectory);

            _mockFile
                .Received()
                .Move(filePath, $@"{destinationDirectory}\{fileName}");
        }
    }
}
