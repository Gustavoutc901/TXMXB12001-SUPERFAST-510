using System;
using System.Collections.Generic;
using System.Text;

namespace TXMXB12001_SUPERFAST_510
{
    public class KeyMapLayout
    {
        public KeyMapLayout(EnumTypeLayout typeLayout, int start, int end)
        {
            Start = start;
            End = end;
            TypeLayout = typeLayout;
        }
        public int Start { get; set; }
        public int End { get; set; }
        public EnumTypeLayout TypeLayout { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
