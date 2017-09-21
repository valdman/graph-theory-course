using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GraphService
{
    public class Graph
    {
        public Graph(IList<int> I, IList<int> J)
        {
            if(I.Count != J.Count)
            {
                throw new ArgumentException("incomparable length of I and J");
            }
            
            N = I.Count;

            MergedArcs = new int[2*N];
            BundleLists = new int[N];
            BundleHeads = new int[N];

            for (var i = 0; i < N; i++)
            {
                MergedArcs[i] = I[i];
                MergedArcs[2*N - i - 1] = J[i];
                BundleHeads[i] = -1;
            }
            
            for (var k = 0; k < N; k++ )
            {
                var i = I[k]; 
                BundleLists[k] = BundleHeads[i]; 
                BundleHeads[i] = k; 
            } 
        }

        public void Add(int i, int j)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Arc> GetAllArcsFrom(int i)
        {
            for (var k = BundleHeads[i]; k != -1; k = BundleLists[k] )
            {
                yield return GetArcByNumber(k);
            } 
        }

        private Arc GetArcByNumber(int arcNumber)
        {
            return new Arc(MergedArcs[arcNumber], MergedArcs[2*N - arcNumber - 1]);
        }
        
        public string PrintToWolframFormat(StreamWriter streamToWrite = null)
        {
            var builder = new StringBuilder();
            builder.Append('{');
            for (var i = 0; i < N; i++)
            {
                builder.Append($"{MergedArcs[i]}->{MergedArcs[2*N - i - 1]}");
                if (i < N - 1)
                    builder.Append(", ");
            }
            builder.Append('}');
            var result = builder.ToString();

            streamToWrite?.Write(result);

            return result;
        }
        
        public IList<int> MergedArcs { get; private set; }  //IJ
        public IList<int> BundleHeads { get; private set; } //H
        public IList<int> BundleLists { get; private set; } //L

        public int N { get; private set; }
    }

    public class Arc
    {
        public Arc(int fromNumber, int toNumber)
        {
            FromNumber = fromNumber;
            ToNumber = toNumber;
        }

        public int FromNumber { get; set; }
        public int ToNumber { get; set; }
    }
}