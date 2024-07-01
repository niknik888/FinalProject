using Blog2.BLL.ViewModels.User;
using Microsoft.AspNetCore.Identity.Data;

namespace Blog2.BLL.ViewModels
{
    public class MainViewModel
    {
        public UserRegisterViewModel RegisterView { get; set; }

        public UserLoginViewModel LoginView { get; set; }

        public MainViewModel()
        {
            RegisterView = new UserRegisterViewModel();
            LoginView = new UserLoginViewModel();
        }
    }
}
