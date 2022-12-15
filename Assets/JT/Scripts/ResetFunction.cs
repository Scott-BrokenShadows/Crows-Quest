using UnityEngine.SceneManagement;
using UnityEngine;

public class ResetFunction : MonoBehaviour
{
    public string _goToScene;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(_goToScene);
        }
    }
}
