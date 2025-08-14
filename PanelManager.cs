using UnityEngine;
using System.Collections.Generic; // Dibutuhkan untuk menggunakan List

public class PanelManager : MonoBehaviour
{
    // Masukkan semua panel Anda lewat Inspector
    public List<GameObject> panels;
    private int currentIndex = 0;

    void Start()
    {
        // Pastikan hanya panel pertama yang aktif saat mulai
        ShowPanel(currentIndex);
    }

    public void ShowNextPanel()
    {
        // Pindah ke panel berikutnya
        currentIndex++;

        // Jika sudah di panel terakhir, kembali ke awal
        if (currentIndex >= panels.Count)
        {
            currentIndex = 0;
        }

        ShowPanel(currentIndex);
    }

    public void ShowPreviousPanel()
    {
        // Pindah ke panel sebelumnya
        currentIndex--;

        // Jika sudah di panel pertama, pindah ke paling akhir
        if (currentIndex < 0)
        {
            currentIndex = panels.Count - 1;
        }

        ShowPanel(currentIndex);
    }

    // Fungsi untuk menampilkan panel yang dipilih dan menyembunyikan yang lain
    void ShowPanel(int indexToShow)
    {
        for (int i = 0; i < panels.Count; i++)
        {
            // Jika panel ini adalah yang ingin ditampilkan, aktifkan. Jika tidak, nonaktifkan.
            panels[i].SetActive(i == indexToShow);
        }
    }
}