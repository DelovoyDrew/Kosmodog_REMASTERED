using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public void LoadToScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

}
