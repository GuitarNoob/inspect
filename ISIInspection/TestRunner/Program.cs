﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            ISIInspection.Tests.UnitTests test = new ISIInspection.Tests.UnitTests();
            test.AddTest();
        }
    }
}