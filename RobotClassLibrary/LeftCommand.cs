using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotClassLibrary
{
    public class LeftCommand : AbstractсCommand
    {
        public override (int outX, int outY, PositionOrientedObject.OrientationEnum outOrientation) Execute(int x, int y, PositionOrientedObject.OrientationEnum orientationIn)
        {
            var outX = x;
            var outY = y;
            var outOrientation = orientationIn;
            switch (orientationIn)
            {
                case PositionOrientedObject.OrientationEnum.N:
                    outOrientation = PositionOrientedObject.OrientationEnum.W;
                    break;
                case PositionOrientedObject.OrientationEnum.W:
                    outOrientation = PositionOrientedObject.OrientationEnum.S;
                    break;
                case PositionOrientedObject.OrientationEnum.S:
                    outOrientation = PositionOrientedObject.OrientationEnum.E;
                    break;
                case PositionOrientedObject.OrientationEnum.E:
                    outOrientation = PositionOrientedObject.OrientationEnum.N;
                    break;
                default:
                    break;
            }
            return (outX, outY, outOrientation);
        }
    }
}
