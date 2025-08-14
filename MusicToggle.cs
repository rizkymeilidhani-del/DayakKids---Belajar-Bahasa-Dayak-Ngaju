using UnityEngine;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour
{
    // --- TAMBAHAN DIMULAI ---
    // Membuat variabel statis untuk menyimpan satu-satunya instance dari script ini
    public static MusicToggle instance;

    void Awake()
    {
        // Logika untuk membuat object ini "abadi" dan mencegah duplikat
        if (instance != null)
        {
            // Jika sudah ada MusicPlayer, hancurkan yang baru ini
            Destroy(gameObject);
        }
        else
        {
            // Jika ini yang pertama, simpan sebagai instance utama dan jangan hancurkan
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // --- TAMBAHAN SELESAI ---


    // --- KODE LAMA (TIDAK DIUBAH) ---
    public GameObject musicOnIcon;
    public GameObject musicOffIcon;
    public AudioSource musicSource;

    private void Start()
    {
        // Cek status musik saat start
        if (PlayerPrefs.GetInt("MusicState", 1) == 1)
        {
            musicSource.Play();
            musicOnIcon.SetActive(true);
            musicOffIcon.SetActive(false);
        }
        else
        {
            musicSource.Pause();
            musicOnIcon.SetActive(false);
            musicOffIcon.SetActive(true);
        }
    }

    public void ToggleMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Pause();
            musicOnIcon.SetActive(false);
            musicOffIcon.SetActive(true);
            PlayerPrefs.SetInt("MusicState", 0);
        }
        else
        {
            musicSource.Play();
            musicOnIcon.SetActive(true);
            musicOffIcon.SetActive(false);
            PlayerPrefs.SetInt("MusicState", 1);
        }
    }
}