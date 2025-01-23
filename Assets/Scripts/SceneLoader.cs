using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName;
    
    public void StartGame()
    {
        StartCoroutine(LoadSceneCoroutine());
        
        
    }

    private IEnumerator LoadSceneCoroutine()
    {
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(gameSceneName, LoadSceneMode.Additive);
        yield return new WaitUntil(() => asyncOp.isDone);
        var newScene = SceneManager.GetSceneByName(gameSceneName);
        SceneManager.SetActiveScene(newScene);
    }
}
