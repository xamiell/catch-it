using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    [SerializeField] AudioSource musicBackground;

    // Particles ref to instantiate
    [SerializeField] ParticleSystem particlesBackground;

    private static int _sceneCount = default;
    private static ParticleSystem _particles;

    private void Start()
    {
        if (_sceneCount == default)
        {
            _particles = Instantiate(particlesBackground);
            _particles.gameObject.SetActive(true);

            DontDestroyOnLoad(this);
            DontDestroyOnLoad(musicBackground);
            DontDestroyOnLoad(_particles);

            musicBackground.Play();
            _sceneCount = 1;
        }
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("MainScene");
        ParticlesLoader(true, false);
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    public void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnScoresButtonClick()
    {
        SceneManager.LoadScene("ScoresScene");
    }

    public void OnGameOver()
    {
        SceneManager.LoadScene("GameOver");
        ParticlesLoader(false, true);
    }

    private void ParticlesLoader(bool isActive, bool setActive)
    {
        if (_particles.gameObject.activeSelf == isActive)
        {
            _particles.gameObject.SetActive(setActive);
        }
    }
}
