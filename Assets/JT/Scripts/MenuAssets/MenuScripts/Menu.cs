using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Menu : MonoBehaviour
{
    [SerializeField] List<GameObject> _listUI;
    [SerializeField] GameObject _selectedUI;
    [SerializeField] Color _selectedColor;
    [SerializeField] Color _selectedColorPressed;
    [SerializeField] Vector3 _selectedScale = new Vector3(1.5f, 1.5f, 1.5f);
    [SerializeField] float _selectedSpeed = 1f;

    [SerializeField] bool resetCurrentIndex;
    [SerializeField] bool loopCurrentIndex;

    int _currentNumber;
    Color _defaultColor;
    Vector3 _defaultScale;
    MenuInvokeSelected _menuInvokeSelect;

    void Awake()
    {
        _defaultColor = _listUI[0].transform.GetChild(0).GetComponent<Text>().color;
        _defaultScale = _listUI[0].transform.GetChild(0).localScale;
    }

    // Update is called once per frame
    void Update()
    {
        _currentNumber = Mathf.Clamp(_currentNumber, 0, _listUI.Count - 1);

        foreach (GameObject ui in _listUI)
        {
            if (ui != null)
            {
                _selectedUI = _listUI[_currentNumber];

                if (ui != _selectedUI)
                { 
                    ui.transform.GetChild(0).GetComponent<Text>().color = _defaultColor;
                    ui.transform.GetChild(0).localScale = _defaultScale;

                    _menuInvokeSelect = null;
                }
            }
        }

        if (Input.GetKeyDown("down"))
        {
            if (loopCurrentIndex)
            {
                if (_currentNumber < _listUI.Count - 1)
                {
                    _currentNumber++;
                }
                else if (_currentNumber >= _listUI.Count - 1)
                {
                    _currentNumber = 0;
                }
            }
            else
            {
                _currentNumber++;
            }
        }
        else if (Input.GetKeyDown("up"))
        {
            if (loopCurrentIndex)
            {
                if (_currentNumber > 0)
                {
                    _currentNumber--;
                }
                else if (_currentNumber <= 0)
                {
                    _currentNumber = _listUI.Count - 1;
                }
            }
            else
            {
                _currentNumber--;
            }
        }

        if (_selectedUI)
        {
            _selectedUI.transform.GetChild(0).transform.localScale = Vector3.Lerp(_selectedUI.transform.GetChild(0).transform.localScale, _selectedScale, Time.fixedDeltaTime * _selectedSpeed);

            if (Input.GetKey("space"))
            {
                _selectedUI.transform.GetChild(0).GetComponent<Text>().color = _selectedColorPressed;
            }
            else
            {
                _selectedUI.transform.GetChild(0).GetComponent<Text>().color = _selectedColor;
            }

            if (Input.GetKeyUp("space"))
            {

                _menuInvokeSelect = _selectedUI.transform.gameObject.GetComponent<MenuInvokeSelected>();
                _menuInvokeSelect.AcessInvoke();
            }

        }

        ResetCurrentNumber();
        DisbleUI();
    }

    void ResetCurrentNumber()
    {
        if (resetCurrentIndex)
        {
            if (!enabled || this.gameObject.activeInHierarchy == false)
            {
                _currentNumber = 0;
            }
        }
    }

    void DisbleUI()
    {
        if (!enabled || this.gameObject.activeInHierarchy == false)
        {
            foreach (GameObject ui in _listUI)
            {
                ui.transform.GetChild(0).GetComponent<Text>().color = _defaultColor;
                ui.transform.GetChild(0).localScale = _defaultScale;

                _menuInvokeSelect = null;
            }

            _selectedUI = null;
        }
    }
}
