using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Trapdoor : MonoBehaviour
{
    [SerializeField] private bool isOpen = true;
    [SerializeField] private int durationToStayOpen = 30;
    private int openFrames = 0;
    private Collider2D trapdoorCollider;

    private void Awake()
    {
        trapdoorCollider = GetComponent<Collider2D>();
        trapdoorCollider.enabled = !isOpen;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if (isOpen)
            CheckTrapdoor();
    }

    private void CheckTrapdoor()
    {
        if (isOpen && ++openFrames >= durationToStayOpen)
        {
            trapdoorCollider.enabled = true;
            isOpen = false;
        }
    }

}
