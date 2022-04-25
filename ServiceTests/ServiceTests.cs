using NUnit.Framework;
using ValidationWebAPI.Services;

namespace ServiceTests;

public class Tests
{

    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void TestOneValid()
    {
        var inputData = "Richard 3293982\nXAEA-12 8293982";
        var responseData = "{\"fileValid\":false,\"invalidLines\":[\"Account Name,Account Number - not valid for 2 XAEA-12 8293982\"]}";

        ValidationService service = new ValidationService(new AccountInfoValidationEngine(),new ResultStorageProvider());
        Assert.AreEqual(service.ValidateAndGenerateResponse(inputData), responseData);
    }

    [Test]
    public void TestAllValid()
    {
        var inputData = "Richard 3293982\nAistis 4567890";
        var responseData = "{\"fileValid\":true,\"invalidLines\":[]}";

        ValidationService service = new ValidationService(new AccountInfoValidationEngine(), new ResultStorageProvider());
        Assert.AreEqual(service.ValidateAndGenerateResponse(inputData), responseData);
    }

    [Test]
    public void TestNoneValid()
    {
        var inputData = "Richard 3293982a\nAistis1 4567890";
        var responseData = "{\"fileValid\":false,\"invalidLines\":[\"Account Number - not valid for 1 Richard 3293982a\",\"Account Name - not valid for 2 Aistis1 4567890\"]}";

        ValidationService service = new ValidationService(new AccountInfoValidationEngine(), new ResultStorageProvider());
        Assert.AreEqual(service.ValidateAndGenerateResponse(inputData), responseData);
    }
}
