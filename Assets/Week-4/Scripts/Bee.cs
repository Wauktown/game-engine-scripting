using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Bee : MonoBehaviour
{
    // Start is called before the first frame update
    private Hive hive;
    private Flower currentFlower;

    void Start()
    {
        CheckAnyFlower();
    }

    private void CheckAnyFlower()
    {
        Flower[] flowers = FindObjectsOfType<Flower>();
        if (flowers.Length > 0)
        {
            Flower randomFlower = flowers[Random.Range(0, flowers.Length)];
            transform.DOMove(randomFlower.transform.position, 1f).OnComplete(() =>
            {
                currentFlower = randomFlower; // Update the current flower
                if (currentFlower != null && currentFlower.HasNectar())
                {
                    TakeNectarFromFlower(); // Take nectar from the flower if it's not null and has nectar
                }
                else
                {
                    CheckAnyFlower(); // Check for another flower if the current one doesn't have nectar
                }
            }).SetEase(Ease.Linear);
        }
        else
        {
            Debug.LogError("No flowers found");
        }
    }

    private void TakeNectarFromFlower()
    {
        transform.DOMove(currentFlower.transform.position, 1f).OnComplete(() =>
        {
            if (hive != null && currentFlower != null && currentFlower.HasNectar())
            {
                hive.GiveNectar(); // Attempt to give nectar to the hive
                ReturnToHive(); // Return to the hive regardless of whether nectar is successfully given or not
            }
            else
            {
                CheckAnyFlower(); // Check for another flower if hive or flower is null or flower has no nectar
            }
        }).SetEase(Ease.Linear);
    }

    public void ReturnToHive()
    {
        Debug.Log("Returning to the hive");
        transform.DOMove(hive.transform.position, 1f).OnComplete(() =>
        {
            CheckAnyFlower(); // Once back at the hive, go out to find more flowers
        }).SetEase(Ease.Linear);
    }

    public void Init(Hive hive)
    {
        this.hive = hive;
    }
}