using System;
using NUnit.Framework;
using FluentAssertions;
using SteeringCS;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var vector = new Vector2D(4, 5);

            vector.Normalize().Should().BeEquivalentTo(new Vector2D(0.62, 0.78));
        }
    }
}