using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_Creator.RGRMechanic
{
    class Triangle
    {
        private double angleAlpha;
        private double angleBeta;
        private double angleSigma;
        private double sideA;
        private double sideB;
        private double sideC;
        private Point PointA;
        private Point PointB;
        private Point PointC;

        public Triangle() { }
        public double AngleAlpha
        {
            get { return angleAlpha; }
            set
            {
                angleAlpha = value;
            }
        }
        public double AngleBeta
        {
            get { return angleBeta; }
            set
            {
                angleBeta = value;
            }
        }
        public double AngleSigma
        {
            get { return angleSigma; }
            set
            {
                angleSigma = value;
            }
        }
        public double SideA
        {
            get { return sideA; }
            set
            {
                sideA = value;
            }
        }
        public double SideB
        {
            get { return sideB; }
            set
            {
                sideB = value;
            }
        }
        public double SideC
        {
            get { return sideC; }
            set
            {
                sideC = value;
            }
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
            double res = (Math.Pow(sideA, 2) + Math.Pow(sideB, 2) - Math.Pow(sideC, 2)) /
                                            (2 * sideA * sideB);
            return MathExeptions.RadInDeg(Math.Acos( res ));
        }
        /// <summary>
        /// угол через две стороны и угол(не обязательно между ними
        /// </summary>
        /// <param name="sideA">противолежащая сторона</param>
        /// <param name="sideB">вторая сторона</param>
        /// <param name="angle">угол</param>
        /// <returns></returns>
        public static double GetAngle1(double sideA, double sideB, double angle)
        {
            return sideB * Math.Sin(MathExeptions.DegInRad(angle)) / sideA;
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
                                (2 * sideA * sideB * Math.Cos(MathExeptions.DegInRad(angle)));
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
            return (sideA * Math.Sin(MathExeptions.DegInRad(angleAlpha)) / Math.Sin(MathExeptions.DegInRad(angleSigma)));
        }
        // поменять названия
        public static double GetX(double hypotenuse, double angle)
        {   
            return (hypotenuse * Math.Sin(MathExeptions.DegInRad(angle)));
        }
        public static double GetY(double hypotenuse, double angle)
        {
            return (hypotenuse * Math.Cos(MathExeptions.DegInRad(angle)));
        }
    }
}
