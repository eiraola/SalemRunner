using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public TextMeshProUGUI pressTxt;
    public TextMeshProUGUI unpressText;
    private int press = 0;
    private int unpress = 0;
    [SerializeField] private UnityEvent OnJumpPressed = new UnityEvent();
    [SerializeField] private UnityEvent OnJumpReleased = new UnityEvent();
    public void Press(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            press++;
            OnJumpPressed?.Invoke();
        }
        if (context.canceled)
        {
            OnJumpReleased?.Invoke();
            unpress++;
        }
    }
}
