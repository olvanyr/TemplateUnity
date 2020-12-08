using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public PlayerInput playerInput;


    public static PlayerMovement instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'une instance de PlayerMovement dans la scéne");
            return;
        }

        instance = this;


        playerInput = new PlayerInput();

        playerInput.NormalMovement.Jump.performed += context => Jump(); //second methode
        playerInput.NormalMovement.Move.performed += context => HorizontalMovement(context.ReadValue<Vector2>()); //second methode
    }

    private void OnEnable() //if the script is enable, the we enable the PlayerInput we need to enable it
    {
        playerInput.Enable();
    }

    private void OnDisable() //if the script is disable, the we disable the PlayerInput
    {
        playerInput.Disable();
    }

    void Update()
    {
        //first methode
        /*float movementInput = playerInput.NormalMovement.Move.ReadValue<float>(); // we get the action value from our input class
        float jumpInput = playerInput.NormalMovement.Jump.ReadValue<float>(); // we get the action value from our input class

        

        if (movementInput == 1)
        {
            Debug.Log("moving right");
        }
        if (movementInput == -1)
        {
            Debug.Log("moving left");
        }

        if (jumpInput == 1)
        {
            Debug.Log("jumping");
        }
        
        playerInput.NormalMovement.Move.bindings*/


    }

    void Jump()
    {
        Debug.Log("Player is jumping");
    }
    
    void HorizontalMovement(Vector2 direction)
    {
        Debug.Log("Player is moving : " + direction);
    }
}
