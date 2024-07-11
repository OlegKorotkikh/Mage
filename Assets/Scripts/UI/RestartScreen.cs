using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScreen : MonoBehaviour
{
    public void RestartClicked()
    {
        SceneManager.LoadScene(0);
    }
}
