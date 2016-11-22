using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameLibraryController : Singleton<GameLibraryController> {

    protected GameLibraryController() { }

    [SerializeField]
    private GameObject gamePanelPrefab;
    [SerializeField]
    private GameObject gameInSessionPrompt;
    [SerializeField]
    private Text gameNameInSession;

    private System.Diagnostics.Process currentProcess;

    // Use this for initialization
    void Start () {
        GameLibrary gl = GameLoaderService.Instance.gameLibrary;
        int gameNumber = gl.games.Length;
        while(gameNumber > 0)
        {
            GameObject go = Instantiate(gamePanelPrefab);
            go.transform.SetParent(transform, false);
            go.GetComponent<GamePanel>().UpdateGameInfo(gl.games[gameNumber - 1]);
            gameNumber--;
        }
    }

    public void DisplayGameInSession(string gameTitle, System.Diagnostics.Process process)
    {
        gameInSessionPrompt.SetActive(true);
        gameNameInSession.text = gameTitle;
        currentProcess = process;
    }

    public IEnumerator HideGameInSession()
    {
        gameInSessionPrompt.SetActive(false);
        if (!currentProcess.HasExited)
        {
            currentProcess.Close();
        }
        yield return null;
    }
}
