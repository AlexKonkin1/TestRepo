using Xunit;
using RobotClassLibrary;
using System.Text;
using System;

namespace RobotTestUnit
{
    public class StepRobotTest
    {
        private WalkingArea HelperStringToArea(string topRight, string smels)
        {
            var arr = topRight.Split(' ');
            WalkingArea result = WalkingArea.CreateByUpperRightPos(int.Parse(arr[0]), int.Parse(arr[1]));
            arr = smels.Split(' ');
            foreach (var itemArr in arr)
            {
                if(!string.IsNullOrEmpty(itemArr))
                {     
                    var arrsm = itemArr.Split(',');
                    result.AddPositionWithSmell(new PositiontObject(int.Parse(arrsm[0]), int.Parse(arrsm[1])));
                }
            }
            return result;
        }

        private StepRobot HelperStringToRobot(string s, WalkingArea walkingArea)
        {
            var arr = s.Split(' ');
            return new StepRobot(int.Parse(arr[0]), int.Parse(arr[1]), Enum.Parse<PositionOrientedObject.OrientationEnum>(arr[2]), walkingArea);
        }

        private AbstractсCommand? HelperStringToCommand(string s)
        {
            AbstractсCommand result = null;
            switch (s)
            {
                case "F":
                    result = new ForwardCommand();
                    break;
                case "R":
                    result = new RightCommand();
                    break;
                case "L":
                    result = new LeftCommand();
                    break;
                default:
                    break;
            }
            return result;
        }

        [Theory]
        [InlineData("5 3", "", "1 1 E", "R F R F R F R F", "1 1 E", false)]
        [InlineData("5 3", "", "3 2 N", "F R R F L L F F R R F L L", "3 3 N", true)]
        [InlineData("5 3", "3,3","0 3 W", "L L F F F L F L F L", "2 3 S", false)]
        public void TestSample(string areaPoint, string stringSmalPoints, string startPos, string commands, string expectedResult, bool isLost)
        {
            try
            {
                var area = HelperStringToArea(areaPoint, stringSmalPoints);
                StepRobot robot = HelperStringToRobot(startPos, area);
                var listCommands  = commands.Split(' ');
                foreach (var command in listCommands)
                {
                    robot.ExecuteCommand(HelperStringToCommand(command));
                }
                Assert.Equal(robot.ToString(), expectedResult);
                Assert.Equal(robot.IsLosted, isLost);
                if (robot.IsLosted)
                {
                    Assert.True(area.ContainsPositionWithSmell(new PositiontObject(robot.X, robot.Y)));
                }
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }
    }
}