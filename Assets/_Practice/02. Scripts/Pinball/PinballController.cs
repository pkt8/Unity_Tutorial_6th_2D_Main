using UnityEngine;

public class PinballController : MonoBehaviour
{
    public Rigidbody2D leftHandleRb;
    public Rigidbody2D rightHandleRb;

    public float pushPower = 10f;
    public float releasePower = 30f;

    private bool isLeftUp, isRightUp;

    private int score;

    void Update()
    {
        isLeftUp = Input.GetKey(KeyCode.LeftArrow);
        isRightUp = Input.GetKey(KeyCode.RightArrow);
    }

    void FixedUpdate()
    {
        if (isLeftUp)
            leftHandleRb.AddTorque(pushPower, ForceMode2D.Impulse);
        else
            leftHandleRb.AddTorque(-releasePower);

        if (isRightUp)
            rightHandleRb.AddTorque(-pushPower, ForceMode2D.Impulse);
        else
            rightHandleRb.AddTorque(releasePower);
    }

    public void SetScore(int point)
    {
        Debug.Log(point + "점 획득");
        
        score += point;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public int GetScore()
    {
        return score;
    }
}