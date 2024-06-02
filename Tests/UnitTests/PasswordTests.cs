using Domain;
using ViaEventAssociation.Core.Tools.OperationResult;

namespace UnitTests;

/* Rules:
    Must be between 8 and 24 characters
    Must contain at least one lower case letter
    Must contain at least one upper case letter
    Must contain at least one digit
    Must contain at least one of the following symbols: #, !, _, ?, +, -
*/

public class PasswordTests
{
    [Fact]
    public void Can_Create_Valid_Password()
    {
        // Arrange
        string input = "Troels12!";


        // Act
        Result<Password> created = Password.Create(input);

        // Assert
        Assert.True(created.IsSuccess);
        Assert.Equal(input, created.Value.Value);
    }

    [Theory]
    [InlineData("Troels1!")]
    [InlineData("Ek!0_fjke#5")]
    [InlineData("S0m3_wh3r3_!z_Gr43t")]
    [InlineData("S0m3_wh3r3_!z_Gr43t_1234")]
    public void Can_Create_Password_With_Valid_Number_of_Characters(string arg)
    {
        // Arrange
        string input = arg;

        // Act
        Result<Password> result = Password.Create(input);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(input, result.Value.Value);
    }
}