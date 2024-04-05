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

        // Act
        userService.AddUser(
            "Jan",
            "Malewski",
            "malewski@gmail.pl",
            DateTime.Parse("2000-01-01"),
            2
        );

        var result = userService.client.Type.Equals("VeryImportantClient");

        // Assert
        Assert.True(result);
    }           
    
    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        // Arrange
        var userService = new UserService();

        // Act
        userService.AddUser(
            "Jan",
            "Smith",
            "smith@gmail.pl",
            DateTime.Parse("2000-01-01"),
            3
        );

        var result = userService.client.Type.Equals("ImportantClient");

        // Assert
        Assert.True(result);
    }
    [Fact]
    public void AddUser_ReturnsTrueWhenNormalClient()
    {
        // Arrange
        var userService = new UserService();

        // Act
        userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@gmail.pl",
            DateTime.Parse("2000-01-01"),
            1
        );

        var result = userService.client.Type.Equals("NormalClient");

        // Assert
        Assert.True(result);
    }
    
    
   [Fact]
    public void AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser()
    {
        // Arrange
        var userService = new UserService();

        // Act
        Action action = () =>
        {
            userService.AddUser(
                "Jan",
                "Andrzejewicz",
                "andrzejewicz@wp.pl",
                DateTime.Parse("2000-01-01"),
                6
            );
        };

        // Assert
        Assert.Throws<ArgumentException>(action);
    }
    
    [Fact]
    public void AddUser_ThrowsExceptionWhenUserDoesNotExist()
    {
        // Arrange
        var userService = new UserService();

        // Act
        Action action = () =>
        {
            userService.AddUser(
                "Jan",
                "Swift",
                "swift@wp.pl",
                DateTime.Parse("2000-01-01"),
                1000
            );
        };

        // Assert
        Assert.Throws<ArgumentException>(action);
    }

}