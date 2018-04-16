using UnityEngine;
using UnityEngine.Events;

public class KeyboardEvent : MonoBehaviour
{
    [SerializeField] private KeyCode keyCode;
    [SerializeField] private UnityEvent onKeyUp;

    private void Update()
    {
        if (Input.GetKeyUp(this.keyCode))
        {
            this.onKeyUp.Invoke();
        }
    }
}
