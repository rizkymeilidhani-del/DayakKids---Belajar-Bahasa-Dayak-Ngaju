using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    // Ganti nama scene sesuai dengan yang kamu pakai
    public string sceneName = "Kurikulum";

    public void LoadPlayScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
