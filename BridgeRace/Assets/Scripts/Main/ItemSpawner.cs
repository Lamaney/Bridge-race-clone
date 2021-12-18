using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    //public GameObject[] bricks;
    //public GameObject[] disabledItems;

    [Header("Item lists")]
    public List<GameObject> bricks;
    

    public Material[] brickMaterials;

    public Transform spawnPoint;
    public Transform parent;

    public GameObject brick;
    GameObject clone;

    System.Random rand=new System.Random();
    
  

    




    public  void SpawnBricks(int playerCounter)
    {


        for (int i = 0; i < playerCounter; i++)
        {

            clone=Instantiate(brick);
            clone.transform.parent = parent;
            Vector3 column = spawnPoint.localPosition;
            clone.transform.localPosition = column;
            

            for (int j = 0; j < 5; j++)
            {
                clone = Instantiate(brick);
                clone.transform.parent = parent;
                spawnPoint.position += new Vector3(4,0);
                Vector3 row = spawnPoint.localPosition;
                clone.transform.localPosition = row;


            }

            spawnPoint.localPosition += new Vector3(0,0,5);

        }



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

    public void DisableBrick(GameObject gameObject)
    {

        gameObject.GetComponent<MeshRenderer>().enabled = false;    
        gameObject.GetComponent<Collider>().enabled = false;

    }
   

    void SpawnOneBrick()
    {

    }
}
