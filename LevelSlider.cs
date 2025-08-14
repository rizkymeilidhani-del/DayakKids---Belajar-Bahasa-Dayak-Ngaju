using UnityEngine;
using System.Collections.Generic;

public class LevelSlider : MonoBehaviour
{
    // Masukkan semua panel kurikulum Anda di sini
    public List<GameObject> daftarPanelLevel;
    
    private int indexHalamanSaatIni = 0;

    void Start()
    {
        // Pastikan hanya halaman pertama yang muncul saat mulai
        TampilkanHalaman(0);
    }

    // Fungsi untuk tombol panah KANAN
    public void HalamanBerikutnya()
    {
        if (indexHalamanSaatIni < daftarPanelLevel.Count - 1)
        {
            indexHalamanSaatIni++;
            TampilkanHalaman(indexHalamanSaatIni);
        }
    }

    // Fungsi untuk tombol panah KIRI
    public void HalamanSebelumnya()
    {
        if (indexHalamanSaatIni > 0)
        {
            indexHalamanSaatIni--;
            TampilkanHalaman(indexHalamanSaatIni);
        }
    }

    void TampilkanHalaman(int index)
    {
        // Matikan semua panel dulu
        foreach (GameObject panel in daftarPanelLevel)
        {
            panel.SetActive(false);
        }
        // Nyalakan hanya panel yang dipilih
        daftarPanelLevel[index].SetActive(true);
    }
}