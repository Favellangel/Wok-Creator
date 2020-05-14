using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Work_Creator
{
    public static class MathExeptions
    {
        /// <summary>
        /// угол через направляющие векторы двух прямых
        /// </summary>
        /// <param name="pVec1">Координаты конца первого вектора</param>
        /// <param name="pVec2">Координаты конца второго вектора</param>
        /// <param name="lengthBegin">Длинна первого вектора</param>
        /// <param name="lengthEnd">Длина второго вектора</param>
        public static double GetAngle(Point pVec1, Point pVec2, int lengthBegin, int lengthEnd)
        {
            double ScalarMulVector = pVec1.x * pVec2.x + pVec1.y * pVec2.y;
            return MathExeptions.RadInDeg( Math.Acos(ScalarMulVector / (lengthBegin * lengthEnd)));
        }
        public static double DegInRad(double angle)
        {
            return (Math.PI * angle) / 180; ;
        }
        public static double RadInDeg(double angle)
        {
            return (angle * 180) / Math.PI;
        }
    }
}
