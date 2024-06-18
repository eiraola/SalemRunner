public class Constants 
{
    public static string TAG_PLAYER = "Player";
    public static string TAG_DAMAGER = "Damager";

    public static string SCENE_NAME_GAME = "S_Game";
    public static string SCENE_NAME_MAINMENU = "S_MainMenu";
    public static string SCENE_NAME_SYSTEM = "S_System";

    public static string SceneName(EScenes scene)
    {
        switch (scene)
        {
            case EScenes.MainMenu:
                return SCENE_NAME_MAINMENU;
            case EScenes.Game:
                return SCENE_NAME_GAME;
            default:
                return SCENE_NAME_MAINMENU;
        }
    }
}
