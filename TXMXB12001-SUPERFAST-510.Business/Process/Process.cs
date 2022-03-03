using System;
using System.Collections.Generic;
using System.Text;

namespace TXMXB12001_SUPERFAST_510.Business
{
    public class Process
    {
        public void Hola()
        {
            DateTime hr = new DateTime();
            hr = DateTime.Now;
            System.IO.File.Create(@"C:\Users\maprado\Documents\ENROLAMIENTO\nicky.txt");
        }

   
    }
}
