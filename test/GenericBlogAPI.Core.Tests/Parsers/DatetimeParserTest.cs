using System;
using FluentAssertions;
using GenericBlogAPI.Core.Parsers;
using NUnit.Framework;

namespace GenericBlogAPI.Core.Tests.Parsers
{
    [TestFixture]
    public class DatetimeParserTest
    {
        private IDatetimeParser _datetimeParser;

        [SetUp]
        public void Init()
        {
            _datetimeParser = new DatetimeParser();
        }

        [Test]
        public void Should_ParseStringValue_ToDatetimeObject()
        {
            const string datetimeAsString = "2015-01-01 15:15:20";

            var expected = new DateTime(2015, 1, 1, 15, 15, 20);

            var obtained = _datetimeParser.ParseFromStringValue(datetimeAsString);

            obtained.Should().Be(expected);
        }

        [Test]
        public void Should_ParseStringValue_With_MM_YYYY_DD_Dateformat_ToDatetimeObject()
        {
            const string datetimeAsString = "01-2015-30 15:15:20";

            var expected = new DateTime(2015, 1, 30, 15, 15, 20);

            var obtained = _datetimeParser.ParseFromStringValue(datetimeAsString);

            obtained.Should().Be(expected);
        }
    }
}