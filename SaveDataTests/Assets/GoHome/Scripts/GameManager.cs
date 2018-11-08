using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Xml.Serialization;
using System.IO;

namespace GoHome
{
    [Serializable]
    public class GameData
    {
        public int score;

    }
    public class GameManager : MonoBehaviour
    {
        #region Singleton
        public static GameManager Instance = null;

        private void Awake()
        {
            Instance = this;

            fullPath = Application.dataPath + "/GoHome/Data/" + fileName + ".xml";
            if (File.Exists(fullPath))
            {
                scoreText.text = "Score: " + data.score;
                Load();
            }

        }
        private void OnDestroy()
        {
            Instance = null;
            Save();
        }
        #endregion
        public int currentScore = 0;
        public int currentLvl = 0;
        public bool isGameRunning = true;
        public Transform levelContainer;
        [Header("UI")]
        public Text scoreText;
        [Header("GameSave")]
        public string fileName = "GameData";
        private string fullPath;
        private Level[] levels;
        private GameData data = new GameData();

        private void Start()
        {
            //populate levels array with levels
            levels = levelContainer.GetComponentsInChildren<Level>(true);
            SetLevel(currentLvl);

        }
        //disable all levels except the levelIndex
        private void SetLevel(int levelIndex)
        {
            //loop through all levels
            for (int i = 0; i < levels.Length; i++)
            {
                //the next level in array
                GameObject level = levels[i].gameObject;
                //level is not active
                level.SetActive(false);
                if (i == levelIndex)
                {
                    //sets the level as active
                    level.SetActive(true);
                }
            }
        }
        public void GameOver()
        {
            isGameRunning = false;
        }
        public void AddScore(int scoreToAdd)
        {
            currentScore += scoreToAdd;
            scoreText.text = "Score: " + currentScore;
        }
        public void AddScore(int scoreToAdd, int modifier)
        {
            AddScore(scoreToAdd * modifier);
        }
        public void Nextlevel()
        {
            //Increase currentLevel
            currentLvl++;
            //If current level exceeds level length
            if (currentLvl >= levels.Length)
            {
                //gameover
                GameOver();
            }
            else
            {
                //update current level
                SetLevel(currentLvl);
            }
        }
        private void Save()
        {
            data.score = currentScore;

            //creates a serializer of type gamedata
            var serializer = new XmlSerializer(typeof(GameData));
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                serializer.Serialize(stream, data);
            }
        }
        private void Load()
        {
            var serializer = new XmlSerializer(typeof(GameData));
            using (var stream = new FileStream(fullPath, FileMode.Open))
            {
                data = serializer.Deserialize(stream) as GameData;

                currentScore = data.score;


            }
        }

    }
}
