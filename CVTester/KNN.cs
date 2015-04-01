using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Accord.MachineLearning;

namespace CVTester
{
    public class KNN
    {
        private KNearestNeighbors _knn;

        public KNN()
        {
            
        }

        public void TrainKNN(double[][] inputs, int[] outputs, int k)
        {
            _knn = new KNearestNeighbors(k, 3,inputs, outputs);
        }

        public string Classify(double[] image)
        {
            var answer = _knn.Compute(image);

            return Utilities.GetClassFromInt(answer);
        }

        public double ComputeError(double[][] inputs, int[] expectedOutputs)
        {
            // Compute errors
            var count = 0;
            for (var i = 0; i < inputs.Length; i++)
            {
                var actual = _knn.Compute(inputs[i]);
                var expected = expectedOutputs[i];

                if (actual != expected)
                    Interlocked.Increment(ref count);
            }

            // Return misclassification error ratio
            return count / (double)inputs.Length;
        }
    }
}
