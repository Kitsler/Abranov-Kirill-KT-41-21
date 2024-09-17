using Project.Models;

namespace Project_Test
{
    public class GroupTests
    {
        [Fact]
        public void IsValidGroupName_KT4121_True()
        {
            //arrange
            var testGroup = new Group
            {
                GroupName = "KT-41-21"
            };

            //act
            var result = testGroup.IsValidGroupName();

            //assert
            Assert.True(result);
        }
    }
}
