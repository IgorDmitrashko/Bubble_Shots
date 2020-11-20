using UnityEngine;
using UnityEngine.UI;

public class ConvasController : MonoBehaviour
{
    public GameObject winText;
    public GameObject lostText;

    public void WinGame() {
        winText.SetActive(true);
        lostText.SetActive(false);
    }

    public void GameOver() {
        lostText.SetActive(true);
        winText.SetActive(false);
    }
}
