using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItems : MonoBehaviour
{
    Backpack backpack;
    ItemSpawner spawner=new ItemSpawner();


    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == this.gameObject.tag)
        {
            backpack = other.GetComponent<Backpack>();

            if (backpack != null)
            {
                backpack.AddItem(this.gameObject);                
                spawner.DisableBrick(this.gameObject);
                
            }
        }



    }
}
