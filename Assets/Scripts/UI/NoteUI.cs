using UnityEngine;
using TMPro;

public class NoteUI : MonoBehaviour
{
    [Header("Note UI")]
    public GameObject notePanel;
    public TMP_Text noteText;

    [Header("Prompt")]
    public TMP_Text promptText;

    [Header("Counter")]
    public TMP_Text counterText;

    private bool isOpen = false;
    private Note currentNote;

    private void Start()
    {
        // Au démarrage, cacher le panel
        if (notePanel != null)
            notePanel.SetActive(false);

        if (promptText != null)
            promptText.gameObject.SetActive(false);

        UpdateCounter();
    }

    public void ShowPrompt(bool state)
    {
        if (isOpen) return; // si une note est ouverte, on n'affiche pas le prompt
        if (promptText != null)
            promptText.gameObject.SetActive(state);
    }

    public void OpenNote(Note note)
    {
        isOpen = true;
        currentNote = note;

        if (notePanel != null)
            notePanel.SetActive(true);

        if (noteText != null)
            noteText.text = note.noteText;

        if (promptText != null)
            promptText.gameObject.SetActive(false);

        // Marquer la note comme lue
        if (!note.isRead)
        {
            note.isRead = true;
            NoteManager.Instance.NoteRead();
            UpdateCounter();
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseNote()
    {
        if (!isOpen) return;

        isOpen = false;

        if (notePanel != null)
            notePanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UpdateCounter()
    {
        if (counterText != null)
            counterText.text = $"{NoteManager.Instance.NotesRead}/{NoteManager.Instance.TotalNotes}";
    }
}
