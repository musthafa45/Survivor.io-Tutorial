using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] private Image[] joyStickImages;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    private void Start()
    {
        ETouch.Touch.onFingerDown += Touch_onFingerDown;
        ETouch.Touch.onFingerMove += Touch_onFingerMove;
        ETouch.Touch.onFingerUp += Touch_onFingerUp;

        SetActiveJoyStickImages(false);
    }

    private void SetActiveJoyStickImages(bool activeSelf)
    {
        foreach (Image image in joyStickImages)
        {
            image.enabled = activeSelf;
        }
    }

    private void Touch_onFingerDown(Finger currentFinger)
    {
        Debug.Log("Finger Down");
        Vector2 touchPosition = currentFinger.currentTouch.screenPosition;
        if(IsValidTouchPosition(touchPosition))
        {
            joyStickImages[0].transform.position = touchPosition;
            SetActiveJoyStickImages(true);
        }
        
    }

    private bool IsValidTouchPosition(Vector2 touchPosition)
    {
        return touchPosition.y < Screen.height / 2f;
    }

    private void Touch_onFingerMove(Finger obj)
    {
        Debug.Log("Finger Move");

    }

    private void Touch_onFingerUp(Finger obj)
    {
        Debug.Log("Finger Up");
        SetActiveJoyStickImages(false);

    }

    private void Update()
    {
        //Debug.Log(playerInput.TouchControl.Move.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        playerInput.Enable();
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
        EnhancedTouchSupport.Disable();

        ETouch.Touch.onFingerDown -= Touch_onFingerDown;
        ETouch.Touch.onFingerMove -= Touch_onFingerMove;
        ETouch.Touch.onFingerUp -= Touch_onFingerUp;
    }
}
