using ClassifyVision.Models;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace ClassifyVision;

class Program
{
    static void Main()
    {
        var mlContext = new MLContext();

        var reader = mlContext.Data.CreateTextLoader<IrisData>(separatorChar: ',', hasHeader: true);
        IDataView trainingDataView = reader.Load("iris-data.txt");

        var model = TrainModel(mlContext, trainingDataView);

        var predictionEngine = mlContext.Model.CreatePredictionEngine<IrisData, IrisPrediction>(model);

        TestModel(predictionEngine);
    }

    static ITransformer TrainModel(MLContext mlContext, IDataView trainingDataView)
    {
        var pipeline = mlContext.Transforms.Conversion.MapValueToKey("Label")
            .Append(mlContext.Transforms.Concatenate("Features", "SepalLength", "SepalWidth", "PetalLength", "PetalWidth"))
            .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy(labelColumnName: "Label", featureColumnName: "Features"))
            .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

        return pipeline.Fit(trainingDataView); 
    }

    static void TestModel(PredictionEngine<IrisData, IrisPrediction> predictionEngine)
    {
        var testsCount = 10000;
        
        // Статистика предсказаний для каждого типа ириса
        var correctSetosa = 0;
        var correctVersicolor = 0;
        var correctVirginica = 0;

        // Выполнение 1000 предсказаний для каждого типа ириса
        for (int i = 0; i < testsCount; i++)
        {
            var setosaPrediction = MakePrediction(predictionEngine, StaticData.CreateIrisSetosa());
            if (setosaPrediction == "Iris-setosa") 
                correctSetosa++;
            
            var versicolorPrediction = MakePrediction(predictionEngine, StaticData.CreateIrisVersicolor());
            if (versicolorPrediction == "Iris-versicolor") 
                correctVersicolor++;
            
            var virginicaPrediction = MakePrediction(predictionEngine, StaticData.CreateIrisVirginica());
            if (virginicaPrediction == "Iris-virginica") 
                correctVirginica++;
        }

        Console.WriteLine($"Setosa: Correct predictions = {correctSetosa}/{testsCount} ({(correctSetosa / (float)testsCount) * 100}%)");
        Console.WriteLine($"Versicolor: Correct predictions = {correctVersicolor}/{testsCount} ({(correctVersicolor / (float)testsCount) * 100}%)");
        Console.WriteLine($"Virginica: Correct predictions = {correctVirginica}/{testsCount} ({(correctVirginica / (float)testsCount) * 100}%)");
    }

    static string MakePrediction(PredictionEngine<IrisData, IrisPrediction> predictionEngine, IrisData irisData)
    {
        var prediction = predictionEngine.Predict(irisData);
        return prediction.PredictedLabel;  
    }
}
