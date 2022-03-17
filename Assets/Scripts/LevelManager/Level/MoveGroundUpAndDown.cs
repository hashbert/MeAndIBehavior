using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGroundUpAndDown : MonoBehaviour
{
    //adjust this to change speed
    [SerializeField] float ySpeed = 5f;
    //adjust this to change how high it goes
    [SerializeField] float yHeight = 0.5f;

    [SerializeField] float xSpeed = 5f;
    [SerializeField] float xHeight = 0.5f;


    private Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newX = Mathf.Sin(Time.time * xSpeed) * xHeight + pos.x;
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * ySpeed) * yHeight + pos.y;
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(newX, newY, transform.position.z);

        //gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * xHeight * Time.deltaTime);
    }
}
