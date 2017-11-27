using System;
using Autofac;
using Autofac.Core;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Blob;
using Moq;

namespace Automoq_AzureSdk
{
    [TestClass]
    public class AutomoqAzureStorageTests
    {
        [TestMethod]
        public void AutoMoqNamedParameter()
        {
            var uri = new Uri("http://localhost");
            using (var mock = AutoMock.GetStrict())
            {
                Parameter[] p = { new NamedParameter("baseUri", uri) };
                var blobClientMock = mock.Mock<CloudBlobClient>(p);

                blobClientMock.Setup(m => m.GetContainerReference(It.IsAny<string>())).Returns((CloudBlobContainer)null);
            }
        }

        [TestMethod]
        public void AutoMoqIndexParameter()
        {
            var uri = new Uri("http://localhost");
            using (var mock = AutoMock.GetStrict())
            {
                Parameter[] p = { new PositionalParameter(0, uri) };
                var blobClientMock = mock.Mock<CloudBlobClient>(p);

                blobClientMock.Setup(m => m.GetContainerReference(It.IsAny<string>())).Returns((CloudBlobContainer)null);
            }
        }


        [TestMethod]
        public void PureMoq()
        {
            var uri = new Uri("http://localhost");
            var blobClientMock = new Mock<CloudBlobClient>(uri);
            Parameter[] p = { new PositionalParameter(0, uri) };
            blobClientMock.Setup(m => m.GetContainerReference(It.IsAny<string>())).Returns((CloudBlobContainer)null);
        }
    }
}
