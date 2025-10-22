using Domain.ValueObjects;

namespace DomainTests;

[TestClass]
public class TaxIdTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TaxIdConstr_WhiteSpace_AttendedError()
    {
        var taxId = new TaxId("     ");
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TaxIdConstr_null_AttendedError()
    {
        var taxId = new TaxId(null);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TaxIdConstr_LessThan16Chars_AttendedError()
    {
        var taxId = new TaxId("123456789012345");
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TaxIdConstr_MoreThan16Chars_AttendedError()
    {
        var taxId = new TaxId("12345678901234567");
    }
    [TestMethod]
    public void TaxIdConstr_ValidTaxId_NoError()
    {
        TaxId taxId = new TaxId("RSSMRA85M01H501U");
        Assert.AreEqual("RSSMRA85M01H501U", taxId.Value);
    }
}
