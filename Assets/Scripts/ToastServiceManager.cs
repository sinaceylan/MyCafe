using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ToastServiceManager : MonoBehaviour
{
    public List<GameObject> toastList = new List<GameObject>();
    public GameObject toastPrefab;
    public Transform exitPoint;
    bool isWorking;
    int stackCount = 5;

    void Start()
    {
        StartCoroutine(MakeToast());
    }

    IEnumerator MakeToast()
    {
        while (true)
        {
            float toastCount = toastList.Count;
            int rowCount = (int)toastList.Count / stackCount;

            if (isWorking)
            {
                GameObject toast = Instantiate(toastPrefab);
                toast.transform.position = new Vector3(exitPoint.position.x , exitPoint.position.y + (toastCount % stackCount / 50), exitPoint.position.z + ((float)rowCount / 2));
                toastList.Add(toast);

                if (toastList.Count >= 15)
                {
                    isWorking = false;
                }
            }
            else if (toastList.Count <15)
            {
                isWorking=true;
            }
            yield return new WaitForSeconds(1f);
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
}
