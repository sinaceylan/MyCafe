using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public delegate void OnCollectArea();
    public static event OnCollectArea OnToastCollect;
    public static ToastServiceManager toastManager;
    bool isCollecting;

    //public static event OnCollectArea OnCoffeeCollect;
    //public static CoffeeServiceManager coffeeManager;

    public delegate void OnDeskArea();
    public static event OnDeskArea OnToastGive;
    public static CustomerManager customerManager;
    bool isGiving;
    
    //public static event OnDeskArea OnCoffeeGive;
    //public static CoffeeCustomerManager coffeeCustomerManager;

    public delegate void OnMoneyArea();
    public static event OnMoneyArea OnMoneyCollected;

    void Start()
    {
        StartCoroutine(CollectEnum());
    }
    IEnumerator CollectEnum()
    {
        while (true)
        {
            if (isCollecting == true)
            {
                OnToastCollect();
                //OnCoffeeCollect();
            }
            if (isGiving == true)
            {
                OnToastGive();
                //OnCoffeeGive();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            OnMoneyCollected();
            Destroy(other.gameObject);

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("ToastCollectArea"))
        {
            isCollecting= true;
            toastManager = other.gameObject.GetComponent<ToastServiceManager>();
        }
        if (other.gameObject.CompareTag("ToastServiceArea"))
        {
            isGiving = true;
            customerManager = other.gameObject.GetComponent<CustomerManager>();
        }

        /*
        if (other.gameObject.CompareTag("CoffeeCollectArea"))
        {
            isCollecting = true;
            coffeeManager = other.gameObject.GetComponent<CoffeeServiceManager>();
        }
        if (other.gameObject.CompareTag("CoffeeServiceArea"))
        {
            isGiving = true;
            coffeeCustomerManager = other.gameObject.GetComponent<CoffeeCustomerManager>();
        }
        */

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ToastCollectArea"))
        {
            isCollecting = false;
            toastManager = null;
        }
        if (other.gameObject.CompareTag("ToastServiceArea"))
        {
            isGiving = false;
            customerManager = null;
        }

        /*
        if (other.gameObject.CompareTag("CoffeeCollectArea"))
        {
            isCollecting = false;
            coffeeManager = null;
        }
        if (other.gameObject.CompareTag("CoffeeServiceArea"))
        {
            isGiving = false;
            coffeeCustomerManager = null;
        }
        */
    }

}
