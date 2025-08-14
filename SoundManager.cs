using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Membuat script ini bisa diakses dari mana saja (Singleton)
    public static SoundManager instance;

    // Siapkan AudioSource khusus untuk SFX
    public AudioSource sfxSource;

    // Siapkan slot untuk setiap suara di Inspector
    public AudioClip soundTombolKlik;
    public AudioClip soundJawabanBenar;
    public AudioClip soundJawabanSalah;

    void Awake()
    {
        // Pengaturan Singleton agar object ini abadi dan hanya ada satu
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // --- Fungsi untuk memanggil setiap suara ---

    public void PlaySuaraTombol()
    {
        sfxSource.PlayOneShot(soundTombolKlik);
    }

    public void PlaySuaraBenar()
    {
        sfxSource.PlayOneShot(soundJawabanBenar);
    }

    public void PlaySuaraSalah()
    {
        sfxSource.PlayOneShot(soundJawabanSalah);
    }
}