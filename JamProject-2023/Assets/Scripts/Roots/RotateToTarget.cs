using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    [SerializeField] float rotationSpeed,speed;
    [SerializeField] Vector3 direction;
    PlayerController myplayer;

    private void Start()
    {
        myplayer= PlayerController.instance;
    }


    // Update is called once per frame
    void Update()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition)- transform.position;
        float angle = Mathf.Atan2(direction.z,direction.y)*Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed*Time.deltaTime);


        transform.position = Vector3.MoveTowards(Camera.main.ScreenToWorldPoint(Input.mousePosition), myplayer.transform.position, speed);
    }
}
