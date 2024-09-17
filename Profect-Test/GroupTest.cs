using System.Text.RegularExpressions;


namespace Profect_Test
{
    public class GroupTests
    {
        [Fact]
        public void IsValidGroupName_KT3120_True()
        {
            //arrange
            var testGroup = new Group
            {
                GroupName = "��-41-21"
            };

            //act
            var result = testGroup.IsValidGroupName();

            //assert
            Assert.True(result);
        }
    }
}