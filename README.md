# Iris Classification Project

## Project Description
This project demonstrates a machine learning-based solution for classifying Iris flower species based on their physical characteristics such as sepal and petal dimensions. The application utilizes a trained model to predict whether a given flower belongs to one of three species: *Iris Setosa*, *Iris Versicolor*, or *Iris Virginica*. 

## Features
- **Dataset**: The Iris dataset with 150 samples and features: `sepal length`, `sepal width`, `petal length`, `petal width`.
- **Classification**: Prediction of Iris species using predefined and custom datasets.
- **Custom Input**: Support for creating and classifying Iris flower data with dynamic feature values.
- **Static Data**: Predefined examples for testing predictions.

## Technologies Used
- **.NET Core**: Backend logic and data handling.
- **C#**: Language for implementing the project.
- **Machine Learning Models**: Iris classification logic.
- **Iris Dataset**: Widely known dataset for classification problems.

## Project Structure
- **Models**: Contains the `IrisData` model representing the input data format.
- **StaticData**: Provides pre-defined Iris flower data for testing the application.
- **Dataset**: Represents the real-world Iris dataset for training and evaluation.

## Sample Input and Output
- **Input Example**:
    ```csharp
    var sampleData = new IrisData
    {
        SepalLength = 5.1f,
        SepalWidth = 3.5f,
        PetalLength = 1.4f,
        PetalWidth = 0.2f
    };
    ```
- **Output Example**:
    ```
    Setosa: Correct predictions = 9872/10000 (98,72%)
    Versicolor: Correct predictions = 9663/10000 (96,630005%)
    Virginica: Correct predictions = 7620/10000 (76,200005%) 

    ```

## Future Improvements
- Implement dynamic dataset input through a UI or API.
- Enhance the model with additional features or datasets.
- Visualize predictions using a web frontend.

---
