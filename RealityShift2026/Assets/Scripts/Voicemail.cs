using UnityEngine;
using System.Collections;

public class VoicemailHandler : MonoBehaviour
{
    [SerializeField] private Texture idleSlide;
    [SerializeField] private Texture playingSlide;
    [SerializeField] private Texture transcriptSlide;

    [SerializeField] private AudioSource recording;

    [SerializeField] private Renderer screenRenderer;
    
    void Awake()
    {
        screenRenderer.material.mainTexture = idleSlide;
        StartCoroutine(PlayVoicemail());
    }

    private IEnumerator PlayVoicemail()
    {
        yield return new WaitForSecondsRealtime(5f);
        screenRenderer.material.mainTexture = playingSlide;
        recording.Play();
        yield return new WaitForSecondsRealtime(20f);
        screenRenderer.material.mainTexture = transcriptSlide;
    }
}
