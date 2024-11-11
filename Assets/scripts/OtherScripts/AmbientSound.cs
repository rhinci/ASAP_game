using UnityEngine;

public class AmbientSound : MonoBehaviour
{
    public AudioClip ambientClip; // Ссылка на аудиодорожку
    private AudioSource audioSource;

    void Start()
    {
        // Добавляем компонент AudioSource к объекту
        audioSource = gameObject.AddComponent<AudioSource>();

        // Устанавливаем аудиодорожку
        audioSource.clip = ambientClip;

        // Включаем зацикливание
        audioSource.loop = true;

        // Запускаем воспроизведение
        audioSource.Play();
    }
}
