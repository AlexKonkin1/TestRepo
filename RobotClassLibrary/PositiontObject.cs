using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotClassLibrary
{
    public class PositiontObject
    {
        //protected int m_x;
        //protected int m_y;

        public PositiontObject(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X 
        {
            protected set; get;    
        }
        public int Y 
        {
            protected set; get;
        }

        // Equals overrides
        public static bool operator ==(PositiontObject o1, PositiontObject o2)
        {
            if ((object)o1 == null)
                return (object)o2 == null;

            return o1.Equals(o2);
        }

        public static bool operator !=(PositiontObject o1, PositiontObject o2)
        {
            return !(o1 == o2);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var o2 = (PositiontObject)obj;
            return (X == o2.X && Y == o2.Y);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }
}
