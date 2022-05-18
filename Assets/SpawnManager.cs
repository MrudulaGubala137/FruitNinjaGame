using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region SINGLETON REGION
    private static SpawnManager instance;
    public static SpawnManager Instance
    {
        get
        {
            if (instance == null)
            {

                instance = GameObject.FindObjectOfType<SpawnManager>();
                if (instance == null)
                {
                    GameObject container = new GameObject("SpawnManager");
                    instance = container.AddComponent<SpawnManager>();
                }
            }

            return instance;
        }
    }
    #endregion
    #region MONOBEHAVIOUR METHODS


    void Start()
    {


        StartCoroutine("SpawnAsteroids");

    }
    void Update()
    {

    }
    #endregion
    #region PUBLIC METHODS
    // Spawn asteroids every few seconds.
    private IEnumerator SpawnAsteroids()
    {
        while (true)
        {


            yield return new WaitForSeconds(Random.Range(2f, 3f));
            SpawnFruits();
        }
    }
    private void SpawnFruits()
    {
        FruitScript newFruit=PoolManager.Instance.Spawn("Fruit").GetComponent<FruitScript>();
        newFruit.transform.position=this.transform.position;
        SpriteRenderer spriteRenderer = newFruit.GetComponentInChildren<SpriteRenderer>();
        
    }
    #endregion
}
