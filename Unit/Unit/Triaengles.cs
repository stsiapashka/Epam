using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit
{
  public class Triangles
    {
        public static bool IsTringele(double a, double b, double c)
        {
            if (a > 0 && b > 0 && c > 0)
            {
                if ((a + b >= c) && (a + c >= b) && (c + b >= a))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }             
        }
        public static bool IsObtuseTringele(double a, double b, double c)//тупоугольный
        {
            return IsTringele(a,b,c) &&
               ((Math.Pow(a, 2) + Math.Pow(b, 2)) < Math.Pow(c, 2) ||
                (Math.Pow(a, 2) + Math.Pow(c, 2)) < Math.Pow(b, 2) ||
                (Math.Pow(b, 2) + Math.Pow(c, 2)) < Math.Pow(a, 2));
        }

        public static bool IsAcuteTriangle(double a, double b, double c)//остроугольный
        {
            return IsTringele(a, b, c) &&
                ((Math.Pow(a, 2) + Math.Pow(b, 2)) > Math.Pow(c, 2) ||
                (Math.Pow(a, 2) + Math.Pow(c, 2)) > Math.Pow(b, 2) ||
                (Math.Pow(b, 2) + Math.Pow(c, 2)) > Math.Pow(a, 2));
        }
    }
}
