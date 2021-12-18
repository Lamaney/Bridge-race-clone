using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int players›nGame;
    ItemSpawner ItemSpawner;



    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        ItemSpawner.SpawnBricks(players›nGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
