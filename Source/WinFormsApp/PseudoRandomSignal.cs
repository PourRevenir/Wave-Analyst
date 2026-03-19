using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApp
{
    public class PseudoRandomSignal
    {
        public double[] FrequencyList { get; private set; }
        public int NSequence { get; private set; }
        private double[] Sequence { get; set; } = Array.Empty<double>();

        public PseudoRandomSignal(double[] frequencyList, string method = "default")
        {
            if (frequencyList == null || frequencyList.Length == 0)
            {
                frequencyList = new double[] { 1 };
            }

            foreach (var freq in frequencyList)
            {
                if (freq <= 0 || freq != Math.Floor(freq))
                {
                    throw new ArgumentException("frequencyList must contain positive integers.");
                }
            }

            switch (method)
            {
                case "2n":
                    if (frequencyList.Length != 1)
                    {
                        throw new ArgumentException("For '2n' method, frequencyList should be a scalar.");
                    }
                    int n = (int)frequencyList[0];
                    FrequencyList = new double[n];
                    for (int i = 0; i < n; i++)
                    {
                        FrequencyList[i] = Math.Pow(2, i);
                    }
                    MakeSequence();
                    break;
                case "pattern":
                    Sequence = new double[frequencyList.Length * 2];
                    for (int i = 0; i < frequencyList.Length; i++)
                    {
                        Sequence[i] = frequencyList[i];
                        Sequence[i + frequencyList.Length] = -frequencyList[i];
                    }
                    NSequence = Sequence.Length;
                    FrequencyList = new double[] { 1 };
                    break;
                default:
                    FrequencyList = frequencyList;
                    MakeSequence();
                    break;
            }
        }
        
        public double[] Sampling(int nInterpolation = 1, int samplingTime = 1)
        {
            if (nInterpolation <= 0 || samplingTime <= 0)
            {
                throw new ArgumentException("nInterpolation and samplingTime must be positive integers.");
            }

            var repeatedSequence = new List<double>();
            foreach (var item in Sequence)
            {
                for (int i = 0; i < nInterpolation; i++)
                {
                    repeatedSequence.Add(item);
                }
            }

            var result = new List<double>();
            for (int i = 0; i < samplingTime; i++)
            {
                result.AddRange(repeatedSequence);
            }

            return result.ToArray();
        }

        private void MakeSequence()
        {
            int nFrequency = FrequencyList.Length;
            int nColsHalfMatrix = (int)FrequencyList[0];

            for (int i = 1; i < nFrequency; i++)
            {
                nColsHalfMatrix = LCM(nColsHalfMatrix, (int)FrequencyList[i]);
            }

            int nColsMatrix = nColsHalfMatrix * 2;
            double[,] sequenceMatrix = new double[nFrequency, nColsMatrix];
            Sequence = new double[nColsMatrix];
            NSequence = nColsMatrix;

            for (int i = 0; i < nFrequency; i++)
            {
                int freq = (int)FrequencyList[i];
                int halfPeriodLength = nColsHalfMatrix / freq;

                double[] halfPeriod = new double[halfPeriodLength];
                for (int j = 0; j < halfPeriodLength; j++)
                {
                    halfPeriod[j] = 1;
                }

                double[] pattern = new double[nColsHalfMatrix];
                Array.Copy(halfPeriod, 0, pattern, 0, halfPeriodLength);
                for (int j = 0; j < halfPeriodLength; j++)
                {
                    pattern[j + halfPeriodLength] = -1;
                }

                double[] row = new double[nColsMatrix];
                for (int j = 0; j < freq; j++)
                {
                    Array.Copy(pattern, 0, row, j * nColsHalfMatrix, nColsHalfMatrix);
                }

                for (int j = 0; j < nColsMatrix; j++)
                {
                    sequenceMatrix[i, j] = row[j];
                }
            }

            for (int j = 0; j < nColsMatrix; j++)
            {
                double sum = 0;
                for (int i = 0; i < nFrequency; i++)
                {
                    sum += sequenceMatrix[i, j];
                }
                Sequence[j] = Math.Sign(sum);
            }
        }

        private static int LCM(int a, int b)
        {
            return a / GCD(a, b) * b;
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}