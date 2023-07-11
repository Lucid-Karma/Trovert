using UnityEngine;

public class HeadBob : MonoBehaviour
{
    //[Header ("Head Bob Parameters")]
    float bobbingSpeed = 4f;    
    float bobbingAmount = .1f;  //0.05f;   
    //[Space]
    private float timer = 0.0f;
    private float midpoint = 0.0f;
    private bool isMoving = false;

    CharacterFSM characterFSM;
    CharacterFSM CharacterFSM { get { return (characterFSM == null) ? characterFSM = GetComponentInParent<CharacterFSM>() : characterFSM; } }

    

    private void Start()
    {
        midpoint = transform.localPosition.y;
    }

    private void Update()
    {
        if (CharacterFSM.executingState == ExecutingState.WALK || CharacterFSM.executingState == ExecutingState.SPRINT)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            timer += bobbingSpeed * Time.deltaTime;
            transform.localPosition = new Vector3(transform.localPosition.x, midpoint + Mathf.Sin(timer) * bobbingAmount, transform.localPosition.z);
        }
        else
        {
            timer = 0.0f;
            transform.localPosition = new Vector3(transform.localPosition.x, midpoint, transform.localPosition.z);
        }
    }
}
