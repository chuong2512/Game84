using Jackal;
using UnityEngine.SceneManagement;

namespace MyNamespace
{
    using UnityEngine;
    using UnityEngine.UI;

    public class MusicItem : MonoBehaviour
    {
        [SerializeField] private SongID songID;
        public Button button;
        public GameObject lockObj;
        private bool _unlock;
        private MusicController _controller;
        private int _price;
        private int id;

        public void Init(int price, int id, MusicController controller)
        {
            _price = price;
            _controller = controller;
            button.onClick.AddListener(PlaySong);
            _unlock = false;
            this.id = id;
        }

        public void Unlock()
        {
            _unlock = true;
            lockObj.SetActive(false);
        }

        public void Buy()
        {
            _controller.ShowPopup(_price, id);
        }
        
        private void PlaySong()
        {
            if (!_unlock)
            {
                Buy();
                return;
            }

            GameDataManager.Instance.currentID = songID;
            SceneManager.LoadScene("Music");
        }

        public SongID SongID => songID;
    }
}