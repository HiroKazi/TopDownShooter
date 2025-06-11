using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject asteroid;
    public Vector3 spawnValues;
    public int hazardCount;
    public float startWait;
    public float spawnWait;
    public float waveWait;

    public bool isPaused;

    [Header("Scene Index")]
    [SerializeField] private int sceneIndex = 0;

    [Header("Gameplay Buttons")]
    public Button buttonResume;
    public Button buttonPause;
    public Button buttonMenu;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());
        buttonPause.onClick.AddListener(HandleButtonClick);
        buttonResume.onClick.AddListener(HandleButtonClick);
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(asteroid, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);

            }
            yield return new WaitForSeconds(waveWait);
        }
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    private void HandleButtonClick()
    {
        if (isPaused)
        {
            Resume();
            buttonPause.gameObject.SetActive(true);
            buttonResume.gameObject.SetActive(false);
        }
        else
        {
            Pause();
            buttonPause.gameObject.SetActive(false);
            buttonResume.gameObject.SetActive(true);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }
}
