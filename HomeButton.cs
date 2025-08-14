using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    // Ganti nama scene sesuai dengan yang kamu pakai
    public string sceneName = "Kurikulum 1";

    public void LoadPlayScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
