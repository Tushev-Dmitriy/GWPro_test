using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//тест под клавиатуру
public class ButtonHoldTester : MonoBehaviour
{
    [SerializeField] private ButtonHold _target;

    private void Update()
    {
        if (_target == null) return; 
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _target.PressStart();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _target.PressEnd();
        }
    }
}
