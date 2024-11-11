using UnityEngine;

public class SlideShow : MonoBehaviour
{
    public AudioSource audioSource; // Ссылка на AudioSource
    public AudioClip[] audioClips; // Массив аудиодорожек
    private int currentSlideIndex = 0; // Индекс текущего слайда

    void Start()
    {
        PlayAudio(currentSlideIndex); // Воспроизвести первую аудиодорожку при загрузке сцены
    }

    public void NextSlide()
    {
        if (currentSlideIndex < audioClips.Length - 1)
        {
            currentSlideIndex++; // Переход к следующему слайду
            PlayAudio(currentSlideIndex); // Воспроизвести соответствующую аудиодорожку
        }
    }

    private void PlayAudio(int index)
    {
        audioSource.Stop(); // Остановить текущее воспроизведение
        audioSource.clip = audioClips[index]; // Установить новую аудиодорожку
        audioSource.Play(); // Воспроизвести новую аудиодорожку
    }
}

