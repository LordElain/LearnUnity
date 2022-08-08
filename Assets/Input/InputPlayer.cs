using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputPlayer : MonoBehaviour
{
    LearnUnity PlayerControls;
    Vector2 move;
    public float speed = 10;
    // Start is called before the first frame update
    void Awake()
    {
        PlayerControls = new LearnUnity();
        PlayerControls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        PlayerControls.Player.Move.canceled += ctx => move = Vector2.zero;
    }
     void SendMessage(Vector2 Coordinates)
 {     
     Debug.Log("Button Pressed");
     Debug.Log("Thumb-stick coordinates = " + Coordinates);
 }
    private void OnEnable()
    {
        PlayerControls.Player.Enable();
    }
    private void OnDisable()
    {
        PlayerControls.Player.Disable();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(move.x, 0.0f, move.y) * speed *
        Time.deltaTime;
        transform.Translate(movement, Space.World);
    }
}
