using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dice
{
    class Dice
    {
        private const double EPSILON = 1e-6;
        private const double BASEMINDICEVALUE = 1;
        private const double BASEMAXDICEVALUE = 6;
        private const double BASELEFTBORDERPARAM = 1;
        private const double BASERIGHTBORDERPARAM = 10;
        private const double BASESIGNIFICANCEPARAMVALUE = 0.75;
        private const double a = 3;

        protected double minimumDiceValue;
        protected double maximumDiceValue;
        protected double leftBorderParameter;
        protected double rightBorderParameter;
        protected double significanceParameter;
        protected Random randomValueGenerator;

        public Dice(double minimumDiceValue, double maximumDiceValue, double leftBorderParameter, double rightBorderParameter, double significanceParameter)
        {
            this.minimumDiceValue = minimumDiceValue;
            this.maximumDiceValue = maximumDiceValue;
            this.leftBorderParameter = leftBorderParameter;
            this.rightBorderParameter = rightBorderParameter;
            this.significanceParameter = significanceParameter;
            this.randomValueGenerator = new Random();
        }

        public Dice(double leftBorderParameter, double rightBorderParameter, double significanceParameter)
            : this(BASEMINDICEVALUE, BASEMAXDICEVALUE, leftBorderParameter, rightBorderParameter, significanceParameter)
        { }

        public Dice(double leftBorderParameter, double rightBorderParameter)
            : this(BASEMINDICEVALUE, BASEMAXDICEVALUE, leftBorderParameter, rightBorderParameter, BASESIGNIFICANCEPARAMVALUE)
        { }

        public Dice()
            : this(BASEMINDICEVALUE, BASEMAXDICEVALUE, BASELEFTBORDERPARAM, BASERIGHTBORDERPARAM, BASESIGNIFICANCEPARAMVALUE)
        { }

        public Dice(Dice copy)
            : this(copy.minimumDiceValue, copy.maximumDiceValue, copy.leftBorderParameter, copy.rightBorderParameter, copy.significanceParameter)
        { }

        public void setSignificanceParameter(double newSignificanceParameter)
        {
            significanceParameter = newSignificanceParameter;
        }

        private double Transform(double oldValue, double oldLeftBorder, double oldRightBorder, double newLeftBorder, double newRightBorder)
        {
            return newLeftBorder - (oldLeftBorder - oldValue) * (newLeftBorder - newRightBorder) / (oldLeftBorder - oldRightBorder);
        }

        private double GenerateNormalDistributedX()
        {
            double result;
            double x;
            double y;
            do
            {
                x = Transform(randomValueGenerator.NextDouble(), 0, 1, -1, 1);
                y = Transform(randomValueGenerator.NextDouble(), 0, 1, -1, 1);
                result = System.Math.Pow(x, 2) + System.Math.Pow(y, 2);
            } while ((result <= 0.0) || (result > 1.0));
            result = x * System.Math.Sqrt(-2 * System.Math.Log(result) / result) / significanceParameter;
            return result;
        }

        private double GetValueInterval(double value, double leftBorder, double rightBorder, int numberIntervals)
        {
            double result = leftBorder;
            double step = (rightBorder - leftBorder) / numberIntervals;
            while (result < value)
            {
                result += step;
            }
            return result;
        }

        public double ThrowDise(double parameterValue)
        {
            double left = -a;
            double right = a;
            if ((parameterValue - leftBorderParameter) < (rightBorderParameter - parameterValue))
            {
                left = Transform(leftBorderParameter, parameterValue, rightBorderParameter, 0, a);
            };
            if ((parameterValue - leftBorderParameter) > (rightBorderParameter - parameterValue))
            {
                right = Transform(rightBorderParameter, leftBorderParameter, parameterValue, -a, 0);
            };
            double diseV;
            do
            {
                diseV = GenerateNormalDistributedX();
            } while ((diseV < left) || (diseV > right));
            diseV = Transform(diseV, left, right, minimumDiceValue - 1, maximumDiceValue);
            diseV = GetValueInterval(diseV, minimumDiceValue - 1, maximumDiceValue, (int)(maximumDiceValue - minimumDiceValue + 1));
            return diseV;
        }

        public int[] SampleTest(double parameterValue, double testSignificanceParameter, int sampleLength)
        {
            double copySignificanceParameter = significanceParameter;
            significanceParameter = testSignificanceParameter;
            int numDiceValues = (int)(maximumDiceValue - minimumDiceValue) + 1;
            int[] valueCounter = new int[numDiceValues];
            for (int i = 0; i < numDiceValues; i++)
            {
                valueCounter[i] = 0;
            }
            for (int i = 0; i < sampleLength; i++)
            {
                valueCounter[(int)(ThrowDise(parameterValue) - minimumDiceValue)]++;
            }
            significanceParameter = copySignificanceParameter;
            return valueCounter;
        }

        public override bool Equals(Object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Dice left, Dice right)
        {
            return (left.minimumDiceValue == right.minimumDiceValue) && (left.maximumDiceValue == right.maximumDiceValue);
        }

        public static bool operator !=(Dice left, Dice right)
        {
            return (left.minimumDiceValue != right.minimumDiceValue) || (left.maximumDiceValue != right.maximumDiceValue);
        }
    }
}
