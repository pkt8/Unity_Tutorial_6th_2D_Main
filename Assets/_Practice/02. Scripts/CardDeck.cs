using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    public List<string> deck = new List<string>(){"A", "B", "C", "D", "E", "F", "G", "H"};

    public Stack<string> deckStack = new Stack<string>();
    
    public int shakeCount = 100;

    IEnumerator Start()
    {
        PrintDeck();

        yield return new WaitForSeconds(1);
        ShuffleDeck();
        Debug.Log("카드 섞기 완료");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            DrawCard();

        if (Input.GetKeyDown(KeyCode.Return))
            Debug.Log($"다음 카드는 {deckStack.Peek()}입니다.");
    }

    private void PrintDeck()
    {
        string str = "";

        foreach (var card in deck)
        {
            str += $"{card}, ";
        }

        Debug.Log(str);
    }

    private void ShuffleDeck()
    {
        // Shuffle 기능
        for (int i = 0; i < shakeCount; i++)
        {
            int ranIndex1 = Random.Range(0, deck.Count);
            int ranIndex2 = Random.Range(0, deck.Count);
        
            // Swap 기능
            var temp = deck[ranIndex1];
            deck[ranIndex1] = deck[ranIndex2];
            deck[ranIndex2] = temp;
        }
        
        deckStack = new Stack<string>(deck); // List를 Stack으로 변환
    }

    private void DrawCard()
    {
        if (deck.Count == 0)
        {
            Debug.Log("카드가 없습니다.");
            return;
        }

        string card = deckStack.Pop();
        
        // string card = deck[0];
        // deck.RemoveAt(0);
        //
        // string card2 = deck[deck.Count - 1];
        // deck.RemoveAt(deck.Count - 1);

        Debug.Log($"현재 뽑은 카드 : {card}");
    }
}