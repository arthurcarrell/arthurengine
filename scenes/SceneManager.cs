namespace arthurengine.Scenes;
using System.Collections.Generic;

public abstract class SceneManager
{
    private static List<Scene> scenes = new List<Scene>();
    private static Scene loadedScene = null;
    public static List<Scene> GetScenes() { return scenes; }
    public static Scene GetLoadedScene() { return loadedScene; }
    public static void LoadScene(Scene scene) => loadedScene = scene;
    public static void AddScene(Scene scene) => scenes.Add(scene);

    public static Scene GetSceneByID(string id)
    {
        foreach (Scene scene in scenes)
        {
            if (scene.GetID() == id)
            {
                return scene;
            }
        }
        throw new KeyNotFoundException("No Scene with ID found!");
    }

}
