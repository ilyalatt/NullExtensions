# NullExtensions

[![NuGet version](https://shields.io/nuget/vpre/NullExtensions)](https://www.nuget.org/packages/NullExtensions)

## Quick start

```C#
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
```

## Why

Libraries like [LanguageExt](https://github.com/louthy/language-ext) are heavy.
I prefer to use [Nullable.Extensions](https://github.com/bert2/Nullable.Extensions).
However it interfers with existing methods like `Select` and you can get confusing compilation errors.
So I decided to create a lightweight library that has nullable extensions prefixed with `N` letter.
It tries to follow LINQ style naming.
It fits the feeling that nullable types are equivalent to empty or single element collections.
