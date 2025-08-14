using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    // --- BAGIAN UNTUK MENU KURIKULUM ---
    [Header("Menu Kurikulum (Hanya di Scene Menu)")]
    // Variabel panelMenuKurikulum sudah dihapus karena tidak diperlukan lagi
    public Button[] tombolKurikulum;

    // --- BAGIAN UNTUK SCENE LEVEL ---
    [Header("Konten Level (Hanya di Scene Level)")]
    public List<GameObject> semuaKontenLevel;

    [Header("Panel Feedback Universal")]
    public GameObject panelBenar;
    public GameObject panelSalah;

    // Variabel internal
    private int levelSaatIni;

    void Start()
    {
        // Cek apakah ini scene menu atau scene level
        // Pengecekan sekarang berdasarkan apakah list tombolKurikulum diisi atau tidak
        if (tombolKurikulum != null && tombolKurikulum.Length > 0)
        {
            // Jika di menu, update tampilan gembok
            UpdateTampilanKurikulum();
        }
        else
        {
            // Jika di scene level, muat konten level yang sesuai
            MuatKontenLevel();
        }
    }

    // --- FUNGSI DI SCENE MENU ---
    public void UpdateTampilanKurikulum()
    {
        int highestLevel = PlayerPrefs.GetInt("highestUnlockedLevel", 1);
        for (int i = 0; i < tombolKurikulum.Length; i++)
        {
            if (tombolKurikulum[i] == null) continue;
            bool isUnlocked = (i + 1) <= highestLevel;
            tombolKurikulum[i].interactable = isUnlocked;
            tombolKurikulum[i].transform.Find("GembokTerkunci")?.gameObject.SetActive(!isUnlocked);
            tombolKurikulum[i].transform.Find("GembokTerbuka")?.gameObject.SetActive(isUnlocked);
        }
    }

    public void PilihKurikulum(int level)
    {
        PlayerPrefs.SetInt("levelYangDipilih", level);
        SceneManager.LoadScene("Kurikulum 1"); // Sesuaikan dengan nama scene level Anda
    }

    // --- FUNGSI DI SCENE LEVEL ---
    void MuatKontenLevel()
    {
        if (panelBenar != null) panelBenar.SetActive(false);
        if (panelSalah != null) panelSalah.SetActive(false);

        levelSaatIni = PlayerPrefs.GetInt("levelYangDipilih", 1);

        foreach (GameObject konten in semuaKontenLevel)
        {
            if (konten != null) konten.SetActive(false);
        }

        if (semuaKontenLevel.Count >= levelSaatIni)
        {
            semuaKontenLevel[levelSaatIni - 1].SetActive(true);
        }
    }

    public void TombolJawabanDitekan(bool adalahJawabanBenar)
    {
        StartCoroutine(ProsesJawabanCoroutine(adalahJawabanBenar));
    }

    IEnumerator ProsesJawabanCoroutine(bool adalahJawabanBenar)
    {
        if (semuaKontenLevel.Count >= levelSaatIni)
        {
            semuaKontenLevel[levelSaatIni - 1].SetActive(false);
        }

        yield return null;

        if (adalahJawabanBenar)
        {
            if (panelBenar != null) panelBenar.SetActive(true);
            UnlockLevelBerikutnya();
        }
        else
        {
            if (panelSalah != null) panelSalah.SetActive(true);
        }
    }

    void UnlockLevelBerikutnya()
    {
        int levelToUnlock = levelSaatIni + 1;
        int highestLevel = PlayerPrefs.GetInt("highestUnlockedLevel", 1);
        if (levelToUnlock > highestLevel)
        {
            PlayerPrefs.SetInt("highestUnlockedLevel", levelToUnlock);
            PlayerPrefs.Save();
        }
    }

    public void TombolLanjutKurikulum()
    {
        SceneManager.LoadScene("Kurikulum"); // Sesuaikan dengan nama scene menu Anda
    }

    public void TombolJawabUlang()
    {
        panelSalah.SetActive(false);
        semuaKontenLevel[levelSaatIni - 1].SetActive(true);
    }
}