using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class InputScriptTwo : MonoBehaviour
{
    #region PUBLIC VARIABLES
    public bool useAccelerometer = false;
    public float movementSpeed = 2f;
    public int score=0;
    public Text scoreText;
    #endregion
    #region PRIVATE VARIABLES
    Rigidbody2D rigidbody2D;
    EdgeCollider2D edgeCollider2D;
    private bool isMoving = false;
    bool isInUpdate;
    #endregion
    #region MONOBEHAVIOUR METHODS
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        edgeCollider2D = GetComponent<EdgeCollider2D>();
    }
    void Start()
    {


    }


    // Update is called once per frame
    void Update()
    {

    }
    private void OnEnable() // When gameobject is active, then we are subscribing 
    {
        if (!useAccelerometer)
        {
            MyShootingGame.InputHandler.OnPanBegan += StartMove;
            MyShootingGame.InputHandler.OnPanHeld += UpdateMove;
            MyShootingGame.InputHandler.OnPanEnded += StopMove;
        }

        else
        {
            MyShootingGame.InputHandler.OnAccelerometerChanged += MoveWithAcceleration;

        }

    }

    private void OnDisable()// When gameobject is inactive, then we are desubscribing 
    {
        if (!useAccelerometer)
        {
            MyShootingGame.InputHandler.OnPanBegan -= StartMove;
            MyShootingGame.InputHandler.OnPanHeld -= UpdateMove;
            MyShootingGame.InputHandler.OnPanEnded -= StopMove;

        }
        else
        {
            MyShootingGame.InputHandler.OnAccelerometerChanged -= MoveWithAcceleration;

        }
    }
   
    private void StartMove(Touch touch)        //When pan gesture began
    {
        isMoving = true;
        isInUpdate = false;
    }
    private void UpdateMove(Touch touch)        //When pan gesture held
    {
        isInUpdate = true;
        Vector2 tempPoint = Camera.main.ScreenToWorldPoint(touch.position);
       // tempPoint.y = 0;
        rigidbody2D.position=tempPoint;

    }
    private void StopMove(Touch touch)        //When pan gesture ended
    {
        isMoving = false;
    }

    #endregion
    #region MY PUBLIC METHODS



    private void MoveWithAcceleration(Vector3 acceleration)
    {
        if (!isMoving)
        {
            acceleration.z = 0;

            if (acceleration.sqrMagnitude >= 0.03f)
            {
                Vector2 targetPoint = transform.position + acceleration;

                rigidbody2D.AddForce(transform.forward * movementSpeed * Time.deltaTime);
               // UpdateMove(targetPoint);

            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3&& isInUpdate==true)
        {
            ScoreUpdate(10);
            PoolManager.Instance.Recycle("Fruit", collision.gameObject);
            isInUpdate = false;
        }
    }
    private void ScoreUpdate(int value)
    {
        score= score + value;
        Debug.Log("Score:"+score);
        scoreText.text = score.ToString();

    }
    #endregion
}
