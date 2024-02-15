using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfTests : MonoBehaviour
{
    [SerializeField] int coins = 10011011;
    [SerializeField] string word = "bird";
    [SerializeField] bool someBool = true;

    [ContextMenu("Execute")]
    void ExecuteTest()
    {
        int starsEarned = 3;
        //This inline if statement
        int coinsEarned = starsEarned <= 2 
                            ? (starsEarned == 2 ? 250 : 100)
                            : 500;

        if(starsEarned == 4 ? true : (word == "dandelion" ? true : false))
        {

        }

        //is the same as this
        if (starsEarned == 3)        
        {
            coinsEarned = 500;
        }
        else if(starsEarned == 2)
        {

        }
        else
        {
            coinsEarned = 100;
        }

        if (coins != 10011011 || word == "dog")
        {
            Debug.Log("Not Equal");
        }
    }
}
