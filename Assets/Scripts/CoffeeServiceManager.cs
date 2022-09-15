using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeServiceManager : MonoBehaviour
{
    public List<GameObject> coffeeList  =new List<GameObject>();
    public GameObject coffeePrefab;
    public Transform exitPoint;
    bool isWorking;
    int stackCount = 1;
    void Start()
    {
        StartCoroutine(MakeCoffee());
    }

    IEnumerator MakeCoffee()
    {
        while (true)
        {
            float coffeeCount = coffeeList.Count;
            int rowCount = (int)coffeeList.Count / stackCount;

            if (isWorking)
            {
                GameObject coffee = Instantiate(coffeePrefab);
                coffee.transform.position = new Vector3(exitPoint.position.x + ((float)rowCount / 2), exitPoint.position.y + (coffeeCount % stackCount / 50), exitPoint.position.z);
                coffeeList.Add(coffee);

                if (coffeeCount >= 2)
                {
                    isWorking = false;
                }
            }
            else if (coffeeCount < 2)
            {
                isWorking = true;
            }
            yield return new WaitForSeconds(1f);
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
}
