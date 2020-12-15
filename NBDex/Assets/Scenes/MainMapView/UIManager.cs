using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using Firebase.Extensions;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button profileButton;
    [SerializeField] private Button NBDexButton;
    [SerializeField] private GameObject ProfileMenu;
    [SerializeField] private GameObject NBDexMenu;
    [SerializeField] private GameObject ProfileBackground;
    [SerializeField] private GameObject CollectionBackground;
    [SerializeField] private GameObject LoginMenuBase;
    [SerializeField] private GameObject LoginMenu;
    [SerializeField] private GameObject CreateAccountMenu;
    [SerializeField] private InputField emailLogin;
    [SerializeField] private InputField passwordLogin;
    [SerializeField] private InputField usernameCreate;
    [SerializeField] private InputField emailCreate;
    [SerializeField] private InputField passwordCreate;
    [SerializeField] private GameObject LocationBasedGame;
    [SerializeField] private GameObject AnimalController;

    private Firebase.FirebaseApp app;
    private Firebase.Auth.FirebaseAuth auth;
    private DatabaseReference db;
    private Firebase.Auth.FirebaseUser currentUser;

    private void Awake() {
    }

    void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                app = Firebase.FirebaseApp.DefaultInstance;
                auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
                db = FirebaseDatabase.DefaultInstance.RootReference;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    public void signIn() {
        SignInWithEmailAsync();
    }

    public Task SignInWithEmailAsync() {
        return auth.SignInWithEmailAndPasswordAsync(emailLogin.text, passwordLogin.text).ContinueWithOnMainThread((Task<Firebase.Auth.FirebaseUser> task) => {
            if (task.IsFaulted)
            {
                ShowToast("Error Signing In");
            }
            else {
                currentUser = task.Result;
                closeLoginMenu();
            }
        });
    }

    public void createAccount() {
        CreateUserWithEmailAsync();
    }

    public Task CreateUserWithEmailAsync() {
        return auth.CreateUserWithEmailAndPasswordAsync(emailCreate.text, passwordCreate.text).ContinueWithOnMainThread((task) =>
        {
            if (task.IsCanceled)
            {
                ShowToast("User Creation Stopped");
                return;
            }
            if (task.IsFaulted)
            {
                ShowToast("Error Creating User");
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;

            User user = new User(usernameCreate.text, emailCreate.text);
            string json = JsonUtility.ToJson(user);
            db.Child("users").Child(newUser.UserId).SetRawJsonValueAsync(json);

            ShowToast("User Created");
            closeCreateAccountMenu();
        });
    }

    public void openProfileMenu() {
        profileButton.gameObject.SetActive(false);
        NBDexButton.gameObject.SetActive(false);
        ProfileMenu.gameObject.SetActive(true);
    }

    public void openNBDex() {
        profileButton.gameObject.SetActive(false);
        NBDexButton.gameObject.SetActive(false);
        NBDexMenu.gameObject.SetActive(true);
    }

    public void openCreateAccountMenu() {
        LoginMenu.gameObject.SetActive(false);
        CreateAccountMenu.gameObject.SetActive(true);
    }

    public void openCollectionMenu()
    {
        ProfileBackground.gameObject.SetActive(false);
        CollectionBackground.gameObject.SetActive(true);
    }

    public void closeProfileMenu() {
        profileButton.gameObject.SetActive(true);
        NBDexButton.gameObject.SetActive(true);
        ProfileMenu.gameObject.SetActive(false);
    }

    public void closeNBDex()
    {
        profileButton.gameObject.SetActive(true);
        NBDexButton.gameObject.SetActive(true);
        NBDexMenu.gameObject.SetActive(false);
    }

    public void closeCollectionMenu()
    {
        ProfileBackground.gameObject.SetActive(true);
        CollectionBackground.gameObject.SetActive(false);
    }

    public void closeCreateAccountMenu()
    {
        LoginMenu.gameObject.SetActive(true);
        CreateAccountMenu.gameObject.SetActive(false);
    }

    public void closeLoginMenu() 
    {
        LoginMenuBase.gameObject.SetActive(false);
        profileButton.gameObject.SetActive(true);
        NBDexButton.gameObject.SetActive(true);
        LocationBasedGame.gameObject.SetActive(true);
        AnimalController.gameObject.SetActive(true);
    }

    private void ShowToast(string message) {
        SSTools.ShowMessage(message, SSTools.Position.bottom, SSTools.Time.twoSecond);
    }
}
