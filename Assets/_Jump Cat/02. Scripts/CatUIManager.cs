using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CatUIManager : MonoBehaviour
{
    private CatSoundManager sound;
    public GameObject cat;
    private CatFade fade;

    public TMP_InputField inputUI;
    public TextMeshProUGUI catNameUI;
    public TextMeshProUGUI fruitCountUI;
    public TextMeshProUGUI timerUI;

    public TextMeshProUGUI gameOverTime;
    public TextMeshProUGUI gameOverFruitCount;

    public Button startButton;
    public Button reStartButton;

    public GameObject introUI;
    public GameObject[] playObjs;
    public GameObject outroUI;

    public static int fruitCount; // 정적변수
    private float timer;
    private bool isPlay;

    void Awake()
    {
        sound = FindFirstObjectByType<CatSoundManager>();
        fade = GetComponent<CatFade>();
    }
    
    void Start()
    {
        startButton.onClick.AddListener(StartEvent); // 스타트 버튼에 StartEvent 함수 등록
        reStartButton.onClick.AddListener(RestartEvent);

        introUI.SetActive(true);

        foreach (var obj in playObjs)
            obj.SetActive(false);

        outroUI.SetActive(false);
    }

    void Update()
    {
        if (!isPlay)
            return;

        SetFruitCount();
        SetTimer();
    }

    private void StartEvent() // Intro -> Play
    {
        if (inputUI.text.Length == 0)
        {
            Debug.Log("고양이의 이름을 작성하세요.");
            return;
        }

        isPlay = true;
        sound.BGMSound(1); // Play 배경음악
        catNameUI.text = inputUI.text; // 입력한 텍스트를 고양이 이름에 적용

        foreach (var obj in playObjs)
            obj.SetActive(true);

        introUI.SetActive(false);
    }

    private void SetFruitCount()
    {
        fruitCountUI.text = $"X {fruitCount}";

        if (fruitCount >= 2)
        {
            GameCompleted();
        }
    }

    private void SetTimer()
    {
        timer += Time.deltaTime;
        timerUI.text = $"{timer:F1}초";
    }

    public void GameOver() // Play -> Outro
    {
        fade.Fade(1f, Color.black, false);
        
        isPlay = false;
        sound.MuteSound(true);
        playObjs[1].SetActive(false);
        gameOverTime.text = $"플레이 시간 : {timer:F1}초";
        gameOverFruitCount.text = $"획득한 과일의 수 : {fruitCount}개";
        
        cat.GetComponent<CircleCollider2D>().enabled = false;
    }

    public void GameCompleted()
    {
        fade.Fade(2f, Color.white, true);
        
        isPlay = false;
        sound.MuteSound(true);
        cat.GetComponent<CircleCollider2D>().enabled = false;
    }

    private void RestartEvent() // Outro -> Play
    {
        fade.fadeUI.gameObject.SetActive(false);
        
        sound.MuteSound(false);
        playObjs[0].SetActive(true);
        playObjs[1].SetActive(true);
        outroUI.SetActive(false);
        cat.GetComponent<CircleCollider2D>().enabled = true;
        timer = 0f;
        fruitCount = 0;
        isPlay = true;
    }
}