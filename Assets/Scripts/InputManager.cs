using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] private Transform joyStickParent;
    private void Awake()
    {
        playerInput = new PlayerInput();
        joyStickParent.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Start()
    {
        playerInput.TouchInput.Move.started += (context) => MoveStarted(context);
        playerInput.TouchInput.Move.canceled += (context) => MoveEnded(context);

        playerInput.TouchInput.TouchPress.started += (context) => TouchPressStarted(context);
        playerInput.TouchInput.TouchPress.canceled += (context) => TouchPressEnded(context);

    }

    private void TouchPressStarted(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Vector2 touchPos = playerInput.TouchInput.TouchPosition.ReadValue<Vector2>();
        if (IsValidTouchPosition(touchPos))
        {
            Debug.Log("Touch pressed Position is Valid");
            joyStickParent.position = touchPos;
            joyStickParent.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Touch pressed Position is Not Valid");
            joyStickParent.gameObject.SetActive(false);
        }
    }

    private bool IsValidTouchPosition(Vector2 touchPosition)
    {
        return touchPosition.y > Screen.height / 2f == false ;
    }

    private void TouchPressEnded(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Debug.Log("Touch press Ended");
    }

    private void MoveStarted(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Debug.Log("Move Stated "+context.ReadValue<Vector2>());
    }
    private void MoveEnded(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Debug.Log("Move Ended " + context.ReadValue<Vector2>());
    }

    //private void Update()
    //{
    //    Debug.Log(playerInput.TouchInput.Move.ReadValue<Vector2>());
    //}
}
