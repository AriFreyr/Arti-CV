using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Statistics.Kernels;

namespace CVTester
{
    public class SVM
    {
        private MulticlassSupportVectorMachine _svm;
        private MulticlassSupportVectorLearning _smo;


        public double TrainSVM(IKernel kernel, int classes, double[][] inputs, int[] outputs)
        {
            _svm = new MulticlassSupportVectorMachine(inputs[0].Length, kernel, classes);
            _smo = new MulticlassSupportVectorLearning(_svm, inputs, outputs);
            _smo.Algorithm = (svm, classInputs, classOutputs, i, j) =>
                              new SequentialMinimalOptimization(svm, classInputs, classOutputs);
            return _smo.Run();
        }

        public string Classify(double[] img)
        {
            var c = _svm.Compute(img);
            return Utilities.GetClassFromInt(c);
        }

        public MulticlassSupportVectorLearning GetSMO()
        {
            return _smo;
        }

    }
}
