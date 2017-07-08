using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMockInput : MotorController {

    int MotorController.GetMotorInput(int index)
    {
        if (index == 0)
        {
            return Input.GetKey(KeyCode.Q) ? 20 : 0;
        } else if (index == 1)
        {
            return Input.GetKey(KeyCode.Q) ? 20 : 0;
        } else if (index == 2)
        {
            return Input.GetKey(KeyCode.P) ? 20 : 0;
        } else if (index == 3)
        {
            return Input.GetKey(KeyCode.P) ? 20 : 0;
        } else
        {
            throw new NotSupportedException();
        }
    }
}
