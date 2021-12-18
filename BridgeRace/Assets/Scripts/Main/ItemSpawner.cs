using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    //public GameObject[] bricks;
    //public GameObject[] disabledItems;

    [Header("Item lists")]
    List<GameObject> bricks=new List<GameObject>();
    List<GameObject> disabledItems=new List<GameObject>();


    public Material[] brickMaterials;

    public Transform spawnPoint;
    public Transform parent;

    public GameObject brick;
    GameObject clone,collectibleChild;

   



    private void Start()
    {
        SpawnBricks(3);
        disabledItems.Add(clone);
        
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log(disabledItems.Count);
        }
    }

    public  void SpawnBricks(int playerCounter)
    {


        for (int i = 0; i < playerCounter; i++)
        {

            clone=Instantiate(brick);
            bricks.Add(clone);
            clone.transform.parent = parent;
            Vector3 column = spawnPoint.localPosition;
            clone.transform.localPosition = column;
            

            for (int j = 0; j < 4; j++)
            {
                clone = Instantiate(brick);
                bricks.Add(clone);
                clone.transform.parent = parent;
                spawnPoint.position += new Vector3(4,0);
                Vector3 row = spawnPoint.localPosition;
                clone.transform.localPosition = row;


            }

            spawnPoint.localPosition -= new Vector3(16,0,5);

        }



        for (int i = 0; i < bricks.Count; i++)
        {
            MeshRenderer mr=bricks[i].GetComponent<MeshRenderer>();
            mr.enabled = true;
           // bricks[i].GetComponent<MeshRenderer>().material= brickMaterials[rand.Next(0,brickMaterials.Length)];
            mr.material = brickMaterials[Random.Range(0, brickMaterials.Length)];
            string materialName=mr.material.name.ToString().Replace(" (Instance)", ""); ;
            
            bricks[i].gameObject.tag = materialName; 
        }







    }

    public void DisableBrick(GameObject gameObject)
    {
        disabledItems.Add(gameObject);
        gameObject.GetComponent<MeshRenderer>().enabled = false;    
        gameObject.GetComponent<Collider>().enabled = false;
        

    }
   

    void SpawnOneBrick()
    {

    }
}
