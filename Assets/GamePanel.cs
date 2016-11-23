using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GamePanel : MonoBehaviour {

    [SerializeField]
    Text gameName;
    [SerializeField]
    Text gameDesc;
    [SerializeField]
    Image gameThumbnail;

    private GameMetaData metadata;

    public void UpdateGameInfo(GameMetaData data)
    {
        gameName.text = data.name;
        gameDesc.text = data.desc;
        metadata = data;
        StartCoroutine(LoadSprite(Application.streamingAssetsPath + "/" + data.name + "/" + data.thumbPath));
    }
	
    public void RunGame()
    {
        Debug.Log(Application.streamingAssetsPath + "/" + metadata.gamePath);
        using (System.Diagnostics.Process execute = new System.Diagnostics.Process())
        {
            execute.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
            execute.EnableRaisingEvents = true;
            execute.Exited += OnGameExit;
            execute.StartInfo.FileName = Application.streamingAssetsPath + "/" + metadata.name + "/" + metadata.gamePath;
            //Display a UI screen that says "Running [GAME_NAME]... Exit the game to return the game selection screen."
            GameLibraryController.Instance.DisplayGameInSession(gameName.text, execute);
            execute.Start();
            //Process now started, detect exit here 
        }
        
        
    }

    private void OnGameExit(object sender, EventArgs e)
    {
        Debug.Log("Game exited");
        StartCoroutine(GameLibraryController.Instance.HideGameInSession());
    }

    public IEnumerator LoadSprite(string absImagePath)
    {
        string finalPath;
        WWW localFile;
        Texture texture;
        Sprite sprite;

        finalPath = "file://" + absImagePath;
        localFile = new WWW(finalPath);

        yield return localFile;
        texture = localFile.texture;
        sprite = Sprite.Create(texture as Texture2D, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        gameThumbnail.sprite = sprite;
    }

}
