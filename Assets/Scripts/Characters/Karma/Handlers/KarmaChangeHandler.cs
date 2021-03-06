using UnityEngine;
using UnityEngine.SceneManagement;

public class KarmaChangeHandler : MonoBehaviour
{
    [SerializeField] 
    private Karma karma;

    private const string recentWinPlayerPref = "RecentWin";
    private const string demonWinPlayerPref = "DemonWin";
    private const string angelWinPlayerPref = "AngelWin";
    private const string winScene = "WinScreen";

    private void Awake()
    {
        karma.OnKarmaChange += OnKarmaChange;
    }

    private void OnDestroy()
    {
        karma.OnKarmaChange -= OnKarmaChange;
    }

    private void OnKarmaChange(object caller, Karma.KarmaChangeArgs args)
    {
        CheckWinConditions(args.karma);
    }

    private void CheckWinConditions(int currentKarma) 
    {
        if(currentKarma <= 0)
            WinGame(demonWinPlayerPref);
        else if(currentKarma >= karma.MaxKarma)
            WinGame(angelWinPlayerPref);
    }

    private void WinGame(string keyWin)
    {
        PlayerPrefs.SetInt(keyWin, 1);
        PlayerPrefs.SetString(recentWinPlayerPref, keyWin);
        SceneManager.LoadScene(winScene);
    }
}