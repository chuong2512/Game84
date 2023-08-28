using UnityEngine.UI;

public class PlayDrum : PlayMusic
{
    public Button[] drums;

    protected override void Start()
    {
        base.Start();
        int n = drums.Length;
        for (int i = 0; i < n; i++)
        {
            drums[i].onClick.AddListener(() => Play(0));
        }
    }
}
