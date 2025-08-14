using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    public void Play()
    {
        // Cari SoundManager yang sedang aktif dan panggil fungsinya
        if (SoundManager.instance != null)
        {
            SoundManager.instance.PlaySuaraTombol();
        }
    }
}