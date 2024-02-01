using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private PlayerInput playerInput;
    [SerializeField] private Image[] joyStickImages;
    [SerializeField] private float joyStickOffsetBorder;
    private void Awake()
    {
        Instance = this;
        playerInput = new PlayerInput();
    }

    private void Start()
    {
        ETouch.Touch.onFingerDown += Touch_onFingerDown;
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
        Vector2 touchPosition = currentFinger.currentTouch.screenPosition;
        if(IsValidTouchPosition(touchPosition))
        {
            Vector2 clampedTouchPosition = GetClampedJoyStickStartPos(touchPosition);
            joyStickImages[0].transform.position = clampedTouchPosition;
            SetActiveJoyStickImages(true);
        }
        
    }

    private Vector2 GetClampedJoyStickStartPos(Vector2 touchPosition)
    {
        float touchPosXclamped = Mathf.Clamp(touchPosition.x, joyStickOffsetBorder, Screen.width - joyStickOffsetBorder);
        float touchPosYclamped = Mathf.Clamp(touchPosition.y, joyStickOffsetBorder, Screen.height / 2 - joyStickOffsetBorder);

        return new Vector2(touchPosXclamped,touchPosYclamped);
    }

    private bool IsValidTouchPosition(Vector2 touchPosition)
    {
        return touchPosition.y < Screen.height / 2f;
    }

    private void Touch_onFingerUp(Finger obj)
    {
        SetActiveJoyStickImages(false);
    }

    private void Update()
    {
        //Debug.Log(playerInput.TouchControl.Move.ReadValue<Vector2>());
    }

    public Vector2 GetJoystickInput()
    {
        return playerInput.TouchControl.Move.ReadValue<Vector2>();
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
        ETouch.Touch.onFingerUp -= Touch_onFingerUp;
    }
}
