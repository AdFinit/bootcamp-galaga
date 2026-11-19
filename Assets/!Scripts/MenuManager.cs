using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void StartButton()
    {
        SceneManager.LoadScene(sceneName);
    }
}
