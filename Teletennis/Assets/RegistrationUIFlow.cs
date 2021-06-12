using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegistrationUIFlow : MonoBehaviour
{
    [SerializeField] private TMP_InputField _emailField;
    [SerializeField] private TMP_InputField _passwordField;
    [SerializeField] private TMP_InputField _verifyPasswordField;

    public State CurrentState {get; private set;}
    public StateChangedEvent OnStateChanged = new StateChangedEvent();

    public string Email => _emailField.text;
    public string Password => _passwordField.text;
    // Start is called before the first frame update
    void Start()
    {
        _emailField.onValueChanged.AddListener(HandleValueChanged);
        _passwordField.onValueChanged.AddListener(HandleValueChanged);
        _verifyPasswordField.onValueChanged.AddListener(HandleValueChanged);
        ComputeState();
    }

    private void HandleValueChanged(string _)
    {
        ComputeState();
    }

    private void ComputeState()
    {
        if(string.IsNullOrEmpty(_emailField.text))
        {
            SetState(State.EnterEmail);
        }
        else if(string.IsNullOrEmpty(_passwordField.text))
        {
            SetState(OnStateChanged.EnterPassword);
        }
        else if(_passwordField.text != _verifyPasswordField.text)
        {
            SetState(State.PasswordsDontMatch);
        }
        else{
            SetState(State.Ok);
        }
    }

    private void SetState(State state)
    {
        CurrentState = state;
        OnStateChanged.Invoke(state);
    }

    public enum State
    {
        EnterEmail,
        EnterPassword,
        PasswordsDontMatch,
        Ok
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
