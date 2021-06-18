using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class PlayerState {
    public static long score = 0;
    public static int life = 3;

    public static void Reset() {
        score = 0;
        life = 3;
    }
}