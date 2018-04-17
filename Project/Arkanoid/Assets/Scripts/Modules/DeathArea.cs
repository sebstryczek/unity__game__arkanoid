using UnityEngine;
using UnityEngine.Events;

public class DeathArea : MonoBehaviour
{
    [SerializeField] private UnityEvent onDeath;

    private void Start()
    {
        Transform selfTransform = this.transform;
        selfTransform.position = new Vector2(0, -Utils.Viewport.Height / 2);
        selfTransform.localScale = new Vector2(Utils.Viewport.Width, 1);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        this.onDeath.Invoke();
    }
}
