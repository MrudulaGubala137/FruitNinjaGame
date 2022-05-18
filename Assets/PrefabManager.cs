using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    // Start is called before the first frame update
    #region SINGLETON REGION
    private static PrefabManager instance;
    public static PrefabManager Instance
    {
        get
        {
            if (instance == null)
            {

                instance = GameObject.FindObjectOfType<PrefabManager>();
                if (instance == null)
                {
                    GameObject container = new GameObject("PrefabManager");
                    instance = container.AddComponent<PrefabManager>();
                }
            }

            return instance;
        }
    }
    #endregion
    #region PUBLIC VARIABLES
    // An array of fruit prefabs. Order doesn't matter.
    public GameObject[] fruitPrefabs;

    
    #endregion

    #region MONOBEHAVIOUR METHODS
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion
    #region PUBLIC METHODS
    // Return a large as prefab.
    public GameObject FruitsPrefab()
    {
        if (fruitPrefabs.Length > 0)
            return fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];

        return null;
    }

    #endregion
}