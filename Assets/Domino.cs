using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Domino : MonoBehaviour
{
    private Vector3 rotation;

    private float rotationDomino = 30f;
    public bool isClickX = false; // TODO : Enum���� �ٲٱ�.
    public bool isClickY = false;

    private void Start()
    {
        rotation = transform.eulerAngles;
    }

    private void FixedUpdate()
    {
        RotationXDomino();
        RotationYDomino();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // TODO : ���� �� ����� ��ġ�� �ٲٱ�.
        {
            if (isClickX)
            {
                isClickY = true;
            }
            isClickX = true;
        }
    }

    private void RotationXDomino()
    {
        if (!isClickX)
        {
            rotation = rotation + new Vector3(rotationDomino, 0.0f, 0.0f) * Time.fixedDeltaTime;
            transform.rotation = Quaternion.Euler(rotation);
        }
    }

    private void RotationYDomino()
    {
        if (!isClickX)
        {
            return;
        }
        if (!isClickY)
        {
            rotation = rotation + new Vector3(0.0f, rotationDomino, 0.0f) * Time.fixedDeltaTime;
            transform.rotation = Quaternion.Euler(rotation);
        }
    }
}
