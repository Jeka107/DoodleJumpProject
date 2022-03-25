using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector3 spawnPosition;
    public Vector3 spawnCoinPosition;
    public Vector3 spawnEnemyPosition;
    public List<GameObject> blockPrefab; //list of different bloacks.
    public List<Material> myMaterials;  //list of different materials.
    public Transform playerTransform;
    public Transform blocksParent;      //For order
    public Transform coinsParent;       //For order
    public Transform enemyParent;       //For order
    public GameObject coinPrefab;
    public GameObject enemy;

    MeshRenderer mr;
    int j = 0;
    int randBlock; 
    int randMaterail;
    GameObject LastBlockPrefab;

    void Start()
    {
        mr = blockPrefab[0].GetComponent<MeshRenderer>();       //using first reguler block
        mr.material = myMaterials[j];                           //
        j++;

        for (int i = 0; i <= 5; i++) //creating first regulre block by calling function 6 times.
        {
            CreatePlatfotm();
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            if (playerTransform.position.y > spawnPosition.y - 15)
            {
                CreatePlatfotm();  //create blocks
                
            }
            if(spawnPosition.y>spawnCoinPosition.y-5)
            {
                CreateCoins();     //spawn coins.
            }
        }
    }

    void CreatePlatfotm()
    {
        float randx = Random.Range(-3.5f, 3.5f);
        float randy = Random.Range(2, 4);
        float randEnemyY = Random.Range(8, 15);
        float random = Random.Range(1, 7); //make it more random when spawn enemys.

        spawnPosition.y += randy;
        spawnPosition.x = randx;
       
        switch (j)  //using cases for differs stages.
        {
            case 2:
                randBlock = Random.Range(0, blockPrefab.Count - 2); //using the next king of block.
                CheckBlocks();
                break;
            case 3:
                randBlock = Random.Range(0, blockPrefab.Count - 1); //using the next king of block.
                CheckBlocks();
                break;
            case 4:
                randBlock = Random.Range(0, blockPrefab.Count); //using all kind of blocks.
                CheckBlocks();
                break;
            case 5:
                randMaterail = Random.Range(0, myMaterials.Count); //random blocks
                randBlock = Random.Range(0, blockPrefab.Count);    //random materials.
                CheckBlocks();
                blockPrefab[randBlock].GetComponent<MeshRenderer>().material = myMaterials[randMaterail];  //different materials on stage 5.
                if (random==1)
                {
                    spawnEnemyPosition = spawnPosition; //last block spawn positon.
                    spawnEnemyPosition.y += randEnemyY; //adding random y position to enemy position.
                    Instantiate(enemy, spawnEnemyPosition, Quaternion.identity, enemyParent); //create enemy.
                }
                break;
        }

        if (FindObjectOfType<Destroyer>().GetCount() > 10 * j)        //calling function to know when the next stage.
        {
            if (j < myMaterials.Count)                              //cheking if ew are still i list.
            {
                foreach (GameObject block in blockPrefab)          //for each block change the material we got.
                {
                    block.GetComponent<MeshRenderer>().material = myMaterials[j];
                }
                j++; //moving to next stage.
            }
            else //last stage.
            { j = 5;}
        }
        LastBlockPrefab=Instantiate(blockPrefab[randBlock], spawnPosition, Quaternion.identity, blocksParent); //create block.
    }

    void CheckBlocks() //for not spawning special blocks one after the other.
    {
        if (LastBlockPrefab.tag == "MovingBlock"|| LastBlockPrefab.tag=="Block")
        {
            return;
        }
        if(LastBlockPrefab.tag=="FallingBlock"|| LastBlockPrefab.tag == "SpikeBlock")
        {
            randBlock = 1;
        }
    }

    void CreateCoins() //spawn coins.
    {
        float randCoinx = Random.Range(-2.5f, 2.5f);
        float randCoiny = Random.Range(5, 15);

        spawnCoinPosition.y += randCoiny;
        spawnCoinPosition.x = randCoinx;

        Instantiate(coinPrefab, spawnCoinPosition, Quaternion.identity, coinsParent);
    }
}
