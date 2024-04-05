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
    
    [Fact]
    public void AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail()
    {
        // Arrange
        var userService = new UserService();

        //Act
        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalskikowalcom",
            DateTime.Parse("2000-01-01"),
            1
        );             

        //Assert
        Assert.False(result); 
    }
    
    [Fact]
    public void AddUser_ReturnsFalseWhenYoungerThen21YearsOld()
    {
        // Arrange
        var userService = new UserService();

        //Act
        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Parse("2008-01-01"),
            1
        );             

        //Assert
        Assert.False(result); 
    }
    
    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
        // Arrange
        var userService = new UserService();

        //Act
        var result = userService.AddUser(
            "VeryImportantClient",
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            1
        );             

        //Assert
        Assert.False(result); 
    }
   
    // AddUser_ReturnsTrueWhenVeryImportantClient
    
    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        // Arrange
        var userService = new UserService();

        //Act
        var result = userService.AddUser(
            "ImportantClient",
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            1
        );             

        //Assert
        Assert.False(result); 
    }
    // AddUser_ReturnsTrueWhenImportantClient
    
    [Fact]
    public void AddUser_ReturnsTrueWhenNormalClient()
    {
        // Arrange
        var userService = new UserService();

        //Act
        var result = userService.AddUser(
            "ImportantClient",
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            1
        );             

        //Assert
        Assert.False(result); 
    }
    // AddUser_ReturnsTrueWhenNormalClient
    
    
    // AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit
    
    
    // AddUser_ThrowsExceptionWhenUserDoesNotExist
    // AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser
    
    [Fact]
    public void AddUser_ThrowsExceptionWhenUserDoesNotExist()
    {
        // Arrange
        var userService = new UserService();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => userService.AddUser(
            "Nonexistent", 
            "User", 
            "nonexistentuser@example.com", 
            DateTime.Parse("1980-01-01"), 
            999));
    }

}