using UnityEngine;
using System.Collections.Generic;

public class KartuSlider : MonoBehaviour
{
    [Tooltip("Masukkan semua panel kartu belajar untuk level ini.")]
    public List<GameObject> daftarKartu;

    [Tooltip("Tombol yang akan muncul di kartu terakhir untuk memulai kuis.")]
    public GameObject tombolMulaiKuis; // Ini akan menjadi PanelKuis Anda

    private int indexSaatIni = 0;

    // Fungsi ini otomatis terpanggil setiap kali GameObject ini diaktifkan
    void OnEnable()
    {
        // Selalu mulai dari kartu pertama saat level baru dimuat
        indexSaatIni = 0;
        TampilkanKartu();
    }

    void TampilkanKartu()
    {
        // 1. Matikan semua kartu terlebih dahulu
        for (int i = 0; i < daftarKartu.Count; i++)
        {
            if (daftarKartu[i] != null) daftarKartu[i].SetActive(false);
        }

        // 2. Nyalakan hanya kartu yang sedang dipilih
        if (daftarKartu.Count > 0)
        {
            daftarKartu[indexSaatIni].SetActive(true);
        }

        // 3. Cek apakah harus menampilkan tombol untuk mulai kuis
        if (tombolMulaiKuis != null)
        {
            // Tombol "Mulai Kuis" hanya aktif jika kita berada di kartu terakhir
            bool diKartuTerakhir = (indexSaatIni == daftarKartu.Count - 1);
            tombolMulaiKuis.SetActive(diKartuTerakhir);
        }
    }

    public void NextKartu()
    {
        // Jangan lanjut jika sudah di kartu terakhir
        if (indexSaatIni < daftarKartu.Count - 1)
        {
            indexSaatIni++;
            TampilkanKartu();
        }
    }

    public void PrevKartu()
    {
        // Jangan mundur jika sudah di kartu pertama
        if (indexSaatIni > 0)
        {
            indexSaatIni--;
            TampilkanKartu();
        }
    }
}