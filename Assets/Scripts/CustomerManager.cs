using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public List<GameObject> toastList = new List<GameObject>();
    List<GameObject> moneyList = new List<GameObject>();
    public Transform toastPoint, moneyDropPoint;
    public GameObject toastPrefab, moneyPrefab;

    void Start()
    {
        StartCoroutine(GenerateMoney());
    }

    IEnumerator GenerateMoney()
    {
        while (true)
        {
            if (toastList.Count > 0)
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
        if (toastList.Count > 0)
        {
            Destroy(toastList[toastList.Count - 1]);
            toastList.RemoveAt(toastList.Count - 1);
        }
    }
    public void GetToast()
    {
        GameObject temp = Instantiate(toastPrefab);
        temp.transform.position = new Vector3(toastPoint.position.x, toastPoint.position.y + ((float)toastList.Count / 50), toastPoint.position.z);
        toastList.Add(temp);    

    }

}
