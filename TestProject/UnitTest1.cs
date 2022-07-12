using LeetCode_8_StringToInteger;

namespace TestProject
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("1", 1)]
        [InlineData("+1", 1)]
        [InlineData("-1", -1)]
        [InlineData("  -1", -1)]
        [InlineData("  -123 Main St.", -123)]
        [InlineData("  123 Main St.", 123)]
        [InlineData("  001234 Main St.", 1234)]
        [InlineData("  +0012345 Main St.", 12345)]
        [InlineData("+00123456", 123456)]
        [InlineData("999999999999", 2147483647)]
        [InlineData("-999999999999", -2147483648)]
        [InlineData("should return 0 -999999999999", 0)]
        public void ReturnIntegerFromString(string strNum, int expectedResult)
        {
            // Arrange
            Class1 class1 = new Class1();

            // Act
            int actualResult = class1.MyAtoi(strNum);

            // Assert
            Assert.Equal(expectedResult, actualResult);

        }
    }
}