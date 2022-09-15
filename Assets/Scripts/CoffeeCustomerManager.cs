using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeCustomerManager : MonoBehaviour
{
    public List<GameObject> coffeeList = new List<GameObject>();
    List<GameObject> moneyList = new List<GameObject>();
    public Transform coffeeCollectPoint, moneyDropPoint;
    public GameObject coffeePrefab, moneyPrefab;


    void Start()
    {
        StartCoroutine(GenerateMoney());
    }

    IEnumerator GenerateMoney()
    {
        while (true)
        {
            if (moneyList.Count > 0)
            {
                GameObject temp = Instantiate(moneyPrefab);
                temp.transform.position = new Vector3(moneyDropPoint.position.x, moneyDropPoint.position.y + ((float)moneyList.Count / 50), moneyDropPoint.position.z);
                moneyList.Add(temp);
                RemoveLast();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void RemoveLast()
    {
        if (coffeeList.Count > 0)
        {
            Destroy(coffeeList[coffeeList.Count - 1]);
            coffeeList.RemoveAt(coffeeList.Count - 1);
        }
    }
    public void GetCoffee()
    {
        GameObject temp = Instantiate(coffeePrefab);
        temp.transform.position = new Vector3(coffeeCollectPoint.position.x, coffeeCollectPoint.position.y + ((float)coffeeList.Count / 50), coffeeCollectPoint.position.z);
        coffeeList.Add(temp);

    }

}

