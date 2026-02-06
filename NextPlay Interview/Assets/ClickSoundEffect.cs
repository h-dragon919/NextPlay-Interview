using UnityEngine;

public class ClickSoundEffect : MonoBehaviour
{
    AudioSource soundEffect;
    void Start()
    {
        soundEffect = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            soundEffect.Play();
        }
    }
}
