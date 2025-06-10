using UnityEngine;

public class soundFXmanager : MonoBehaviour
{
    //make a singleton
    public static soundFXmanager instance;
    [SerializeField] private AudioSource soundFXobject;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void playsoundeffect(AudioClip audioClip, Transform spawnTransform)
    {
        AudioSource audioSource = Instantiate(soundFXobject, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);
    }
}
