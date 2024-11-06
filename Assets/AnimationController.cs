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
        // El botón de Pause está desactivado inicialmente
        pauseButton.SetActive(false);

        // Asegurarse de que la animación no se reproduzca automáticamente
        playableDirector.Stop();

        // Asignar funciones a los botones
        playButton.GetComponent<Button>().onClick.AddListener(PlayTimeline);
        pauseButton.GetComponent<Button>().onClick.AddListener(PauseTimeline);

        // Suscribirse al evento de finalización
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
        playableDirector.time = playableDirector.time;  // Mantener la posición actual de la animación
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
