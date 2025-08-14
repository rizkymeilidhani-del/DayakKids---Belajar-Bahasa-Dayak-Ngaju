using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Fungsi ini akan Anda panggil dari tombol
    public void QuitGame()
    {
        // Memberi pesan di console Unity untuk memastikan tombol berfungsi
        Debug.Log("Keluar dari game...");

        // Perintah untuk menutup aplikasi
        Application.Quit();
    }
}