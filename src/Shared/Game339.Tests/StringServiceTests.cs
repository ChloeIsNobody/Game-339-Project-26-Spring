using Game339.Shared.Services.Implementation;
using NUnit.Framework;

namespace Game339.Tests;

public class StringServiceTests
{
    private StringService _svc;

    [SetUp]
    public void SetUp()
    {
        _svc = new StringService(EmptyGameLog.Instance);
    }

    [TestCase("hello", "olleh")]
    [TestCase("", "")]
    [TestCase("a", "a")]
    [TestCase("racecar", "racecar")]
    public void Reverse_ReturnsExpectedString(string input, string expected)
    {
        // Act
        var result = _svc.Reverse(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Reverse_NullString_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<System.ArgumentNullException>(() => _svc.Reverse(null));
    }
    
    [DatapointSource]
    public static readonly char[] cases = [' ', '\n', '\r'];

    [Test]
    public void ReverseWords_Test_Null()
    {
        // Act & Assert
        Assert.Throws<System.ArgumentNullException>(() => _svc.ReverseWords(null));
    }
    
    [Test, TestCaseSource(nameof(cases))]
    public void ReverseWords_Test_ZeroWords(char separator)
    {
        char s = separator;
        
        List<(string input, string output)> tests = [("", ""), ($"{s}", $"{s}"), ($"{s}{s}", $"{s}{s}"), ($"{s} ", $" {s}")];

        foreach (var test in tests)
        {
            var result = _svc.ReverseWords(test.input);
            
            Assert.That(result, Is.EqualTo(test.output));
        }
    }
    
    [Test, TestCaseSource(nameof(cases))]
    public void ReverseWords_Test_OneWords(char separator)
    {
        char s = separator;
        
        List<(string input, string output)> tests = [
            ("one", "one"), ($"one'", $"one'"), ($"one's", $"one's"),
            ($"{s}one", $"one{s}"), ($"one{s}", $"{s}one"), ($"{s}one{s}", $"{s}one{s}")
        ];

        foreach (var test in tests)
        {
            var result = _svc.ReverseWords(test.input);
            
            Assert.That(result, Is.EqualTo(test.output));
        }
    }
    
    [Test, TestCaseSource(nameof(cases))]
    public void ReverseWords_Test_TwoWords(char separator)
    {
        char s = separator;
        
        List<(string input, string output)> tests = [
            ($"one{s}two", $"two{s}one"),
            ($"one{s}two{s}", $"{s}two{s}one"),
            ($"{s}one{s}two", $"two{s}one{s}"),
            ($"one_two", $"one_two")
        ];

        foreach (var test in tests)
        {
            var result = _svc.ReverseWords(test.input);
            
            Assert.That(result, Is.EqualTo(test.output));
        }
    }
    
    [Test, TestCaseSource(nameof(cases))]
    public void ReverseWords_Test_ThreeWords(char separator)
    {
        char s = separator;
        
        List<(string input, string output)> tests = [
            ($"one{s}two{s}three", $"three{s}two{s}one"),
            ($"one{s}two{s}{s}three", $"three{s}{s}two{s}one"),
            ($"one_two three", $"three one_two"),
            ($"one{s}two{s} three", $"three {s}two{s}one")
        ];

        foreach (var test in tests)
        {
            var result = _svc.ReverseWords(test.input);
            
            Assert.That(result, Is.EqualTo(test.output));
        }
    }
}
