using FluentAssertions.Equivalency;
using Kata.Domain;
using System.Collections.Generic;

using System;

namespace Kata.UnitTests
{

    /// <summary>
    /// The maximum sum subarray problem consists in finding the maximum sum 
    /// of a contiguous subsequence in an array or list of integers:
    /// maxSequence [-2, 1, -3, 4, -1, 2, 1, -5, 4]
    /// -- should be 6: [4, -1, 2, 1]
    /// Easy case is when the list is made up of only positive numbers and the maximum 
    /// sum is the sum of the whole array.If the list is made up of only negative numbers, return 0 instead.
    /// Empty list is considered to have zero greatest sum. Note that the empty 
    /// list or array is also a valid sublist/subarray.
    /// </summary>
    public class MaxSequenceShould
    {
        //public static TheoryData<int, bool> DataForTest1 = new TheoryData<int, bool> {
        //    { 1, true },
        //    { 371, true }
        //};

        //[Theory]
        //[MemberData(nameof(DataForTest1))]
        //public void ReturnTrueWhenNumberIsNarcissistic(int number, bool result)
        //{
        //    var katas = new Katas();
        //    Assert.Equal(result, katas.Narcissistic(number));
        //}
        [Fact]
        public void ReturnZeroWhenArrayOnlyContainsOneZero()
        {
            var katas = new Katas();
            Assert.Equal(0, katas.MaxSequence(new int[0]));
        }

        [Fact]
        public void ReturnSixWhenArrayPredefined()
        {
            var katas = new Katas();
            Assert.Equal(6, katas.MaxSequence(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));
        }
    }
}