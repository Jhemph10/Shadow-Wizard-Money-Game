using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clips")]
    public AudioClip GameTheme;
    public AudioClip TitleSCreen;
    public AudioClip MenuScreen;
    public AudioClip TutorialTheme;//same song fast;
    public AudioClip WinTheme;//same sing reg;
    public AudioClip LoseTheme;//Same song slow;
    public AudioClip ShotgunShot;
    public AudioClip ShotgunShell;
    public AudioClip ReloadSound;
    public AudioClip RifleShot;
    public AudioClip Jump;
    public AudioClip Walk;
    public AudioClip Running;

    private void Start()
    {
        musicSource.clip = MenuScreen;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
