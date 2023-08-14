using System;
using MySpot.Core.ValueObjects;
using Shouldly;
using Xunit;

namespace MySpot.Tests.Unit.ValueObjects;

public class WeekTests
{
    [Theory]
    [InlineData("2023-08-13", "2023-08-07", "2023-08-13")]
    [InlineData("2023-08-14", "2023-08-14", "2023-08-20")]
    [InlineData("2023-08-15", "2023-08-14", "2023-08-20")]
    [InlineData("2023-08-16", "2023-08-14", "2023-08-20")]
    [InlineData("2023-08-17", "2023-08-14", "2023-08-20")]
    [InlineData("2023-08-18", "2023-08-14", "2023-08-20")]
    [InlineData("2023-08-19", "2023-08-14", "2023-08-20")]
    [InlineData("2023-08-20", "2023-08-14", "2023-08-20")]
    [InlineData("2023-08-21", "2023-08-21", "2023-08-27")]
    public void given_datetime_offset_should_create_proper_week(
        string dateString, string fromDateString, string toDateString)
    {
        var dateTime = DateTime.Parse(dateString);
        
        var week = new Week(dateTime);
        
        week.From.Value.ToString("yyyy-MM-dd").ShouldBe(fromDateString);
        week.To.Value.ToString("yyyy-MM-dd").ShouldBe(toDateString);
    }
}