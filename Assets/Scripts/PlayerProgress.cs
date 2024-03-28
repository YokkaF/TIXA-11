using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

    public class PlayerProgress : MonoBehaviour
{
    [SerializeField] private List<LvlProgress> levels;
    [SerializeField] private TextMeshProUGUI lvlUpTxt;
    [SerializeField] private RectTransform expRect;
    [SerializeField] private int _lvlValue = 1;
    [SerializeField] private float _expCurrentValue;
    [SerializeField] private float _expTargetValue;
    // Start is called before the first frame update
    void Start()
    {
        SetLvL(_lvlValue);
        DrawUI();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void AddExp(float value)
    {
        _expCurrentValue += value;
        if(_expCurrentValue >= _expTargetValue)
        {
            SetLvL(_lvlValue + 1);
             _expCurrentValue = 0;

        }
        DrawUI();


    }
    private void DrawUI()
    {
        expRect.anchorMax = new Vector2(_expCurrentValue / _expTargetValue, 1);
        lvlUpTxt.text = _lvlValue.ToString();
    }
    private void SetLvL(int value)
    {
        _lvlValue = value;
        _expTargetValue = levels[_lvlValue - 1].nextLvl;
        GetComponent<Bullet>().damage = levels[_lvlValue - 1].bulletDamage;
        GetComponent<GrenadeCaster>().damage = levels[_lvlValue - 1].GrenadeDamage;
    }
}
