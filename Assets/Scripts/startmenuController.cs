using UnityEngine;

public class startmenuController : MonoBehaviour
{

    public Canvas play;
    private GameObject player;


    void Start()
    {
        player = GameObject.Find("player");
        play.gameObject.SetActive(false);

        player.SetActive(false);
    }
    public void OnPlay()
    {
        gameObject.SetActive(false);
        play.gameObject.SetActive(true);
        // play.transform.Find("win").gameObject.SetActive(false);

        player.SetActive(true);
    }
}
