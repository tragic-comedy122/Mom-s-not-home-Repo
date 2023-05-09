using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTCamera : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && transform.position.x < 122)
        {
            Debug.Log("D");
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A) && transform.position.x > -18.5)
        {
            Debug.Log("A");
            transform.Translate((Vector3.right)*-1 * Time.deltaTime * speed);
        }   
    }



}
