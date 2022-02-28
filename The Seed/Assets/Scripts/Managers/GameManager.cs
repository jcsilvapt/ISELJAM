using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    #region SINGLETON INSTANTIATION
    public static GameManager ins;
    #endregion

    #region EVENT SYSTEM
    // Pause System
    public Action EventGameIsPaused;
    public Action EventGameNotPaused;
    #endregion

    #region VARIABLES
 
    [SerializeField, Tooltip("DEBUG: is Game Paused?")] bool isPaused = false;

    #endregion

    private void Awake() {
        if(ins == null) {
            ins = this;
            DontDestroyOnLoad(this);
        } else {
            Destroy(gameObject);
        }
    }

    #region LOGIC

    private void _SetPause(bool value) {
        isPaused = value;

        if(isPaused) {
            EventGameIsPaused?.Invoke();
            Time.timeScale = 0;
        } else {
            EventGameNotPaused?.Invoke();
            Time.timeScale = 1;
        }

    }

    #endregion

    #region SINGELTON CALLOUTS

    /// <summary>
    /// Method that sets the State of the Pause
    /// </summary>
    /// <param name="value">True - Game will pause | False - Game will Unpause</param>
    public static void SetPause(bool value) {
        if(ins != null) {
            ins._SetPause(value);
        }
    }

    #endregion

}
