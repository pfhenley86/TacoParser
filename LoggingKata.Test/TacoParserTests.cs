using System;
using System.Runtime.InteropServices;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.071477,-84.296345,Taco Bell Alpharett...", -84.296345)]
        [InlineData("33.635282,-86.684056,Taco Bell Birmingham...", -86.684056)]
        [InlineData("34.996237,-85.291147,Taco Bell Chattanooga...", -85.291147)]
        //Add additional inline data. Refer to your CSV file.
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Longitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location
            
            //Arrange
            var tester = new TacoParser();
            
            //Act
            var pointInfo = tester.Parse(line);
            var actual = pointInfo.Location.Longitude;
            
            //Assert
            Assert.Equal(expected, actual);

            
        }


        //TODO: Create a test called ShouldParseLatitude

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("34.071477,-84.296345,Taco Bell Alpharett...", 34.071477)]
        [InlineData("33.635282,-86.684056,Taco Bell Birmingham...", 33.635282)]
        [InlineData("34.996237,-85.291147,Taco Bell Chattanooga...", 34.996237)]
        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange
            var tester = new TacoParser();
            
            //Act
            var pointInfo = tester.Parse(line);
            var actual = pointInfo.Location.Latitude;
            
            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
