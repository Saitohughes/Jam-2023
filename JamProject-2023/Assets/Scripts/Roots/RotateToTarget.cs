using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    [SerializeField] float rotationSpeed,speed;
    [SerializeField] Vector3 direction;
    PlayerController myplayer;
    [SerializeField] float angle;

    private void Start()
    {
        myplayer= PlayerController.instance;
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log("W de la bola: "+ transform.rotation.w);
        direction = myplayer.transform.position - transform.position;

         angle = Mathf.Atan2(direction.z,direction.x)*Mathf.Rad2Deg;
        Vector3 dir = new Vector3(90f, 0f, angle);
        Quaternion rotation = Quaternion.Euler(dir);

        //Quaternion newdir = new Quaternion(90f, 0, angle,1);
        //Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed*Time.deltaTime);


        transform.position = Vector3.MoveTowards(transform.position, myplayer.transform.position, speed);
    }
}
