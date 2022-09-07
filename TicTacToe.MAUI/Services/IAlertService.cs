namespace TicTacToe.MAUI.Services
{
    public interface IAlertService
    {
        void ShowConfirmation(string title, string message, Action<bool> callback,
                          string accept = "Yes", string cancel = "No");
    }
}
