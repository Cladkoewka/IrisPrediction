using ClassifyVision.Models;

namespace ClassifyVision;

public class StaticData
{
    private static Random _random = new Random();

    // Функция для добавления случайных колебаний
    private static float AddRandomNoise(float value, float noiseLevel)
    {
        return value + ((float)_random.NextDouble() * 2 - 1) * noiseLevel;
    }

    // Iris Setosa Data
    public static IrisData CreateIrisSetosa()
    {
        return new IrisData()
        {
            SepalLength = AddRandomNoise(4.9f, 0.8f),
            SepalWidth = AddRandomNoise(3.1f, 0.4f),
            PetalLength = AddRandomNoise(1.5f, 0.9f),
            PetalWidth = AddRandomNoise(0.1f, 0.4f)
        };
    }

    // Iris Versicolor Data
    public static IrisData CreateIrisVersicolor()
    {
        return new IrisData()
        {
            SepalLength = AddRandomNoise(6.0f, 0.6f),
            SepalWidth = AddRandomNoise(3.4f, 0.4f),
            PetalLength = AddRandomNoise(4.5f, 0.4f),
            PetalWidth = AddRandomNoise(1.6f, 0.3f)
        };
    }

    // Iris Virginica Data
    public static IrisData CreateIrisVirginica()
    {
        return new IrisData()
        {
            SepalLength = AddRandomNoise(5.9f, 0.6f),
            SepalWidth = AddRandomNoise(3.0f, 0.4f),
            PetalLength = AddRandomNoise(5.1f, 0.4f),
            PetalWidth = AddRandomNoise(1.8f, 0.5f)
        };
    }
}