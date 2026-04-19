using UnityEngine;

public class SlideShow : MonoBehaviour
{
    public Texture[] slides;
    public Renderer screenRenderer;

    public float slideDuration = 2f; // seconds per slide

    private int currentSlide = 0;
    private float timer = 0f;

    void Start()
    {
        ShowSlide(0);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= slideDuration)
        {
            NextSlide();
            timer = 0f;
        }
    }

    void ShowSlide(int index)
    {
        if (slides.Length == 0) return;

        screenRenderer.material.mainTexture = slides[index];
    }

    void NextSlide()
    {
        currentSlide = (currentSlide + 1) % slides.Length;
        ShowSlide(currentSlide);
    }
}