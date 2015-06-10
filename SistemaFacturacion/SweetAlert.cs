using System;

/// <summary>
/// A BEAUTIFUL REPLACEMENT FOR JAVASCRIPT'S "ALERT".
/// http://tristanedwards.me/sweetalert
/// </summary>

[Serializable]
public class SweetAlert
{
    /// <summary>
    /// The title of the modal. It can either be added to the object under the key "title" or passed as the first parameter of the function.
    /// </summary>
    public string title { get; set; }
    /// <summary>
    /// A description for the modal. It can either be added to the object under the key "text" or passed as the second parameter of the function.
    /// </summary>
    public string text { get; set; }
    /// <summary>
    /// The type of the modal. SweetAlert comes with 4 built-in types which will show a corresponding icon animation: "warning", "error", "success" and "info". It can either be put in the array under the key "type" or passed as the third parameter of the function.
    /// </summary>
    public string type { get; set; }
    /// <summary>
    /// If set to true, the user can dismiss the modal by clicking outside it.
    /// </summary>
    public bool allowOutsideClick { get; set; }
    /// <summary>
    /// If set to true, a "Cancel"-button will be shown, which the user can click on to dismiss the modal.
    /// </summary>
    public bool showCancelButton { get; set; }
    /// <summary>
    /// Use this to change the text on the "Confirm"-button. If showCancelButton is set as true, the confirm button will automatically show "Confirm" instead of "OK".
    /// </summary>
    public string confirmButtonText { get; set; }
    /// <summary>
    /// Use this to change the background color of the "Confirm"-button (must be a HEX value).
    /// </summary>
    public string confirmButtonColor { get; set; }
    /// <summary>
    /// Use this to change the text on the "Cancel"-button.
    /// </summary>
    public string cancelButtonText { get; set; }
    /// <summary>
    /// Set to false if you want the modal to stay open even if the user presses the "Confirm"-button. This is especially useful if the function attached to the "Confirm"-button is another SweetAlert.
    /// </summary>
    public bool closeOnConfirm { get; set; }
    /// <summary>
    /// Add a customized icon for the modal. Should contain a string with the path to the image.
    /// </summary>
    public string imageUrl { get; set; }
    /// <summary>
    /// If imageUrl is set, you can specify imageSize to describes how big you want the icon to be in px. Pass in a string with two values separated by an "x". The first value is the width, the second is the height.
    /// </summary>
    public string imageSize { get; set; }
    /// <summary>
    /// Auto close timer of the modal. Set in ms (milliseconds).
    /// </summary>
    public string timer { get; set; }
    /// <summary>
    /// Url to Redirect after comfirm.
    /// </summary>
    public string OnConfirmRedirectTo { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="title">The title of the modal. It can either be added to the object under the key "title" or passed as the first parameter of the function.</param>
    /// <param name="text">A description for the modal. It can either be added to the object under the key "text" or passed as the second parameter of the function.</param>
    /// <param name="type">The type of the modal. SweetAlert comes with 4 built-in types which will show a corresponding icon animation: "warning", "error", "success" and "info". It can either be put in the array under the key "type" or passed as the third parameter of the function.</param>
    /// <param name="allowOutsideClick">If set to true, the user can dismiss the modal by clicking outside it.</param>
    /// <param name="showCancelButton">If set to true, a "Cancel"-button will be shown, which the user can click on to dismiss the modal.</param>
    /// <param name="confirmButtonText">Use this to change the text on the "Confirm"-button. If showCancelButton is set as true, the confirm button will automatically show "Confirm" instead of "OK".</param>
    /// <param name="confirmButtonColor">Use this to change the background color of the "Confirm"-button (must be a HEX value).</param>
    /// <param name="cancelButtonText">Use this to change the text on the "Cancel"-button.</param>
    /// <param name="closeOnConfirm">Set to false if you want the modal to stay open even if the user presses the "Confirm"-button. This is especially useful if the function attached to the "Confirm"-button is another SweetAlert.</param>
    /// <param name="imageUrl">Add a customized icon for the modal. Should contain a string with the path to the image.</param>
    /// <param name="imageSize">If imageUrl is set, you can specify imageSize to describes how big you want the icon to be in px. Pass in a string with two values separated by an "x". The first value is the width, the second is the height.</param>
    /// <param name="timer">Auto close timer of the modal. Set in ms (milliseconds).</param>
    /// <param name="OnConfirmRedirectTo">Url to Redirect after comfirm.</param>
    public SweetAlert(string title = "", string text = null, string type = null, bool allowOutsideClick = false,
                        bool showCancelButton = false, string confirmButtonText = "OK", string confirmButtonColor = "#AEDEF4",
                        string cancelButtonText = "Cancelar", bool closeOnConfirm = true, string imageUrl = null,
                        string imageSize = "80x80", string timer = null, string OnConfirmRedirectTo = null)
    {
        this.title = title;
        this.text = text;
        this.type = type;
        this.allowOutsideClick = allowOutsideClick;
        this.showCancelButton = showCancelButton;
        this.confirmButtonText = confirmButtonText;
        this.confirmButtonColor = confirmButtonColor;
        this.cancelButtonText = cancelButtonText;
        this.closeOnConfirm = closeOnConfirm;
        this.imageUrl = imageUrl;
        this.imageSize = imageSize;
        this.timer = timer;
        this.OnConfirmRedirectTo = OnConfirmRedirectTo;

    }




}
