using Domain.ValueObjects;

namespace DomainTests;

[TestClass]
public class EmailTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void EmailConstr_NullValue_ExpectedError()
    {
        var email = new Email(null!);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void EmailConstr_EmptyValue_ExpectedError()
    {
        var email = new Email(string.Empty);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void EmailConstr_NoAtSymbol_ExpectedError()
    {
        var email = new Email("userdomain.com");
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void EmailConstr_NoDotSymbol_ExpectedError()
    {
        var email = new Email("user@domaincom");
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void EmailConstr_MultipleAtSymbols_ExpectedError()
    {
        var email = new Email("user@@domain.com");
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void EmailConstr_DotBeforeAtSymbol_ExpectedError()
    {
        var email = new Email("user.domain@com");
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void EmailConstr_DotImmediatelyAfterAt_ExpectedError()
    {
        var email = new Email("user@.com");
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void EmailConstr_DotAtEnd_ExpectedError()
    {
        var email = new Email("user@domain.");
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void EmailConstr_AtAtEnd_ExpectedError()
    {
        var email = new Email("user@domain@");
    }
    [TestMethod]
    public void EmailConstr_CorrectEmail_AssertEqual()
    {
        Email mail = new Email("user@domain.com");
        Assert.AreEqual(mail.Value, "user@domain.com");
    }
}
