using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public float horizontal = 0;
    public bool jump = false;
    public bool meleeAttack = false;
    public bool knightFlyAttack = false;
    public bool bnDown = false;

    private void Awake()
    {
        InputManager.instance = this;
    }
    private void Update()
    {
        this.GetInput();
    }

    protected void GetInput()
    {
        this.horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            this.jump = true;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            this.bnDown = true;
        }
        this.meleeAttack = Input.GetMouseButtonDown(0);
        this.knightFlyAttack = Input.GetMouseButtonDown(1);
    }
}
