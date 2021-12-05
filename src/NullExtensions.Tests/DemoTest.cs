using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NullExtensions.Tests {
    public class DemoTest {
        [Fact]
        public void Demo() {
            int? one = 1;
            int? none = null;

            one.NSelect(x => x + 1).Should().Be(2);
            none.NSelect(x => x + 1).Should().BeNull();

            one.NWhere(x => x == 1).Should().Be(1);
            one.NWhere(x => x == 2).Should().BeNull();

            one.NSelectMany(x => x == 1 ? 2 : default(int?)).Should().Be(2);
            one.NSelectMany(x => x == 2 ? 3 : default(int?)).Should().BeNull();
            
            one.NForEach(Console.WriteLine); // prints "1"
            none.NSwitch(
                some: x => Console.WriteLine(x),
                none: () => Console.WriteLine("null")
            ); // prints "null"
            one.NSwitch(
                some: _ => "some",
                none: () => "none"
            ).Should().Be("some");
            
            new[] { 1, default(int?), 3 }.NFlatten().Should().BeEquivalentTo(new[] { 1, 3 });

            string? GetTagName(string s) => s.StartsWith('<') && s.EndsWith('>') ? s[1..^1] : null; // "<div>" -> "div"
            new[] { "<div>", "<br>", "imposter" }.NChoose(GetTagName).Should().BeEquivalentTo(new[] { "div", "br" });
        }
    }
}