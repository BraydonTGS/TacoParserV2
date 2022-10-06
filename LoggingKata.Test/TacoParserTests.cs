using System;
namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNotNull()
        {
            // Making sure that the value returned is Not Null //
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        public void ShouldParseLongitude(string line, double expected)
        {

            // Returning an Itrackable and Checking the Longitude CSV //

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse(line);

            //Assert
            Assert.Equal(expected, actual.Location.Longitude);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        public void ShouldParseLatitude(string line, double expected)
        {
            // Returning an Itrackable and Checking the Latitude CSV //

            // Arrange //
            var tacoParser = new TacoParser();
            // Act //
            var actual = tacoParser.Parse(line);
            // Assert //

            Assert.Equal(expected, actual.Location.Latitude);
        }
    }
}
