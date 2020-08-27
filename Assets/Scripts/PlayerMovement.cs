using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Numerics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 9f;
    public float gravity = -9.81f;
    UnityEngine.Vector3 velocity;
    public Transform GroundCheck;
    public float jumpHeight = 0.75f;
    public float GroundDistance = 0.4f;
    public LayerMask groundMask;
    [SerializeField]
    private GameObject _ThePlayer;
    [SerializeField]
    private GameObject _TheGuns;
    [SerializeField]
    private UnityEngine.Vector3 _scaleChange;
    bool isGrounded;

    void Update()
    {
        Movement();
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouch();
        } else
        {
            _ThePlayer.transform.localScale = new UnityEngine.Vector3(1.2f, 1.4f, 1.2f);
            _TheGuns.transform.localScale = new UnityEngine.Vector3(1.2f, 0.35f, 0.35f);
        }
    }
    void Movement()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        UnityEngine.Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * 3.14f * Time.deltaTime);
    }
    void Crouch()
    {
        _scaleChange = new UnityEngine.Vector3(1.2f, 0.7f, 1.2f);
        _ThePlayer.transform.localScale = _scaleChange;
    }
}
