//Reference
//https://www.youtube.com/watch?v=QQ4BxYoZgQU
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAiNeural : MonoBehaviour
{

    //RigidBody
    private Rigidbody2D myRb;
    //The number of nodes we have for each layer
    static int inputLayer=4, hiddenLayer=3, outputLayer=3;

    //matrices for each layer nodes
    float[,] inputNodes = new float[inputLayer, 1];
    float[,] hiddenLayerNodes = new float[hiddenLayer, 1];
    float[,] outputLayerNodes = new float[outputLayer, 1];

    //Weights inbetween the input layer and hidden layer ,AND weights inbetween the hidden layer and outputLayers
    float[,] weightsIH = new float[inputLayer, hiddenLayer];
    float[,] weightsHO = new float[hiddenLayer, outputLayer];

    //Bias
    float[,] biasIH = new float[hiddenLayer, 1];
    float[,] biasHO = new float[outputLayer, 1];

    //Function gets called when the program starts
    //The numerical values such as weights are initially going to be randomized
    private void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        //Randomize the weights in between input and hidden layer
        for(int i=0;i<inputLayer;i++)
        {
            for(int j=0;j<hiddenLayer;i++)
            {
                weightsIH[i, j] = Random.Range(-0.5f, 0.5f);
            }
        }

        //Randomize the weights in between input and hidden layer
        for (int i = 0; i < hiddenLayer; i++)
        {
            for (int j = 0; j < outputLayer; i++)
            {
                weightsHO[i, j] = Random.Range(-0.5f, 0.5f);
            }
        }

        //Randomize the Bias
        for(int i=0;i<hiddenLayer;i++)
        {
            biasIH[i,0]= Random.Range(-0.5f, 0.5f);
        }

        for (int i = 0; i < hiddenLayer; i++)
        {
            biasHO[i, 0] = Random.Range(-0.5f, 0.5f);
        }


    }

    //called everyframe of of the game
    private void Update()
    {
        feedForward();

        for(int i=0;i<outputLayerNodes.GetLength(0);i++)
        {

        }
       
    }

    //The neural network process
    private void train()
    {
        feedForward();
        backPropagation();
    }

    //feedForward 
    //Basically determine the values of the nodes from the hidden layer to output layer
    //multiplies weights in the channels by the previous layer's input, adds them all together, adds the bias and insert it to the threshold function 
    //to get the value of the next node
    //In the end of this function we get the likeliness of which direction the paddle goes
    private void feedForward()
    {
        hiddenLayerNodes = sigmoid(add(dotProduct(transpose(weightsIH), inputNodes), biasIH));
        outputLayerNodes = sigmoid(add(dotProduct(transpose(weightsHO), hiddenLayerNodes), biasHO));
    }
    private void backPropagation()
    {

    }

    //finds the dot product between two matrices
    //multiplies the rows of the first matrix by the corresponding columns of the other matrix and adds them up
    //matrix1=first matrix
    //matrix2= 2nd matrix
    private float[,] dotProduct(float[,] matrix1,float[,] matrix2)
    {
        //rows and collumns of the first matrix
        int rows1 = matrix1.GetLength(0);
        int cols1 = matrix1.GetLength(1);

        //rows and collumns of the 2nd matrix
        int rows2 = matrix1.GetLength(0);
        int cols2 = matrix1.GetLength(1);

        float[,] result = new float[rows2, cols2];
        int rowsResult = matrix1.GetLength(0);
        int colsResult = matrix1.GetLength(1);

        for(int i=0;i<rowsResult;i++)
        {
            for (int j = 0; j < colsResult; j++)
            {
                float sum = 0;
                for(int k=0;k<cols1;k++)
                {
                    sum += matrix1[i, k] * matrix2[k, j];
                }
                result[i, j]=sum;
                  
            }
        }
        return result;
    }

    //transpose
    //Switches the rows and columns of a matrix
    private float[,] transpose(float[,] matrix)
    {
        float[,] temp = new float[matrix.GetLength(1), matrix.GetLength(0)];
        for(int i=0;i<matrix.GetLength(0);i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                temp[j, i] = matrix[i, j];
            }
        }

        return temp;
    }

    //adds to matrices together
    //
    private float[,] add(float[,] matrix1, float[,] matrix2)
    {
        float[,] temp = new float[matrix1.GetLength(0), matrix1.GetLength(1)];
        for (int i = 0; i < matrix1.GetLength(1); i++)
        {
            for (int j = 0; j < matrix1.GetLength(0); j++)
            {
                temp[j, i] = matrix1[j,i]+matrix2[j,i];
            }
        }
        return temp;
    }

    //sigmoid function
    //our threshold function
    //returns a value from 0 to 1
    private float sigmoid(double x)
    {
        return (1.0f / (1.0f + Mathf.Exp((float)-x)));
    }

    //sigmoid function
    //returns a matrix that has 
    private float[,] sigmoid(float[,] matrix)
    {
        for(int i=0;i< matrix.GetLength(0);i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i,j]=sigmoid(matrix[i,j]);
            }
        }
        return matrix;
    }

    //moves the paddle up
    private void Up()
    {
        
    }
    //moves the paddle down
    private void Down()
    {

    }
    //stops movement
    private void stop()
    {

    }
}
