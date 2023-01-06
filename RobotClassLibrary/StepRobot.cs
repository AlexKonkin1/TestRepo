namespace RobotClassLibrary
{
    public class StepRobot : PositionOrientedObject
    {
        private WalkingArea m_walkingArea;
        public bool IsLosted { private set; get; } = false;

        public StepRobot(int x, int y, OrientationEnum orientation, WalkingArea walkingArea) : base(x, y, orientation)
        {
            m_walkingArea = walkingArea;
        }
        public void ExecuteCommand(AbstractсCommand command)
        {
            if (IsLosted) return;
            var result = command.Execute(X, Y, Orientation);
            var newPosition = new PositiontObject(result.outX, result.outY);
            if (m_walkingArea.ContainsPosition(newPosition))
            {
                X = result.outX;
                Y = result.outY;
                Orientation = result.outOrientation;
            }
            else
            {
                var curPos = new PositiontObject(X, Y);
                if (!m_walkingArea.ContainsPositionWithSmell(curPos))
                { 
                    IsLosted = true;
                    m_walkingArea.AddPositionWithSmell(curPos);
                }
            }
        }
    }
}