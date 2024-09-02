using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Levels/LevelConfig")]
public class LevelConfig_SO : ScriptableObject
{
    public Sprite LevelImage;
    public string InstructionsText;
    public Sprite SuccessSprite;
    public Sprite FailureSprite;
    public List<string> Words;
    public string CorrectWord;
}
