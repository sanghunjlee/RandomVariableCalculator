using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RandomVariableCalculator
{
    public static class Logic
    {
        private static ulong Factorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            else
            {
                return (ulong)n * Factorial(n - 1);
            }
        }
        public static double nCr(int n, int r)
        {
            r = Math.Max(r, n - r);
            ulong denominator = Factorial(n - r);
            ulong numerator = 1;
            for (int i = n; i > r; i-- )
            {
                numerator *= (ulong)i;
            }
            return (double)numerator / denominator;
        }
        public static ProbabilityResult UniformDiscreteRV(List<string> X)
        {
            List<float> xList = X.Select(x => float.Parse(x)).ToList();
            int n = xList.Count;
            float p = (float)1 / n;
            float expectedValue = xList.Sum() / n;
            float variance = xList.Select(x => x * x).Sum() / (n - (expectedValue * expectedValue));
            var pmfTable = new Dictionary<string, string>();
            foreach (float x in xList)
            {
                pmfTable.Add(x.ToString(), p.ToString());
            }
            return new ProbabilityResult(pmfTable, expectedValue.ToString(), variance.ToString());
        }
        public static ProbabilityResult BinomialDistributionRV(string n, string p)
        {
            if (Int32.TryParse(n, out int numberTrials) && float.TryParse(p, out float probabilitySuccess))
            {
                if (probabilitySuccess >= 0 && probabilitySuccess <= 1)
                {
                    double q = 1 - probabilitySuccess;
                    double expectedValue = numberTrials * probabilitySuccess;
                    double variance = expectedValue * q;
                    var pmfTable = new Dictionary<string, string>();
                    for (int r = 0; r <= numberTrials; r++)
                    {
                        double probability = nCr(numberTrials, r);
                        probability *=  Math.Pow(probabilitySuccess, r);
                        probability *= Math.Pow(q, numberTrials - r);
                        pmfTable.Add(r.ToString(), Math.Round(probability, 7).ToString());
                    }
                    return new ProbabilityResult(pmfTable, expectedValue.ToString(), variance.ToString());
                }
                else
                {
                    throw new ProbabilityOutOfBoundException();
                }
            }
            else
            {
                throw new ValueTypeMismatchException();
            }
        }
        public static ProbabilityResult PoissonRV(List<string> k, string h, string w)
        {
            if (double.TryParse(h, out double averageSuccess) &&
                double.TryParse(w, out double timePeriod))
            {
                List<uint> kList = k.Select(x => UInt32.Parse(x)).ToList();
                double expectedValue = averageSuccess * timePeriod;
                double variance = expectedValue;
                var pmfTable = new Dictionary<string, string>();
                foreach (uint numberSuccess in kList)
                {
                    double probability = Math.Exp(-expectedValue);
                    probability *= Math.Pow(expectedValue, numberSuccess);
                    probability /= Factorial((int)numberSuccess);
                    pmfTable.Add(numberSuccess.ToString(), probability.ToString());
                }
                return new ProbabilityResult(pmfTable, expectedValue.ToString(), variance.ToString());
            }
            else
            {
                throw new ValueTypeMismatchException();
            }
        }
        public static ProbabilityResult GeometricRV(string n, string p)
        {
            if (UInt32.TryParse(n, out uint numberTrials) &&
                double.TryParse(p, out double probabilitySuccess))
            {
                double expectedValue = 1.0 / probabilitySuccess;
                double variance = (1 - probabilitySuccess) / (Math.Pow(probabilitySuccess, 2));
                double probability = probabilitySuccess * Math.Pow(1 - probabilitySuccess, numberTrials - 1);
                var pmfTable = new Dictionary<string, string>();
                pmfTable.Add(numberTrials.ToString(), probability.ToString());

                return new ProbabilityResult(pmfTable, expectedValue.ToString(), variance.ToString());
            }
            else
            {
                throw new ValueTypeMismatchException();
            }
        }
        public static ProbabilityResult NegativeBinomialRV(string n, string p, string r)
        {
            if (UInt32.TryParse(n, out uint numberTrials) &&
                double.TryParse(p, out double probabilitySuccess) &&
                UInt32.TryParse(r, out uint numberSuccess))
            {
                double expectedValue = (double)numberSuccess / probabilitySuccess;
                double variance = expectedValue * (1 - probabilitySuccess) / probabilitySuccess;
                double probability = nCr((int)numberSuccess - 1, (int)numberSuccess - 1);
                probability *= Math.Pow(probabilitySuccess, numberSuccess);
                probability *= Math.Pow(1 - probabilitySuccess, numberTrials - numberSuccess);
                var pmfTable = new Dictionary<string, string>();
                pmfTable.Add(numberTrials.ToString(), probability.ToString());

                return new ProbabilityResult(pmfTable, expectedValue.ToString(), variance.ToString());
            }
            else
            {
                throw new ValueTypeMismatchException();
            }
        }
    }
}
