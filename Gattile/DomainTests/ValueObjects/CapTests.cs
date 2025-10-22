using Domain.ValueObjects;

namespace DomainTests;

[TestClass]
public class CapTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CapConstr_WhiteSpaces_ExpectedError()
    {
        var cap = new Cap("     ");
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CapConstr_LessThan5Chars_ExpectedError()
    {
        var cap = new Cap("1234");
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CapConstr_MoreThan5Chars_ExpectedError()
    {
        var cap = new Cap("123456");
    }
    [TestMethod]
    public void CapConstr_ValidCap_NoError() 
    {
        Cap cap = new Cap("12435");
        Assert.AreEqual("12435", cap.Value);
    }
}
