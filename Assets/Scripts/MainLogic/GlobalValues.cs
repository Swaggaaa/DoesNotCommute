using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalValues {

    public static float TimeLeft { get; set; }
    public static bool Running { get; set; }
    public static bool Lost { get; set; }
    public static bool Won { get; set; }

    static GlobalValues()
    {
        TimeLeft = 60;
        Running = true;
        Lost = false;
        Won = false;
    }
}
