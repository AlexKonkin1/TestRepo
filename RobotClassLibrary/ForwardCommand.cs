using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotClassLibrary
{
    public class ForwardCommand : AbstractсCommand
    {
        public override (int outX, int outY, PositionOrientedObject.OrientationEnum outOrientation) Execute(int x, int y, PositionOrientedObject.OrientationEnum orientationIn)
        {
            var outX = x;
            var outY = y;
            var outOrientation = orientationIn;
            switch (orientationIn)
            {
                case PositionOrientedObject.OrientationEnum.N:
                    outY++;
                    break;
                case PositionOrientedObject.OrientationEnum.E:
                    outX++;
                    break;
                case PositionOrientedObject.OrientationEnum.S:
                    outY--;
                    break;
                case PositionOrientedObject.OrientationEnum.W:
                    outX--;
                    break;
                default:
                    break;
            }
            return (outX, outY, outOrientation);
        }
    }
}
