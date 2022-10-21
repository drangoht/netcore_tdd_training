using FluentAssertions.Equivalency;
using Kata.Domain;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Numerics;
using System;

namespace Kata.UnitTests
{
    /// <summary>
    /// A format for expressing an ordered list of integers is to use a comma separated list of either
    /// individual integers
    /// or a range of integers denoted by the starting integer separated from the end integer in the range by a dash, '-'. The range includes all integers in the interval including both endpoints.It is not considered a range unless it spans at least 3 numbers.For example "12,13,15-17"
    /// Complete the solution so that it takes a list of integers in increasing order and returns a correctly formatted string in the range format.
    ///    Example:
    /// solution([-10, -9, -8, -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20]);
    /// returns "-10--8,-6,-3-1,3-5,7-11,14,15,17-20"
    /// Courtesy of rosettacode.org
    /// </summary>
    public class RangeExtractionShould
    {

        [Theory]

    [InlineData("1,2", new[] { 1, 2 })]
    [InlineData("1-3", new[] { 1, 2, 3 })]
    [InlineData("-6,-3-1,3-5,7-11,14,15,17-20", new[] { -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20 })]
    [InlineData("-3--1,2,10,15,16,18-20", new[] { -3, -2, -1, 2, 10, 15, 16, 18, 19, 20 })]
    public void ReturnCorrectRanges(string result, int[] numbers )
        {
            var katas = new Katas();
            Assert.Equal(result, katas.RangeExtraction(numbers));
        }
    }
}