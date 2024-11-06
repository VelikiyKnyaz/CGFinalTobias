using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class AnimationController : MonoBehaviour
{
    public GameObject playButton;
    public GameObject pauseButton;
    public PlayableDirector playableDirector;

    void Start()
    {
        // El bot�n de Pause est� desactivado inicialmente
        pauseButton.SetActive(false);

        // Asegurarse de que la animaci�n no se reproduzca autom�ticamente
        playableDirector.Stop();

        // Asignar funciones a los botones
        playButton.GetComponent<Button>().onClick.AddListener(PlayTimeline);
        pauseButton.GetComponent<Button>().onClick.AddListener(PauseTimeline);

        // Suscribirse al evento de finalizaci�n
        playableDirector.stopped += OnTimelineStopped;
    }

    void PlayTimeline()
    {
        playableDirector.Play();

        playButton.SetActive(false);
        pauseButton.SetActive(true);
    }

    void PauseTimeline()
    {
        playableDirector.time = playableDirector.time;  // Mantener la posici�n actual de la animaci�n
        playableDirector.Pause();

        playButton.SetActive(true);
        pauseButton.SetActive(false);
    }

    void OnTimelineStopped(PlayableDirector director)
    {
        playButton.SetActive(true);
        pauseButton.SetActive(false);
    }
}
