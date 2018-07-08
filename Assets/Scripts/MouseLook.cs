using System;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    private float _rotationX;

    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float maxVert = 45.0f;

    public float minVert = -45.0f;

    public float sensitivityHoriz = 9.0f;
    public float sensitivityVert = 9.0f;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        //UnitySystemConsoleRedirector.Redirect();

        if (axes == RotationAxes.MouseX)
        {
            // horizontal rotation here
            var mouseMove = Input.GetAxis("Mouse X");
            Console.WriteLine(mouseMove);


            transform.Rotate(0, mouseMove * sensitivityHoriz, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            // vertical rotation here
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

            var rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}