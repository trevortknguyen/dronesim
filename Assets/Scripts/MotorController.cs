using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Motors are zero-based indexed
 */
public interface MotorController {
    int GetMotorInput(int index);
}
