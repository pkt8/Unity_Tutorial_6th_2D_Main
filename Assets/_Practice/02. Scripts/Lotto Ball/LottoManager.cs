using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LottoManager : MonoBehaviour
{
    public LottoBall[] balls;

    public Button lottoButton;
    
    private List<int> numbers = new List<int>();
    public int shakeCount = 1000;
    
    public List<int> lottoNumbers = new List<int>();
    public int bonusNumber;

    void Start()
    {
        lottoButton.onClick.AddListener(CreateNumber);
    }

    private void CreateNumber()
    {
        numbers.Clear();
        for (int i = 1; i < 46; i++)
            numbers.Add(i);
        
        ShakeNumber();
    }
    
    
    private void ShakeNumber()
    {
        for (int i = 0; i < shakeCount; i++)
        {
            int randomIndex1 = Random.Range(0, 45); // 0 ~ 44번까지의 랜덤 자리수
            int randomIndex2 = Random.Range(0, 45); 
            
            // Swap : 자리 바꾸기
            int temp = numbers[randomIndex1];
            numbers[randomIndex1] = numbers[randomIndex2];
            numbers[randomIndex2] = temp;
        }
        
        PickNumber();
    }

    private void PickNumber()
    {
        lottoNumbers.Clear();
        for (int i = 0; i < 6; i++)
            lottoNumbers.Add(numbers[i]); // 섞인 numbers의 숫자 6개를 lottoNumbers로 복사하는 기능
        
        lottoNumbers.Sort(); // 오름차순 정렬
        bonusNumber = numbers[6]; // 보너스 넘버 복사

        for (int i = 0; i < 6; i++)
            balls[i].SetNumber(lottoNumbers[i]);
        
        balls[6].SetNumber(bonusNumber);

        for (int i = 0; i < balls.Length; i++)
            balls[i].GetComponent<Animator>().SetTrigger("ScaleUp");
    }
}