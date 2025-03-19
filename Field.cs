using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    internal class Field
    {
        public int startRow;
        public int startColumn;
        public int sizeRow; 
        public int sizeColumn;        

        public Field(int startR,int StartC, int sizeR, int sizeC) 
        {
            startRow = startR;
            startColumn = StartC;
            sizeRow = sizeR;
            sizeColumn = sizeC;        
        }         
    }
}
