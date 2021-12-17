using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeStep : MonoBehaviour
{

    public MeshRenderer meshRenderer;
    public Material []material;
    Backpack backpack;
    public string markedMaterial;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    private void OnCollisionEnter(Collision collision)
    {
        
        backpack = collision.gameObject.GetComponent<Backpack>();


        if (markedMaterial!=collision.gameObject.tag)
        {
            if (backpack.counter > 0)
            {
                this.meshRenderer.enabled = true;
                materialChange(collision);
            }
        }

        else
        {
            return;
        }


        

        

    }




    //method that replaces the material of the step with the colliding object.
    void materialChange(Collision collision) 
    {
        markedMaterial = collision.gameObject.tag;
        switch (collision.gameObject.tag)
        {
            case "Blue":
                this.meshRenderer.material = material[0];
                backpack.minusbrick();
                break;

            case "Red":
                this.meshRenderer.material = material[1];
                backpack.minusbrick();
                break;

            case "Green":
                this.meshRenderer.material = material[2];
                backpack.minusbrick();
                break;

            default:
                break;
        }



    }



}
