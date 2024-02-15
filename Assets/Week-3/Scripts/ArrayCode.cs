using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayCode : MonoBehaviour
{
    [SerializeField] int[] array = new int[]{1,4,6,99};

    int[][] twoArray = new int[4][];

    int[,] otherTwoArray = new int[3,3];

    [ContextMenu("Execute")]
    void Execute()
    {
        //top left is (0,0)
        twoArray[0] = new int[4] { 1, 2, 3, 4 };
        twoArray[1] = new int[4] { 5, 6, 7, 8 };
        twoArray[2] = new int[4] { 9, 10, 11, 12 };
        twoArray[3] = new int[4] { 13, 14, 15, 16 };
        //bottom right is (3,3)
        /*Debug.Log(twoArray[3][3]);

        Debug.Log(array[0]);

        Debug.Log(array[array.Length - 1]);

        Debug.Log(array[3]);

        Debug.Log(otherTwoArray[3, 3]);*/

        int nRows = otherTwoArray.GetLength(0);
        int nColumns = otherTwoArray.GetLength(1);

        for (int row = 0; row < nRows; row++)
        {
            for (int column = 0; column < nColumns; column++)
            {
                otherTwoArray[row, column] = Random.Range(0, 100);
            }
        }

        for (int row = 0; row < nRows; row++)
        {
            for (int column = 0; column < nColumns; column++)
            {
                Debug.Log(otherTwoArray[row, column]);
            }
        }
    }
}
