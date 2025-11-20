using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CatUIManager : MonoBehaviour
{
    public CatSoundManager sound;
    public GameObject cat;
    public GameObject fadeUI;

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
    public bool isPlay;

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
    }

    private void SetTimer()
    {
        timer += Time.deltaTime;
        timerUI.text = $"{timer:F1}초";

        // timer = Time.time; // 유니티 실행한 시점으로부터의 누적 시간
        // sec += Time.deltaTime;
        // if (sec >= 60f)
        // {
        //     sec -= 60f;
        //     min++;
        // }
        //
        // timerUI.text = $"{min} : {sec:F0}";
    }

    public void GameOver() // Play -> Outro
    {
        fadeUI.SetActive(true);
        
        sound.MuteSound(true);
        // playObjs[0].SetActive(false);
        playObjs[1].SetActive(false);
        // outroUI.SetActive(true);
        isPlay = false;
        gameOverTime.text = $"플레이 시간 : {timer:F1}초";
        gameOverFruitCount.text = $"획득한 과일의 수 : {fruitCount}개";
        
        cat.GetComponent<CircleCollider2D>().enabled = false;
    }

    private void RestartEvent() // Outro -> Play
    {
        fadeUI.SetActive(false);
        
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