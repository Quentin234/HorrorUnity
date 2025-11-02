using UnityEngine;

public class Note : MonoBehaviour
{
    [TextArea(3, 6)] public string noteText; // le texte de la note
    public bool isRead = false;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, Vector3.one * 0.2f);
    }
}
