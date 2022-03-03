using System;
using System.Collections.Generic;
using System.Text;

namespace TXMXB12001_SUPERFAST_510
{
    public class File510PointsAttribute : Attribute
    {
        public File510PointsAttribute(int enumTypeLayout, int start, int end)
        {
            EnumTypeLayout = enumTypeLayout;
            Start = start;
            End = end;
        }

        public int EnumTypeLayout { get; set; }

        public int Start { get; set; }

        public int End { get; set; }
    }
}
