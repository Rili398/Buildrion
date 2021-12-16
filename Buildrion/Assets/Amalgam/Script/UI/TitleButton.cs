using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
      UnityEngine.Application.Quit();
#endif
    }

    public void ChangeGameScene()
    {
        Singleton<SoundManager>.Instance.PlaySeByName("gattai");
        Singleton<GameManager>.Instance.SetGameState(GameState.Game);
        SceneManager.LoadScene("City_02");
    }
}
