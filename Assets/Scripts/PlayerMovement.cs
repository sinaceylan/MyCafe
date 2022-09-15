using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float movementSpeed;
    [SerializeField] public float rotatianSpeed=500;

    private Touch _touch;
    private Vector3 _touchDown;
    private Vector3 _touchUp;
    private bool _isMoving;
    private bool _dragStarted;

    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (anim)
        {
            anim.SetBool("Moving",_isMoving);
        }

        if (Input.touchCount>0)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Began)
            {
                _dragStarted = true;
                _isMoving = true;
                _touchDown = _touch.position;
                _touchUp = _touch.position;
            }
        }

        if (_dragStarted == true)
        {
            if (_touch.phase == TouchPhase.Moved)
            {
                _touchDown = _touch.position;
            }
            if (_touch.phase == TouchPhase.Ended)
            {
                _touchDown = _touch.position;
                _dragStarted = false;
                _isMoving = false;
            }
            gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation,CalculateRotation(), rotatianSpeed*Time.deltaTime);
            gameObject.transform.Translate(Vector3.forward*movementSpeed*Time.deltaTime);
        }

        Quaternion CalculateRotation()
        {
            Quaternion temp = Quaternion.LookRotation(CalculateDistance(),Vector3.up);
            return temp;
        }   
        
        Vector3 CalculateDistance()
        {
            Vector3 temp = (_touchDown - _touchUp).normalized;
            temp.z = temp.y;
            temp.y = 0;
            return temp;
        }   
    }
}
