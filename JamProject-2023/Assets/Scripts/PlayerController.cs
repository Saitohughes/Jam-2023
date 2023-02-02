using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    PlayerInput playerInput;
    CharacterController myControl;
    Camera myCamera;

    [SerializeField]
    float speed;
    void Awake()
    {
 
        playerInput=GetComponent<PlayerInput>();
        myControl=GetComponent<CharacterController>();
    }
     void Start()
    {
        //playerInput.actions["Move"].performed += IBindCtx => PlayerMovement();
    }

    // Update is called once per frame
    void Update()
    {
        myControl.Move(PlayerMovement());
        //Aiming();
    }

    public Vector3 PlayerMovement()
    {
        Vector2 movInput = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 finalMov = new Vector3(movInput.x,0f, movInput.y) * speed;
        //myControl.Move(finalMov);
        return finalMov;
    }
   /* public void Aiming()
    {
        float rotation = playerInput.actions["Aim"].ReadValue<Axis>().to * 1f;
        gameObject.transform.Rotate(new Vector3(0f, rotation, 0));
    }
   */
}
