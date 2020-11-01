using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class LooseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Game Over");
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
