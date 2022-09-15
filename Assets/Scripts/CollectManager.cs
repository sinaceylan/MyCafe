using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    public List<GameObject> toastList = new List<GameObject>();
    public GameObject toastPrefab;
    public Transform toastCollectPoint;
    int toastLimit = 5;

    /*
    public List<GameObject> coffeeList = new List<GameObject>();
    public GameObject coffeetPrefab;
    public Transform coffeeCollectPoint;
    int coffeeLimit = 2;
    */

    private void OnEnable()
    {
        TriggerManager.OnToastCollect += GetToast;
        TriggerManager.OnToastGive += GiveToast;

        //TriggerManager.OnCoffeeCollect += GetCoffee;
        //TriggerManager.OnCoffeeGive += GiveCoffee;      
    }
    private void OnDisable()
    {
        if (toastList.Count <= toastLimit)
        {
            TriggerManager.OnToastCollect -= GetToast;
            TriggerManager.OnToastGive -= GiveToast;
        }

        /*
        if (coffeeList.Count <= coffeeLimit)
        {
            TriggerManager.OnCoffeeCollect -= GetCoffee;
            TriggerManager.OnCoffeeGive -= GiveCoffee;
        }
        */
    }
    void GetToast()
    {
        if(toastList.Count <= toastLimit)
        {
            GameObject temp = Instantiate(toastPrefab,toastCollectPoint);
            temp.transform.position = new Vector3(toastCollectPoint.position.x, toastCollectPoint.position.y + ((float)toastList.Count / 50), toastCollectPoint.position.z);
            toastList.Add(temp);

            if (TriggerManager.toastManager != null)
            {
                TriggerManager.toastManager.RemoveLast();
            }
        }
    }
    public void GiveToast()
    {
        if (toastList.Count > 0)
        {
            TriggerManager.customerManager.GetToast();
            RemoveLast();
        }
    }
    /*
    void GetCoffee()
    {
        if (coffeeList.Count <= coffeeLimit)
        {
            GameObject temp = Instantiate(coffeetPrefab, coffeeCollectPoint);
            temp.transform.position = new Vector3(coffeeCollectPoint.position.x, coffeeCollectPoint.position.y + ((float)coffeeList.Count / 50), coffeeCollectPoint.position.z);
            coffeeList.Add(temp);

            if (TriggerManager.coffeeManager != null)
            {
                TriggerManager.coffeeManager.RemoveLast();
            }
        }
    }
    
    public void GiveCoffee()
    {
        if (coffeeList.Count > 0)
        {
            TriggerManager.coffeeCustomerManager.GetCoffee();
            CoffeeRemoveLast();
        }
    }
    */

    public void RemoveLast()
    {
        if (toastList.Count > 0)
        {
            Destroy(toastList[toastList.Count - 1]);
            toastList.RemoveAt(toastList.Count - 1);
        }
    }

    /*
    public void CoffeeRemoveLast()
    {
        if (coffeeList.Count > 0)
        {
            Destroy(coffeeList[coffeeList.Count - 1]);
            coffeeList.RemoveAt(coffeeList.Count - 1);
        }
    }
    */
}
