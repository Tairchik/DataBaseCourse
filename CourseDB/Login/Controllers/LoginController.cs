using System;
using System.Collections.Generic;
using AuthorizationLibrary;

namespace Login
{
    public class LoginController
    {
        private LoginForm view;
        private string _authenticatedUsername;
        private Dictionary<string, User> _users;
        public Dictionary<string, User> users { get { return _users; } }
        public string AuthenticatedUsername { get { return _authenticatedUsername; } }

        public LoginController(LoginForm loginForm)
        {
            view = loginForm;
        }

        public bool AuthorizationData()
        {
            // Создаем объект авторизации
            var auth = new Authorization();
            _users = auth.users;
            // Тестовая авторизация
            string username = view.GetName();
            string password = view.GetPassword();

            if (auth.Authenticate(username, password))
            {
                _authenticatedUsername = username;
                return true;
            }
            else
            {
                throw new Exception("Неверное имя пользователя или пароль.");
            }
        }
    }
}