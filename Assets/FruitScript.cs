using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
   

    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polyCollider;
    private Rigidbody2D rigidbody2D;
    float time;
    void Awake()
    { 
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        polyCollider = (PolygonCollider2D)GetComponent<Collider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        ResetFromPrefab();
        ApplyForce();
    }

    void OnDisable()
    {
        rigidbody2D.angularVelocity = 0f;
        rigidbody2D.velocity = Vector2.zero;
    }

    // Get the force applied to the asteroid.
    /* public Vector2 GetForceApplied()
     {

         return force;
     }*/
    public void Update()
    {
        time = time + Time.deltaTime;
        if(time > 5f)
        {
            PoolManager.Instance.Recycle("Fruit",this.gameObject);
            time=0;
        }
    }
   /* private void OnBecameInvisible()
    {
        PoolManager.Instance.Recycle("Fruit", this.gameObject);
    }*/
    // Apply a random force to the fruit.
    public void ApplyForce()
    {

        // rigidbody2D.AddForce(Vector2.up*Random.Range(30,35),ForceMode2D.Impulse);
        rigidbody2D.AddForce(Vector2.up * 40, ForceMode2D.Impulse);
        Debug.Log("Force Applied");
    }
    private void ResetFromPrefab()
    {

        GameObject prefab = PrefabManager.Instance.FruitsPrefab();
        spriteRenderer.sprite = prefab.GetComponentInChildren<SpriteRenderer>().sprite;

        PolygonCollider2D prefabCollider = ((PolygonCollider2D)prefab.GetComponentInChildren<Collider2D>());
        polyCollider.pathCount = prefabCollider.pathCount;

        for (int i = 0; i < prefabCollider.pathCount; i++)
            polyCollider.SetPath(i, prefabCollider.GetPath(i));

    }
    


}
