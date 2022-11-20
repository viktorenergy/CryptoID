using Xunit;

namespace CryptoID.Test;

public class CryptoIdentityTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(int.MaxValue)]
    public void EncryptionTest(int input)
    {
        string actualResult = CryptoIdentity.Encript(input);

        Assert.NotEmpty(actualResult);
        Assert.True(actualResult.Length >= 3);
    }

    [Theory]
    [InlineData("4nb", 1)]
    [InlineData("o7to9yy8-", int.MaxValue)]
    public void DecryptionTest(
        string input,
        int expectedResult)
    {
        int actualResult = CryptoIdentity.Decrypt(input);

        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    // All values a random
    [InlineData(1)]
    [InlineData(27)]
    [InlineData(394234)]
    [InlineData(256558456)]
    [InlineData(int.MaxValue)]
    public void EncryptDecryptTest(int input)
    {
        string encryptedResult = CryptoIdentity.Encript(input);
        int decryptedValue = CryptoIdentity.Decrypt(encryptedResult);

        Assert.Equal(decryptedValue, input);
    }
}