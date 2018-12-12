using UnityEngine;

public static class GlobalValues {

    public static float TimeLeft { get; set; }
    public static bool Running { get; set; }
    public static bool Lost { get; set; }
    public static bool Won { get; set; }
    public static GameObject CurrentCar { get; set; }
    public static Stage CurrentStage { get; set; }

    static GlobalValues()
    {
        Init();
    }

    public static void Init()
    {
        TimeLeft = 60;
        Running = false;
        Lost = false;
        Won = false;
        CurrentCar = null;
        CurrentStage = Stage1.Instance;
    }
}
