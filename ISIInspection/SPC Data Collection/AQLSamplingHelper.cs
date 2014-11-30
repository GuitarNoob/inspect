using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC_Data_Collection
{
    public enum InspectionLevel
    {
        I,
        II,
        III
    }
    public static class AQLSamplingHelper
    {
        private static string GetILvl(InspectionLevel iLvl, string choice1, string choice2, string choice3)
        {
            switch (iLvl)
            {
                case InspectionLevel.I:
                    return choice1;
                case InspectionLevel.II:
                    return choice2;
                case InspectionLevel.III:
                    return choice3;
            }
            return "";
        }

        private static int GetFailCount(decimal aql, int p0, int p1_5, int p2_5, int p4, int p6_5)
        {
            if (aql < (decimal)0)
                return p0;
            else if (aql < (decimal)1.5)
                return p1_5;
            else if (aql < (decimal)2.5)
                return p2_5;
            else if (aql < (decimal)4)
                return p4;
            else if (aql < (decimal)6.5)
                return p6_5;

            return -1;
        }

        public static string GetSampleSizeCode(int lotSize, InspectionLevel iLvl)
        {
            if (lotSize < 8)
            {
                return GetILvl(iLvl, "A", "A", "B");
            }
            else if (lotSize < 15)
            {
                return GetILvl(iLvl, "A", "B", "C");
            }
            else if (lotSize < 25)
            {
                return GetILvl(iLvl, "B", "C", "D");
            }
            else if (lotSize < 50)
            {
                return GetILvl(iLvl, "C", "D", "E");
            }
            else if (lotSize < 90)
            {
                return GetILvl(iLvl, "C", "E", "F");
            }
            else if (lotSize < 150)
            {
                return GetILvl(iLvl, "D", "F", "G");
            }
            else if (lotSize < 280)
            {
                return GetILvl(iLvl, "E", "G", "H");
            }
            else if (lotSize < 500)
            {
                return GetILvl(iLvl, "F", "H", "J");
            }
            else if (lotSize < 1200)
            {
                return GetILvl(iLvl, "G", "J", "K");
            }
            else if (lotSize < 3200)
            {
                return GetILvl(iLvl, "H", "K", "L");
            }
            else if (lotSize < 10000)
            {
                return GetILvl(iLvl, "J", "L", "M");
            }
            else if (lotSize < 35000)
            {
                return GetILvl(iLvl, "K", "M", "N");
            }
            else if (lotSize < 150000)
            {
                return GetILvl(iLvl, "L", "N", "P");
            }
            else if (lotSize < 500000)
            {
                return GetILvl(iLvl, "M", "P", "Q");
            }
            //else
            return GetILvl(iLvl, "N", "Q", "R");
        }

        public static bool GetSampleSize(string sampleSizeCode, decimal AQLPercent, out int samplesToCheck, out int failCount)
        {
            samplesToCheck = failCount = -1;
            switch (sampleSizeCode)
            {
                case "A":
                    {
                        samplesToCheck = 2;
                        failCount = GetFailCount(AQLPercent, 0, 0, 0, 0, 0);
                    }
                    break;
                case "B":
                    {
                        samplesToCheck = 3;
                        failCount = GetFailCount(AQLPercent, 0, 0, 0, 0, 0);
                    }
                    break;
                case "C":
                    {
                        samplesToCheck = 5;
                        failCount = GetFailCount(AQLPercent, 0, 0, 0, 0, 1);
                    }
                    break;
                case "D":
                    {
                        samplesToCheck = 8;
                        failCount = GetFailCount(AQLPercent, 0, 0, 0, 1, 1);
                    }
                    break;
                case "E":
                    {
                        samplesToCheck = 13;
                        failCount = GetFailCount(AQLPercent, 0, 0, 1, 1, 2);
                    }
                    break;
                case "F":
                    {
                        samplesToCheck = 20;
                        failCount = GetFailCount(AQLPercent, 0, 1, 1, 2, 3);
                    }
                    break;
                case "G":
                    {
                        samplesToCheck = 32;
                        failCount = GetFailCount(AQLPercent, 1, 1, 2, 3, 5);
                    }
                    break;
                case "H":
                    {
                        samplesToCheck = 50;
                        failCount = GetFailCount(AQLPercent, 1, 2, 3, 5, 7);
                    }
                    break;
                case "J":
                    {
                        samplesToCheck = 80;
                        failCount = GetFailCount(AQLPercent, 2, 3, 5, 7, 10);
                    }
                    break;
                case "K":
                    {
                        samplesToCheck = 125;
                        failCount = GetFailCount(AQLPercent, 3, 5, 7, 10, 14);
                    }
                    break;
                case "L":
                    {
                        samplesToCheck = 200;
                        failCount = GetFailCount(AQLPercent, 5, 7, 10, 14, 21);
                    }
                    break;
                case "M":
                    {
                        samplesToCheck = 315;
                        failCount = GetFailCount(AQLPercent, 7, 10, 14, 21, 21);
                    }
                    break;
                case "N":
                    {
                        samplesToCheck = 500;
                        failCount = GetFailCount(AQLPercent, 10, 14, 21, 21, 21);
                    }
                    break;
                case "P":
                    {
                        samplesToCheck = 800;
                        failCount = GetFailCount(AQLPercent, 14, 21, 21, 21, 21);
                    }
                    break;
                case "Q":
                    {
                        samplesToCheck = 1250;
                        failCount = GetFailCount(AQLPercent, 21, 21, 21, 21, 21);
                    }
                    break;
                case "R":
                    {
                        samplesToCheck = 2000;
                        failCount = GetFailCount(AQLPercent, 21, 21, 21, 21, 21);
                    }
                    break;
            }

            return true;
        }
    }
}
