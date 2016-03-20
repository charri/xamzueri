using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using XamZueri.App.Utils;

namespace XamZueri.App.Tests.Utils
{
    [TestFixture]
    public class ODataRequestBuilderTests
    {
        [Test]
        public void When_Ordered_Test()
        {
            var builder = new ODataRequestBuilder<object>("http://www.example.com/").OrderBy("ID", "DESC");

            Assert.That(builder.Request.RequestUri.AbsoluteUri,
                Is.EqualTo("http://www.example.com/odata/Objects?$orderby=ID%20DESC"));
        }

        [Test]
        public void When_Skipped_Test()
        {
            var builder = new ODataRequestBuilder<object>("http://www.example.com/").Skip(20);

            Assert.That(builder.Request.RequestUri.AbsoluteUri,
                Is.EqualTo("http://www.example.com/odata/Objects?$skip=20"));
        }

        [Test]
        public void When_Single_Integer_Test()
        {
            var builder = new ODataRequestBuilder<object>("http://www.example.com/").Single(1);

            Assert.That(builder.Request.RequestUri.AbsoluteUri,
                Is.EqualTo("http://www.example.com/odata/Objects(1)"));
        }

        [Test]
        public void When_Single_Guid_Test()
        {
            var builder = new ODataRequestBuilder<object>("http://www.example.com/").Single(Guid.Empty);

            Assert.That(builder.Request.RequestUri.AbsoluteUri,
                Is.EqualTo($"http://www.example.com/odata/Objects(guid'{Guid.Empty}')"));
        }
    }
}
