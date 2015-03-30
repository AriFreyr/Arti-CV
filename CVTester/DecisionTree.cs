using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.DecisionTrees.Learning;

namespace CVTester
{
    public class DT
    {
        private DecisionTree _decisionTree;
        private C45Learning _c45;
        public DT(DecisionTree decisionTree)
        {
            _decisionTree = decisionTree;
        }

        public double TrainDT(double[][] inputs, int[] outputs)
        {
            _c45 = new C45Learning(_decisionTree);
            var error = _c45.Run(inputs, outputs);

            return error;
        }

        public C45Learning GetC45()
        {
            return _c45;
        }
    }
}
