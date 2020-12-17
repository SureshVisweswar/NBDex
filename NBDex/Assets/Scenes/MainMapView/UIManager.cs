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

    [SerializeField] private GameObject MallardButtonText;
    [SerializeField] private GameObject EagleButtonText;
    [SerializeField] private GameObject WolfButtonText;

    [SerializeField] private GameObject MallardMenu;
    [SerializeField] private GameObject EagleMenu;
    [SerializeField] private GameObject WolfMenu;

    private Firebase.FirebaseApp app;
    private Firebase.Auth.FirebaseAuth auth;
    private DatabaseReference db;
    private Firebase.Auth.FirebaseUser currentUser;

    private bool userHasDuck = false;
    private bool userHasEagle = false;
    private bool userHasWolf = false;

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

        if (PlayerPrefs.GetString("value") != "nothing") {
            if (PlayerPrefs.GetString("value") != "success") {
                if (PlayerPrefs.GetString("sceneEntered") == "Duck") {
                    //FirebaseDatabase.DefaultInstance.GetReference("/users/" + currentUser.UserId + "/NBDex/").Child("Duck").SetValueAsync(true);
                }
                else if (PlayerPrefs.GetString("sceneEntered") == "Eagle1")
                {
                    //FirebaseDatabase.DefaultInstance.GetReference("/users/" + currentUser.UserId + "/NBDex/").Child("Eagle").SetValueAsync(true);
                }
                else if (PlayerPrefs.GetString("sceneEntered") == "Eagle2")
                {
                    //FirebaseDatabase.DefaultInstance.GetReference("/users/" + currentUser.UserId + "/NBDex/").Child("Eagle").SetValueAsync(true);
                }
                else if (PlayerPrefs.GetString("sceneEntered") == "Wolf")
                {
                    //FirebaseDatabase.DefaultInstance.GetReference("/users/" + currentUser.UserId + "/NBDex/").Child("Wolf").SetValueAsync(true);
                }

                PlayerPrefs.SetString("value", "nothing");
            } else {
                PlayerPrefs.SetString("value", "nothing");
            }
        }
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

        /*FirebaseDatabase.DefaultInstance.GetReference("/users/" + currentUser.UserId + "/NBDex/").Child("Duck").GetValueAsync().ContinueWithOnMainThread(task => {
            if (task.IsFaulted)
            {
                ShowToast("Error Retrieving NBDex");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                if ((bool)snapshot.GetValue(true) == true) {
                    MallardButtonText.gameObject.GetComponent<Text>().text = "Mallard";
                    userHasDuck = true;
                }
            }
        });

        FirebaseDatabase.DefaultInstance.GetReference("/users/" + currentUser.UserId + "/NBDex/").Child("Eagle").GetValueAsync().ContinueWithOnMainThread(task => {
            if (task.IsFaulted)
            {
                ShowToast("Error Retrieving NBDex");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                if ((bool)snapshot.GetValue(true) == true)
                {
                    MallardButtonText.gameObject.GetComponent<Text>().text = "Eagle";
                    userHasEagle = true;
                }
            }
        });

        FirebaseDatabase.DefaultInstance.GetReference("/users/" + currentUser.UserId + "/NBDex/").Child("Wolf").GetValueAsync().ContinueWithOnMainThread(task => {
            if (task.IsFaulted)
            {
                ShowToast("Error Retrieving NBDex");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                if ((bool)snapshot.GetValue(true) == true)
                {
                    MallardButtonText.gameObject.GetComponent<Text>().text = "Wolf";
                    userHasWolf = true;
                }
            }
        */
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

    public void openMallardNBDex() {
        if (userHasDuck)
        {
            NBDexMenu.gameObject.SetActive(false);
            MallardMenu.gameObject.SetActive(true);
        }
    }

    public void closeMallardNBDex()
    {
        NBDexMenu.gameObject.SetActive(true);
        MallardMenu.gameObject.SetActive(false);
    }
    public void openEagleNBDex()
    {
        if (userHasEagle)
        {
            NBDexMenu.gameObject.SetActive(false);
            EagleMenu.gameObject.SetActive(true);
        }
    }
    public void closeEagleNBDex()
    {
        NBDexMenu.gameObject.SetActive(true);
        EagleMenu.gameObject.SetActive(false);
    }
    public void openWolfNBDex()
    {
        if (userHasWolf)
        {
            NBDexMenu.gameObject.SetActive(false);
            WolfMenu.gameObject.SetActive(true);
        }
    }

    public void closeWolfNBDex()
    {
        NBDexMenu.gameObject.SetActive(true);
        WolfMenu.gameObject.SetActive(false);
    }

    private void ShowToast(string message) {
        SSTools.ShowMessage(message, SSTools.Position.bottom, SSTools.Time.twoSecond);
    }
}
