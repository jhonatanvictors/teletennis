using System.Collections;
using System.Collections.Generic;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RegistrationButton : MonoBehaviour
{
    [SerializeField] private RegistrationUIFlow _registrationFlow;
    [SerializeField] private Button _registrationButton;
    private Coroutine _registrationCoroutine;
    public UserRegisteredEvent onUserRegistered = new UserRegisteredEvent();
    public UserRegisteredFailedEvent onUserRegistrationFailed = new UserRegisteredFailedEvent();
    // Start is called before the first frame update

    private void Reset()
    {
        _registrationFlow = FindObjectOfType<RegistrationUIFlow>();
        _registrationButton = GetComponent<Button>();
    }
    void Start()
    {
        _registrationFlow.OnStateChanged.AddListener(HandleRegistrationStateChanged);
        _registrationButton.onClick.AddListener(HandleRegistrationButtonClicked);

        UpdateInteractable();
    }

    private void OnDestroy()
    {
        _registrationFlow.OnStateChanged.RemoveListener(HandleRegistrationStateChanged);
        _registrationButton.onClick.RemoveListener(HandleRegistrationButtonClicked);
    }

    // Update is called once per frame
    private void UpdateInteractable()
    {
        _registrationButton.interactable =
        _registrationFlow.CurrentState = RegistrationUIFlow.Ok
        && _registrationCoroutine = null;
    }

    private void HandleRegistrationStateChanged(RegistrationUIFlow.State registrationState)
    {
        UpdateInteractable();
    }

    private void HandleRegistrationButtonClicked()
    {
        _registrationCoroutine = StartCoroutine(RegisterUser(_registrationFlow.Email, _registrationFlow.Password));
        UpdateInteractable();
    }

    private IEnumerator RegisterUser(string email, string password)
    {
        var auth = FirebaseAuth.DefaultInstance;
        var registerTask = auth.CreateUserWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(()=> registerTask.IsCompleted);

        if(registerTask.Exception != null){
            Debug.LogWarning($"Failed to register task with {registerTask.Exception}");
            onUserRegistrationFailed.Invoke(registerTask.Exception);
        }
        else{
            Debug.log($"Successfully registered user {registerTask.Result.Email}");
            onUserRegistered.Invoke(registerTask.Result);
        }

        _registrationCoroutine = null;
        UpdateInteractable();
    }
}
