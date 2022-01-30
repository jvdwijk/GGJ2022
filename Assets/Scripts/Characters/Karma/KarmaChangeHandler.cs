using UnityEngine;

public class KarmaChangeHandler : MonoBehaviour
{
    [SerializeField] 
    private Karma karma;

    [SerializeField]
    private SceneSwitcher sceneSwitcher;

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
        var currentKarmaState = args.newKarmaState;
        Debug.Log("Karma: " + currentKarmaState);
     
        //TODO: Add logic when karma is chagned
        CheckWinConditions(args.karma);
        
    }

    private void CheckWinConditions(int currentKarma) {
        if(currentKarma <= 0)
            WinGame(demonWinPlayerPref);
        else if(currentKarma >= karma.MaxKarma)
            WinGame(angelWinPlayerPref);
    }

    private void WinGame(string keyWin) {
        PlayerPrefs.SetInt(keyWin, 1);
        PlayerPrefs.SetString(recentWinPlayerPref, keyWin);
        sceneSwitcher.SwitchScene(winScene);
    }
}