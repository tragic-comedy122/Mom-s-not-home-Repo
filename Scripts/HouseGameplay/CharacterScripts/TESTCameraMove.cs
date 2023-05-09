using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTCameraMove : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D");
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A");
            transform.Translate((Vector3.right)*-1 * Time.deltaTime * speed);
        }   
    }



}
