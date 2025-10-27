namespace DomainTests;

[TestClass]
public class PhoneNumberTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void PhoneNumberConstr_NullValue_ExpectedError()
    {
        var phoneNumber = new Domain.ValueObjects.PhoneNumber(null);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void PhoneNumberConstr_EmptyValue_ExpectedError()
    {
        var phoneNumber = new Domain.ValueObjects.PhoneNumber(string.Empty);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void PhoneNumberConstr_InvalidFormat_NonDigitChar_ExpectedError()
    {
        var phoneNumber = new Domain.ValueObjects.PhoneNumber("123-456");
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void PhoneNumberConstr_InvalidFormat_LessThan7Char_ExpectedError()
    {
        var phoneNumber = new Domain.ValueObjects.PhoneNumber("12345");
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void PhoneNumberConstr_InvalidFormat_WhiteSpace_ExpectedError()
    {
        var phoneNumber = new Domain.ValueObjects.PhoneNumber("      ");
    }
    [TestMethod]
    public void PhoneNumberConstr_ValidFormat_CorrectCreation()
    {
        var phoneNumber = new Domain.ValueObjects.PhoneNumber("1234567");
        Assert.AreEqual("1234567", phoneNumber.Value);
    }

}
