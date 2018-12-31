using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f,1f)]
    public float volume = 0.7f;
    public float pitch = 1f;


    private AudioSource source;

        public void SetSource (AudioSource _source)
    {
        source = _source;
        source.clip = clip;
    }
    public void Play ()
    {
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
    }
}


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField]
    Sound[] sounds;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one audio manager running in the scene");
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());

        }
    }
    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }

        }
        Debug.LogWarning("SOUND NOT FOUND");
    }

};
