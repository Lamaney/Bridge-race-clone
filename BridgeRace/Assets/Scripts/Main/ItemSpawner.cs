using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    //public GameObject[] bricks;
    //public GameObject[] disabledItems;

    [Header("Item lists")]
    public List<GameObject> bricks;
    List<GameObject> deneme=new List<GameObject>();

    public Material[] brickMaterials;

    public Transform disabledItems;

    System.Random rand=new System.Random();


    void Start()
    {
        SpawnBricks();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            
            Debug.Log(bricks.Count);
            Debug.Log(deneme.Count);

        }
    }




    void SpawnBricks()
    {
        

        for (int i = 0; i < bricks.Count; i++)
        {
            MeshRenderer mr=bricks[i].GetComponent<MeshRenderer>();
            mr.enabled = true;
           // bricks[i].GetComponent<MeshRenderer>().material= brickMaterials[rand.Next(0,brickMaterials.Length)];
            mr.material = brickMaterials[rand.Next(0, brickMaterials.Length)];
            string materialName=mr.material.name.ToString().Replace(" (Instance)", ""); ;
            
            bricks[i].gameObject.tag = materialName; 
        }
    }


    public void DisableBrick(GameObject brick)
    {
     
        brick.GetComponent<MeshRenderer>().enabled = false;
        brick.GetComponent<Collider>().enabled = false;
        deneme.Add(brick as GameObject);
       
    }


    void SpawnOneBrick()
    {

    }
}
