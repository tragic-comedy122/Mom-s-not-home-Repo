using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustCamera : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject parent;
    private Vector3 calculatedPosition;
    public float cameramovespeed; 
    public int side;
    private int collisionshappeningwiththisblock;
    public CollisionHolder holder;

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy"){
            holder.collisions++;
            if((collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy") && (holder.collisions < 2 || collisionshappeningwiththisblock == 2)){
                calculatedPosition = parent.transform.position;
                calculatedPosition.x += side*cameramovespeed;
                parent.transform.position = calculatedPosition;
            }

            if(collision.gameObject.tag =="Player"){

                collisionshappeningwiththisblock++;
            }
            if(collision.gameObject.tag =="Enemy"){
                collisionshappeningwiththisblock++;
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision){
        if((collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy") && (holder.collisions < 2 || collisionshappeningwiththisblock == 2)){
            calculatedPosition = parent.transform.position;
            calculatedPosition.x += side*cameramovespeed;
            parent.transform.position = calculatedPosition;
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy"){
            holder.collisions += -1;
            if(collision.gameObject.tag =="Player"){
                collisionshappeningwiththisblock+= -1;
            }
            if(collision.gameObject.tag =="Enemy"){
                collisionshappeningwiththisblock+= -1;
            }
        }

    }

}
