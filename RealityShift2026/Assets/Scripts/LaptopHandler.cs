using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaptopHandler : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private List<Sprite> slideshow = new List<Sprite>();
    private int currentIndex = 0;
    private int maxIndex = 0;

    void Awake()
    {
        maxIndex = slideshow.Count;
    }

    public void NextImage()
    {
        if (currentIndex + 1 < maxIndex)
        {
            currentIndex += 1;
            image.sprite = slideshow[currentIndex];
        }
    }
}