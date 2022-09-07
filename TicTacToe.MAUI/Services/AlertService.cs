namespace TicTacToe.MAUI.Services
{
    public class AlertService : IAlertService
    {
        public void ShowConfirmation(string title, string message, Action<bool> callback, 
            string accept = "Yes", string cancel = "No")
        {
            Application.Current.MainPage.Dispatcher.Dispatch(async () =>
            {
                bool answer = await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
                callback(answer);
            });
        }
    }
}
