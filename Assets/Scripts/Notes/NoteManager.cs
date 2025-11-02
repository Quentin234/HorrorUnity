using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;
    public int NotesRead = 0;
    public int TotalNotes = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        TotalNotes = FindObjectsOfType<Note>().Length;
    }

    public void NoteRead()
    {
        NotesRead++;
    }
}
