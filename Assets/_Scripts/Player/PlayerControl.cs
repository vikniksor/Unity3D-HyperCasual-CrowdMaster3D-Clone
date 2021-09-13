using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControl : MonoBehaviour
{
    private Vector3 _tapPosition;

    public event UnityAction<Vector2> DirectionChange;
    public event UnityAction PointerUp;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) { _tapPosition = Input.mousePosition; }

        if (Input.GetMouseButton(0)) { DirectionChange?.Invoke(Input.mousePosition - _tapPosition); }

        if (Input.GetMouseButtonUp(0)) { PointerUp?.Invoke(); }
          


    }
}
