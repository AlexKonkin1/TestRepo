using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotClassLibrary
{
    public abstract class AbstractсCommand
    {
        public abstract (int outX,  int outY,  PositionOrientedObject.OrientationEnum outOrientation) Execute(int x, int y, PositionOrientedObject.OrientationEnum orientationIn);

    }
}
