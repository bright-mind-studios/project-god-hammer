using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class XRGamepadController : MonoBehaviour
{
    [SerializeField] private Transform main;
    [SerializeField] private Transform right;
    [SerializeField] private Transform left;

    [SerializeField] private float movementspeed = 5f;
    [SerializeField] private InputActionAsset myActionsAsset;
    [SerializeField] InputActionReference actionGrip;

    private Vector3 mainMoveInputValue, leftMoveInputValue, rightMoveInputValue;

    // Start is called before the first frame update

    public void OnMainmove(CallbackContext ctx) => mainMoveInputValue = ctx.ReadValue<Vector2>();     
    public void OnLeftMove(CallbackContext ctx) => leftMoveInputValue = ctx.ReadValue<Vector2>();
    public void OnRightMove(CallbackContext ctx) => rightMoveInputValue = ctx.ReadValue<Vector2>();

    private void Update() {
        main.transform.position += mainMoveInputValue * movementspeed * Time.deltaTime;
        left.transform.position += leftMoveInputValue * movementspeed * Time.deltaTime;
        right.transform.position += rightMoveInputValue * movementspeed * Time.deltaTime;
    }

}
