// PseudoRandomSignal.cs
using System;
using System.Linq;
using MathNet.Numerics;

namespace 时间域绘图测试

{
    public class PseudoRandomSignal
    {
        public double[] FrequencyList { get; private set; }
        public int NSequence { get; private set; }

        private int[] Sequence { get; set; }

        public PseudoRandomSignal(double[] frequencyList)
        {
            FrequencyList = frequencyList;
            MakeSequence();
        }

        private void MakeSequence()
        {
            int nFrequency = FrequencyList.Length;

            // 找到所有频率的最小公倍数作为基础周期的一半
            int nColsHalfMatrix = (int)FrequencyList[0];
            for (int i = 1; i < nFrequency; i++)
            {
                nColsHalfMatrix = LeastCommonMultiple(nColsHalfMatrix, (int)FrequencyList[i]);
            }

            int nColsMatrix = nColsHalfMatrix * 2;
            int[,] sequenceMatrix = new int[nFrequency, nColsMatrix];
            Sequence = new int[nColsMatrix];
            NSequence = nColsMatrix;

            for (int i = 0; i < nFrequency; i++)
            {
                double freq = FrequencyList[i];
                int halfPeriodLength = nColsHalfMatrix / (int)freq;

                int[] halfPeriod = new int[halfPeriodLength];
                for (int k = 0; k < halfPeriodLength; k++) halfPeriod[k] = 1;

                int[] pattern = new int[halfPeriodLength * 2];
                Array.Copy(halfPeriod, 0, pattern, 0, halfPeriodLength);
                for (int k = 0; k < halfPeriodLength; k++) pattern[halfPeriodLength + k] = -1;

                int[] repeatedPattern = new int[pattern.Length * (int)freq];
                for (int rep = 0; rep < freq; rep++)
                {
                    Array.Copy(pattern, 0, repeatedPattern, rep * pattern.Length, pattern.Length);
                }

                for (int col = 0; col < nColsMatrix; col++)
                {
                    int idx = col % repeatedPattern.Length;
                    sequenceMatrix[i, col] = repeatedPattern[idx];
                }
            }

            // Sum across all frequencies and take sign
            for (int col = 0; col < nColsMatrix; col++)
            {
                double sum = 0.0;
                for (int row = 0; row < nFrequency; row++)
                {
                    sum += sequenceMatrix[row, col];
                }
                Sequence[col] = sum >= 0 ? 1 : -1;
            }
        }

        public int[] Sampling(int nInterpolation, int samplingTime)
        {
            int originalLength = Sequence.Length;
            int newLength = originalLength * nInterpolation * samplingTime;
            int[] result = new int[newLength];

            for (int i = 0; i < originalLength; i++)
            {
                int val = Sequence[i];
                for (int rep = 0; rep < nInterpolation * samplingTime; rep++)
                {
                    result[i * nInterpolation * samplingTime + rep] = val;
                }
            }

            return result;
        }

        private static int GreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private static int LeastCommonMultiple(int a, int b)
        {
            return a / GreatestCommonDivisor(a, b) * b;
        }
    }

}