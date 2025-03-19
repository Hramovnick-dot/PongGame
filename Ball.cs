using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    internal class Ball
    {
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public int OldPositionX { get; private set; }
        public int OldPositionY { get; private set; }
        private int speedX;
        private int speedY;
        private readonly int endOfFieldTop;
        private readonly int endOfFieldDown;
        private readonly int endOfFieldLeft;
        private readonly int endOfFieldRight;

        public Ball(int startPositionX, int startPositionY, int fieldTop, int fieldLeft, int fieldRows, int fieldColumns, bool speed)
        {
            PositionX = startPositionX;
            PositionY = startPositionY;
            endOfFieldTop = fieldTop;
            endOfFieldLeft = fieldLeft;
            endOfFieldDown = fieldRows;
            endOfFieldRight = fieldColumns + fieldLeft;
            if (speed)
            {
                speedX = 1;
                speedY = 1;
            }
            else 
            {
                speedX = -1;
                speedY = -1;
            }
            OldPositionX = startPositionX;
            OldPositionY = startPositionY;
        }
        public void Upgraid(Rackiet rackietLeft, Rackiet rackietRight)
        {
            OldPositionX = PositionX;
            OldPositionY = PositionY;
            PositionX += speedX;
            PositionY += speedY;
            if (PositionX == endOfFieldTop + 1 || PositionX == endOfFieldDown)
                if (speedX > 0)
                    speedX = -1;
                else speedX = 1;
            IntersectRackiets(rackietLeft);
            IntersectRackiets(rackietRight);
        }
        public void IntersectRackiets(Rackiet rackiet)
        {
            if (PositionY == rackiet.CoordinateX && (PositionX >= rackiet.CoordinateStart && PositionX <= rackiet.CoordinateEnd))
                if (speedY > 0)
                    speedY = -1;
                else speedY = 1;
        }
        public RoundInf EndOfRound()
        {
            RoundInf roundInf = new RoundInf();
            if (PositionY == endOfFieldLeft + 1)
            {
                OldPositionX = PositionX;
                OldPositionY = PositionY;
                roundInf.IsRoundEnd = true;
                roundInf.IsLeftPlayerLose = true;
            }
            if (PositionY == endOfFieldRight - 1)
            {
                OldPositionX = PositionX;
                OldPositionY = PositionY;
                roundInf.IsRoundEnd = true;
                roundInf.IsRightPlayerLose = true;
            }
            return roundInf;
        }
        public class RoundInf
        {
            public bool IsRoundEnd = false;
            public bool IsLeftPlayerLose = false;
            public bool IsRightPlayerLose = false;
        }
    }
}
