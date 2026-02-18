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
    
    [TestCase("hello", "hello")]
    [TestCase("", "")]
    [TestCase("a", "a")]
    [TestCase("one two three", "three two one")]
    [TestCase("one  two three", "three two  one")]
    [TestCase(" one two three", "three two one ")]
    [TestCase("one two three ", " three two one")]
    [TestCase("one_two_three", "three_two_one")]
    [TestCase("one two_three", "three_two one")]
    [TestCase("one\ntwo\nthree", "three\ntwo\none")]
    public void ReverseWords_ReturnsExpectedString(string input, string expected)
    {
        // Act
        var result = _svc.Reverse(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ReverseWords_NullString_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<System.ArgumentNullException>(() => _svc.Reverse(null));
    }
}
