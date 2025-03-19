using System;

namespace Pong
{
    internal class Rackiet
    {
        const int INDENT_TO_FIELD = 10;
        public int CoordinateStart { get; private set; }
        public int CoordinateEnd { get; private set; }
        private readonly int LengthOfRackiets;
        public readonly int CoordinateX;
        private readonly int startOfField;
        private readonly int endOfField;
        private readonly int numberOfPlayer;
        public int OldCoordinateStart { get; set; }
        public int OldCoordinateEnd { get; set; }

        public Rackiet(int numberOfPlayer, int lengthOfRackiets, int fieldStartRow, int fieldStartColumn, int fieldRow, int fieldColumn)
        {
            CoordinateStart = fieldStartRow + 1;
            LengthOfRackiets = lengthOfRackiets;
            CoordinateEnd = CoordinateStart + LengthOfRackiets;
            endOfField = fieldRow;
            this.numberOfPlayer = numberOfPlayer;
            CoordinateX = numberOfPlayer == 1 ? fieldStartColumn + INDENT_TO_FIELD : fieldStartColumn + fieldColumn - INDENT_TO_FIELD;
            startOfField = fieldStartRow;
            OldCoordinateStart = CoordinateStart;
            OldCoordinateEnd = CoordinateEnd;
        }
        public void RackietUp()
        {
            if (CoordinateStart > startOfField + 1)
            {                
                CoordinateStart--;
                CoordinateEnd = CoordinateStart + LengthOfRackiets;
            }
        }
        public void RackietDown()
        {
            if (CoordinateEnd < endOfField)
            {               
                CoordinateStart++;
                CoordinateEnd = CoordinateStart + LengthOfRackiets;
            }
        }
    }
}
