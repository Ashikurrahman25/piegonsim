using UnityEngine;

public class AnimationBird : MonoBehaviour
{
    public Animator anim;
    public float hopDelay;
    public string hopAnimName;

    public bool isGrounded;
    float t=0;
    public InputHandle input;
    public Flight flight;

    private void Update()
    {
        flight.isFlyig = !isGrounded;

        if (t < 0)
        {
            t = hopDelay;
            bool pressing = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)
                || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow)
                || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A)
                || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || flight.holdingButton;
            if (isGrounded && pressing)
            anim.Play(hopAnimName);

        }
        else
        {
            t-=Time.deltaTime;
        }
    }
}
