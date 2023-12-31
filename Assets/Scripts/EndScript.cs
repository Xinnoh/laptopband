using UnityEngine;

public class EndCollisionHandler : MonoBehaviour
{
    // This script deletes notes that are missed. This prevents them from scrolling upwards across the screen
    // If it collides with a note, it deletes it.

    public int gamemode;
    public Vector2 detectionSize = new Vector2(1f, 1f); // Size of the detection area
    public Vector2 offset; // Offset for the detection area
    public bool levelSelect;

    private void Update()
    {
        CheckForMiss(detectionSize);
    }

    private bool CheckForMiss(Vector2 size)
    {
        Vector2 boxCenter = (Vector2)transform.position + offset;
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(boxCenter, size, 0);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Note"))
            {
                MoveNote moveNoteScript = hitCollider.gameObject.GetComponent<MoveNote>();
                if (moveNoteScript != null && !moveNoteScript.played)
                {
                    moveNoteScript.PlayNote(false); 
                    if(!levelSelect)
                    {
                        ScoreManager.Instance.RegisterHit("Miss", gamemode);

                    }
                    return true;
                }
            }
        }
        return false;
    }

    // Optional: Draw Gizmos to visualize the detection area
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector2 boxCenter = (Vector2)transform.position + offset;
        Gizmos.DrawWireCube(boxCenter, detectionSize);
    }
}
