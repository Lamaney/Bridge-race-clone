using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    public Transform lastEndPoint;
    public Transform BackPack;

    GameObject prefabClone;
    
    public  int counter = 0;






    void Start()
    {
        Debug.Log(counter);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            minusbrick();
        }
    }

    public void AddItem(GameObject prefab)
    {

        prefabClone = Instantiate(prefab); ;
        
        prefabClone.transform.parent = BackPack;
        Vector3 newPos = lastEndPoint.localPosition;
        prefabClone.transform.localPosition = newPos;
        prefabClone.transform.rotation = lastEndPoint.rotation;
        lastEndPoint.localPosition += new Vector3(0, 0.300f);
        ++counter;
        Debug.Log(counter);

    }

    public void minusbrick()
    {
        if (counter <= 0)
        {
            Debug.LogError("there is nothing left in the bag");
        }
        else
        {
            GameObject destroyable = BackPack.GetChild(counter).gameObject;
            lastEndPoint.localPosition -= new Vector3(0, 0.279f);
            Destroy(destroyable);
            --counter;

        }

    }
}
