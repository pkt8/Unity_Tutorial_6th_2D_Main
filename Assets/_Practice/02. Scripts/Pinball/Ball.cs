using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Point10":
                Debug.Log("10점 획득");
                break;
            case "Point30":
                Debug.Log("30점 획득");
                break;
            case "Point50":
                Debug.Log("50점 획득");
                break;
        }
    }
}