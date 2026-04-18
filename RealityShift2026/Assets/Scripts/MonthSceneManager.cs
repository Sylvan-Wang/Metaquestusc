using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MonthSceneManager : MonoBehaviour
{
    public static MonthSceneManager Instance;

    [Header("Scene Order")]
    public string[] months = {
        "Month1",
        "Month2",
        "Month4",
        "Month6",
        "Month8"
    };

    private int currentIndex = 0;

    // 🌞 Current scene's directional light (NOT persistent)
    private Light sun;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        FindSun();
        ApplyLighting();
        // StartCoroutine(AutoSwitch());
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindSun();        // re-find light in new scene
        ApplyLighting();  // apply correct time of day
    }

    // 🔍 Find directional light in current scene
    void FindSun()
    {
        Light[] lights = FindObjectsOfType<Light>();

        foreach (var l in lights)
        {
            if (l.type == LightType.Directional)
            {
                sun = l;
                return;
            }
        }

        Debug.LogWarning("No Directional Light found in scene!");
    }

    public void LoadNextMonth()
    {
        currentIndex++;

        if (currentIndex >= months.Length)
        {
            Debug.Log("Reached final month");
            return;
        }

        SceneManager.LoadScene(months[currentIndex]);
    }

    public void LoadMonth(int index)
    {
        if (index < 0 || index >= months.Length) return;

        currentIndex = index;
        SceneManager.LoadScene(months[currentIndex]);
    }

    public int GetCurrentMonthIndex()
    {
        return currentIndex;
    }

    // Apply time-of-day based on month
    void ApplyLighting()
    {
        float[] sunAngles = {
            60f,   // Month 1 → morning
            60f,   // Month 2 → midday
            120f,  // Month 4 → afternoon
            170f,  // Month 6 → sunset
            210f   // Month 8 → night
        };

        Color[] sunColors = {
            new Color(1f, 0.95f, 0.8f),  // warm morning
            Color.white,                 // midday
            new Color(1f, 0.7f, 0.5f),   // afternoon
            new Color(1f, 0.5f, 0.3f),   // sunset
            new Color(0.3f, 0.35f, 0.6f) // night blue
        };

        if (sun != null && currentIndex < sunAngles.Length)
        {
            sun.transform.rotation = Quaternion.Euler(sunAngles[currentIndex], 0f, 0f);
            sun.color = sunColors[currentIndex];
        }

        Debug.Log("Time of day set for month: " + currentIndex);
    }

    IEnumerator AutoSwitch()
    {
        while (currentIndex < months.Length - 1)
        {
            yield return new WaitForSecondsRealtime(5f);
            LoadNextMonth();
        }
    }
}