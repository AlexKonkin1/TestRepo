using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotClassLibrary
{

    public class PositionOrientedObject : PositiontObject
    {
        //protected OrientationEnum m_orientation;

        public enum OrientationEnum
        {
            N = 'N',
            S = 'S',
            E = 'E',
            W = 'W'
        }

        public PositionOrientedObject(int x, int y, OrientationEnum orientation) : base(x, y)
        {
            Orientation = orientation;
        }
 
        public OrientationEnum Orientation 
        {
            protected set; get;
        }

        // Equals overrides
        public static bool operator == (PositionOrientedObject o1, PositionOrientedObject o2)
        {
            if ((object)o1 == null)
                return (object)o2 == null;

            return o1.Equals(o2);
        }

        public static bool operator !=(PositionOrientedObject o1, PositionOrientedObject o2)
        {
            return !(o1 == o2);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var o2 = (PositionOrientedObject)obj;
            return (base.Equals(obj) && Orientation == o2.Orientation);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ Orientation.GetHashCode();
        }

        public override string ToString() 
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(X.ToString());
            sb.Append(" ");
            sb.Append(Y.ToString());
            sb.Append(" ");
            sb.Append(Orientation.ToString());
            return sb.ToString();
        }

    }
}
