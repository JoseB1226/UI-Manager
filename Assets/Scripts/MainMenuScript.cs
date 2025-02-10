using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip buttonClickSound; // Reference for button click sound

    private void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.loop = true; // Ensure looping is enabled for background music
            audioSource.Play();
        }
    }

    // Method to play the button click sound
    public void PlayButtonClickSound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound); // Play the click sound once
        }
    }

    public void PlayGame()
    {
        PlayButtonClickSound(); // Play sound when clicking "Play"
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        PlayButtonClickSound(); // Play sound when clicking "Quit"
        Debug.Log("QUIT!");
        Application.Quit();
    }


}
