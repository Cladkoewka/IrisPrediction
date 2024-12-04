using Microsoft.ML.Data;

namespace ClassifyVision.Models;

public class IrisPrediction
{
    [ColumnName("PredictedLabel")]
    public string PredictedLabel;
}