using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotClassLibrary
{
    public class WalkingArea
    {
        private HashSet<PositiontObject> m_positions = new HashSet<PositiontObject>();
        private HashSet<PositiontObject> m_positionsWithSmell = new HashSet<PositiontObject>();
        public void AddPosition(PositiontObject positiontObject)
        {
            m_positions.Add(positiontObject);
        }
        public bool ContainsPosition(PositiontObject positiontObject)
        { 
            return m_positions.Contains(positiontObject); 
        }

        public void AddPositionWithSmell(PositiontObject positiontObject)
        {
            m_positionsWithSmell.Add(positiontObject);
        }
        public bool ContainsPositionWithSmell(PositiontObject positiontObject)
        {
            return m_positionsWithSmell.Contains(positiontObject);
        }

        public static WalkingArea CreateByUpperRightPos(int x, int y)
        {
            WalkingArea wa = new WalkingArea();
            wa.m_positions.Clear();
            for (int i = 0; i <= x; i++)
            {
                for (int j = 0; j <= y; j++)
                {
                    wa.AddPosition(new PositiontObject(i,j));                
                }
            }
            return wa;
        }
    }
}
