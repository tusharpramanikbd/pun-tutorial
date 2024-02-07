using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;

namespace Com.TusharPramanikBD.MyGame
{
    /// <summary>
    /// Player name input field. Let the user input his name, will appear above the player in the game.
    /// </summary>
    [RequireComponent(typeof(InputField))]
    public class PlayerNameInputField : MonoBehaviour
    {
        #region Private Constants

        // Store the PlayerPref Key to avoid typos
        const string PLAYER_NAME_PREF_KEY = "PlayerName";

        #endregion

        #region MonoBehaviour Callbacks

        private void Start() 
        {
            string defaultName = string.Empty;

            InputField inputField = GetComponent<InputField>();

            if(inputField != null && PlayerPrefs.HasKey(PLAYER_NAME_PREF_KEY))
            {
                defaultName = PlayerPrefs.GetString(PLAYER_NAME_PREF_KEY);
                inputField.text = defaultName;
            }

            PhotonNetwork.NickName = defaultName;
        }

        #endregion

        #region Public Methods

        public void SetPlayerName(string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                Debug.LogError("Player Name is null or empty");
                return;
            }

            PhotonNetwork.NickName = value;

            PlayerPrefs.SetString(PLAYER_NAME_PREF_KEY, value);
        }

        #endregion
    }
}
