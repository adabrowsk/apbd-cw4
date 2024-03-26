namespace LegacyApp.Tests;

public class UserServiceTest
{
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
    {
        // Arrange
        var userService = new UserService();

        //Act
        var result = userService.AddUser(
            null,
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            1
       );             

        //Assert
        Assert.False(result); //equal do innych wartosci, false tylko do bool ofc
    }
    
    [Fact]
    public void AddUser_ThrowsExceptionWhenClientDoesNotExist()
    {
        // Arrange
        var userService = new UserService();

        //Act
        Action action = () => {userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            100
        ); };
        
        //Assert
        Assert.Throws<ArgumentException>(action);
    }
    
    
    // AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail
    // AddUser_ReturnsFalseWhenYoungerThen21YearsOld
    // AddUser_ReturnsTrueWhenVeryImportantClient
    // AddUser_ReturnsTrueWhenImportantClient
    // AddUser_ReturnsTrueWhenNormalClient
    // AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit
    // AddUser_ThrowsExceptionWhenUserDoesNotExist
    // AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser

}