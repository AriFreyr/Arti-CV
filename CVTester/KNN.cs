using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
