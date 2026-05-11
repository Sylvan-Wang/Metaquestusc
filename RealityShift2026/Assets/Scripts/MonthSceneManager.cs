using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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

    [Header("Timer")]
    public float timeLimit = 60f;

    [Header("UI")]
    public TextMeshProUGUI timerText;

    private float timer = 0f;
    private int currentIndex = 0;
    private bool isTransitioning = false;

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
        FindTimerText();
    }

    void Update()
    {
        if (isTransitioning) return;

        timer += Time.deltaTime;

        float remaining = Mathf.Max(0, timeLimit - timer);

        UpdateTimerUI(remaining);

        if (timer >= timeLimit)
        {
            Debug.Log("Time ran out!");
            LoadNextMonth();
        }
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
        timer = 0f;
        isTransitioning = false;

        FindSun();
        ApplyLighting();

        FindTimerText();
    }

    void FindTimerText()
    {
        GameObject timerObj =
            GameObject.FindGameObjectWithTag("Timer");

        if (timerObj != null)
        {
            timerText =
                timerObj.GetComponent<TextMeshProUGUI>();

            // if TMP is on a child object
            if (timerText == null)
            {
                timerText =
                    timerObj.GetComponentInChildren<TextMeshProUGUI>();
            }
        }

        if (timerText == null)
        {
            Debug.LogWarning("Timer UI not found!");
        }
    }

    void UpdateTimerUI(float timeRemaining)
    {
        if (timerText == null) return;

        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);

        if (currentIndex >= 4)
        {
            timerText.text = "LOST TRACK OF TIME";
        }
        else
        {
            timerText.text =
                minutes.ToString("00") +
                ":" +
                seconds.ToString("00");
        }
    }

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

    void ApplyLighting()
    {
        float[] sunAngles = {
            60f,
            60f,
            120f,
            170f,
            210f
        };

        Color[] sunColors = {
            new Color(1f, 0.95f, 0.8f),
            Color.white,
            new Color(1f, 0.7f, 0.5f),
            new Color(1f, 0.5f, 0.3f),
            new Color(0.3f, 0.35f, 0.6f)
        };

        if (sun != null && currentIndex < sunAngles.Length)
        {
            sun.transform.rotation = Quaternion.Euler(sunAngles[currentIndex], 0f, 0f);
            sun.color = sunColors[currentIndex];
        }

        Debug.Log("Time of day set for month: " + currentIndex);
    }

    public void LoadNextMonth()
    {
        if (isTransitioning) return;

        isTransitioning = true;

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
        isTransitioning = true;

        SceneManager.LoadScene(months[currentIndex]);
    }

    public int GetCurrentMonthIndex()
    {
        return currentIndex;
    }
}