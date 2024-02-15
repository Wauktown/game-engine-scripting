using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanoiTower : MonoBehaviour
{
    [SerializeField] private int[] peg1 = { 1, 2, 3, 4 };
    [SerializeField] private int[] peg2 = { 0, 0, 0, 0 };
    [SerializeField] private int[] peg3 = { 0, 0, 0, 0 };

    [SerializeField] private int currentPeg = 1;

    [ContextMenu("Move Right")]
    void MoveRight()
    {
        if (CanMoveRight() == false) return;

        int[] fromArray = GetPeg(currentPeg);
        int fromIndex = GetTopNumberIndex(fromArray);

        if(fromIndex == -1) return;

        int[] toArray = GetPeg(currentPeg + 1);
        int toIndex = GetBottomNumberIndex(toArray);

        if (toIndex == -1) return;

        MoveNumber(fromArray, fromIndex, toArray, toIndex);
    }

    [ContextMenu("Move Left")]
    void MoveLeft()
    {
        if (CanMoveLeft() == false) return;

        int[] fromArray = GetPeg(currentPeg);
        int fromIndex = GetTopNumberIndex(fromArray);

        if (fromIndex == -1) return;

        int[] toArray = GetPeg(currentPeg - 1);
        int toIndex = GetBottomNumberIndex(toArray);

        if (toIndex == -1) return;

        MoveNumber(fromArray, fromIndex, toArray, toIndex);
    }

    void MoveNumber(int[] fromArr, int fromIndex, int[] toArr, int toIndex)
    {
        int value = fromArr[fromIndex];
        fromArr[fromIndex] = 0;

        toArr[toIndex] = value;
    }

    bool CanMoveRight()
    {
        //If peg 1 or 2 then can move right
        return currentPeg < 3;
    }

    bool CanMoveLeft()
    {
        //If peg 2 or 3 then can move right
        return currentPeg > 1;
    }

    int[] GetPeg(int pegNumber)
    {
        if(pegNumber == 1) return peg1;
       
        if(pegNumber == 2) return peg2; 
        
        return peg3;
    }

    int GetTopNumberIndex(int[] peg)
    {
        for(int i = 0; i < peg.Length; i++)
        {
            if (peg[i] != 0) return i;
        }

        return -1;
    }

    int GetBottomNumberIndex(int[] peg)
    {
        for (int i = peg.Length - 1; i >= 0; i--)
        {
            if (peg[i] == 0) return i;
        }

        return -1;
    }
}
