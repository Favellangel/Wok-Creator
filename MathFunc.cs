using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Work_Creator
{
    public static class MathFunc
    {
        /// <summary>
        /// угол через направляющие векторы двух прямых
        /// </summary>
        /// <param name="pBegin">Координаты конца первого вектора</param>
        /// <param name="pEnd">Координаты конца второго вектора</param>
        /// <param name="lengthBegin">Длинна первого вектора</param>
        /// <param name="lengthEnd">Длина второго вектора</param>
        public static double GetAngle(Point pBegin, Point pEnd, int lengthBegin, int lengthEnd)
        {
            double ScalarMulVector = pBegin.x * pEnd.x + pBegin.y * pEnd.y;
            return  Math.Acos(ScalarMulVector / (lengthBegin * lengthEnd));
        }
        
        public static double GetAngle(double sideA, double sideB, double sideC)
        {

            return 0;
        }
        /// <summary>
        /// сторона, через 2 стороны и угол между ними в треугольнике
        /// </summary>
        /// <param name="sideA">Первая сторона</param>
        /// <param name="sideB">Вторая сторона</param>
        /// <param name="angle">Угол между ними</param>
        /// <returns></returns>
        public static double GetSide(double sideA, double sideB, double angle)
        {
            double res = Math.Pow(sideA, 2) + 
                Math.Pow(sideB, 2) - 
                    (2 * sideA * sideB * Math.Cos(angle));
            return Math.Sqrt(res);
        }
    }
}
