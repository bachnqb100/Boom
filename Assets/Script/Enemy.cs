using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    private AIPath aiPath;

    private float radiusBomb;
    public float xRange = 7f;
    public float yRange = 5f;

    private Transform posBomb;
    public Transform posDodgeBomb;

    private Transform player;

    private BombController bombController;
    public LayerMask destructiblesBomb;
    private bool nearBomb = false;


    private void Awake()
    {
        aiPath = GetComponent<AIPath>();

        radiusBomb = GetComponent<BombController>().explosionRadius;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bombController = GetComponent<BombController>();
        posDodgeBomb.position = player.position;
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Bomb") == null)
        {
            nearBomb = false;
        } else if (GameObject.FindGameObjectWithTag("Bomb") != null && nearBomb == true)
        {
            posBomb = GameObject.FindGameObjectWithTag("Bomb").transform;
            if (((posBomb.position.x - transform.position.x < radiusBomb) && (posBomb.position.y - transform.position.y < 0.5)) ||
                    ((posBomb.position.y - transform.position.y < radiusBomb) && (posBomb.position.x - transform.position.x < 0.5)))                    
            {
                nearBomb = true;

                //posDodgeBomb.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                Debug.Log("Near boommmmmmmmmmm");
                if (Random.Range(1, 3) == 1)
                {
                    posDodgeBomb.position = new Vector3(-posBomb.position.x, -player.position.y, 0f);
                } else
                {
                    posDodgeBomb.position = new Vector3(-player.position.x, -posBomb.position.y, 0f);
                }
                nearBomb = false;
            }
        }

        if (aiPath.velocity.magnitude < 0.1f)
        {
            Vector3 posTemp = posDodgeBomb.position;
            posTemp.x = -(posDodgeBomb.position.y - transform.position.y) + transform.position.x;
            posTemp.y = (posDodgeBomb.position.x - transform.position.x) + transform.position.y;

            posDodgeBomb.position = posTemp;
        }


        if (Physics2D.OverlapCircle(transform.position, 0.6f, destructiblesBomb) && !nearBomb)
        {
            Debug.Log("Placed bommmm");
            bombController.PlacedBomb();
            return;
        }


        
    }



    public void SpeedUp()
    {
        aiPath.maxSpeed++;
    }
        
}
