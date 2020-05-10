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

        /// <summary>
        /// угол через три стороны теругольника
        /// </summary>
        /// <param name="sideA">1 прилежащая сторона к неизвестному углу</param>
        /// <param name="sideB">2 прилежащая сторона к неизвестному углу</param>
        /// <param name="sideC">Противолежащая сторона к неизвестному углу</param>
        /// <returns></returns>
        public static double GetAngle(double sideA, double sideB, double sideC)
        {
            return Math.Acos(Math.Pow(sideA, 2) + Math.Pow(sideB, 2) - Math.Pow(sideC, 2) /
                        (2 * sideA * sideB));
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

        /// <summary>
        /// сторона, через 2 угла и сторону
        /// </summary>
        /// <param name="sideA"></param>
        /// <param name="angleAlpha"></param>
        /// <param name="angleSigma"></param>
        /// <returns></returns>
        public static double GetSide1(double sideA, double angleAlpha, double angleSigma)
        {
            return (sideA * Math.Sin(angleAlpha) / Math.Sin(angleSigma));
        }

        public static double GetX(double hypotenuse, double angle)
        {
            return (hypotenuse * Math.Sin(angle));
        }

        public static double GetY(double hypotenuse, double angle)
        {
            return (hypotenuse * Math.Cos(angle));
        }
    }
}
