using FluentAssertions.Equivalency;
using Kata.Domain;

using Interval = System.ValueTuple<int, int>;
namespace Kata.UnitTests
{
    /// <summary>
    ///    Write a function called sumIntervals/sum_intervals that accepts an array of intervals, and returns the sum of all the interval lengths.Overlapping intervals should only be counted once.
    ///    Intervals
    ///    Intervals are represented by a pair of integers in the form of an array.The first value of the interval will always be less than the second value.Interval example: [1, 5] is an interval from 1 to 5. The length of this interval is 4.
    ///    Overlapping Intervals
    ///    List containing overlapping intervals:
    ///[
    ///       [1, 4],
    ///       [7, 10],
    ///       [3, 5]
    ///]
    ///The sum of the lengths of these intervals is 7. Since[1, 4] and[3, 5] overlap, we can treat the interval as [1, 5], which has a length of 4.
    ///Examples:
    ///sumIntervals([
    ///   [1, 2],
    ///   [6, 10],
    ///   [11, 15]
    ///] ) => 9
    ///sumIntervals([
    ///   [1, 4],
    ///   [7, 10],
    ///   [3, 5]
    ///] ) => 7
    ///sumIntervals([
    ///   [1, 5],
    ///   [10, 20],
    ///   [1, 6],
    ///   [16, 19],
    ///   [5, 11]
    ///] ) => 19
    ///sumIntervals([
    ///   [0, 20],
    ///   [-100000000, 10],
    ///   [30, 40]
    ///] ) => 100000030
    ///Tests with large intervals
    ///Your algorithm should be able to handle large intervals.All tested intervals are subsets of the range[-1000000000, 1000000000].
    /// </summary>
    public class SumIntervalsShould
    {

        private Katas _katas;
        public SumIntervalsShould()
        {
            _katas = new Katas();
        }
        [Fact]
        public void ShouldHandleEmptyIntervals()
        {
            Assert.Equal(0, _katas.SumIntervals(new Interval[] { }));
            Assert.Equal(0, _katas.SumIntervals(new Interval[] { (4, 4), (6, 6), (8, 8) }));
        }

        [Fact]
        public void ShouldAddDisjoinedIntervals()
        {
            Assert.Equal(9, _katas.SumIntervals(new Interval[] { (1, 2), (6, 10), (11, 15) }));
            Assert.Equal(11, _katas.SumIntervals(new Interval[] { (4, 8), (9, 10), (15, 21) }));
            Assert.Equal(7, _katas.SumIntervals(new Interval[] { (-1, 4), (-5, -3) }));
            Assert.Equal(78, _katas.SumIntervals(new Interval[] { (-245, -218), (-194, -179), (-155, -119) }));
        }

        [Fact]
        public void ShouldAddAdjacentIntervals()
        {
            Assert.Equal(54, _katas.SumIntervals(new Interval[] { (1, 2), (2, 6), (6, 55) }));
            Assert.Equal(23, _katas.SumIntervals(new Interval[] { (-2, -1), (-1, 0), (0, 21) }));
        }

        [Fact]
        public void ShouldAddOverlappingIntervals()
        {
            Assert.Equal(7, _katas.SumIntervals(new Interval[] { (1, 4), (7, 10), (3, 5) }));
            Assert.Equal(6, _katas.SumIntervals(new Interval[] { (5, 8), (3, 6), (1, 2) }));
            Assert.Equal(19, _katas.SumIntervals(new Interval[] { (1, 5), (10, 20), (1, 6), (16, 19), (5, 11) }));
        }

        [Fact]
        public void ShouldHandleMixedIntervals()
        {
            Assert.Equal(13, _katas.SumIntervals(new Interval[] { (2, 5), (-1, 2), (-40, -35), (6, 8) }));
            Assert.Equal(1234, _katas.SumIntervals(new Interval[] { (-7, 8), (-2, 10), (5, 15), (2000, 3150), (-5400, -5338) }));
            Assert.Equal(158, _katas.SumIntervals(new Interval[] { (-101, 24), (-35, 27), (27, 53), (-105, 20), (-36, 26) }));
        }

        [Fact]
        public void ShouldHandleLargeIntervals()
        {
            Assert.Equal(2_000_000_000, _katas.SumIntervals(new Interval[] { (-1_000_000_000, 1_000_000_000) }));
            Assert.Equal(100_000_030, _katas.SumIntervals(new Interval[] { (0, 20), (-100_000_000, 10), (30, 40) }));
        }
    }
}