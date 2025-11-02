using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 3f;
    public LayerMask noteLayer;
    public Camera playerCamera;
    public NoteUI noteUI;

    private Note currentNote;

    void Update()
    {
        // Si on regarde une note
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, interactRange, noteLayer))
        {
            Note note = hit.collider.GetComponent<Note>();

            if (note != null)
            {
                currentNote = note;
                noteUI.ShowPrompt(true); // affiche "Appuyez sur E"

                if (Input.GetKeyDown(KeyCode.E))
                {
                    noteUI.OpenNote(note);
                }
            }
        }
        else
        {
            noteUI.ShowPrompt(false);
            currentNote = null;
        }

        // Fermer la note avec ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            noteUI.CloseNote();
        }
    }
}
