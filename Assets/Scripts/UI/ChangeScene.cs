using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private SceneAsset sceneToLoad;

    public void LoadSelectedScene()
    {
        SceneManager.LoadScene(sceneToLoad.name);
    }
}
