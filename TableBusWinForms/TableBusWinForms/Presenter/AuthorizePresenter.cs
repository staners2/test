﻿using LibraryController;
using LibraryController.Models;
using System.Linq;
using System.Windows.Forms;

namespace TableBusWinForms.Presenter
{
    public class AuthorizePresenter
    {
        public AuthorizePresenter(AuthorizeForm View)
        {
            this.View = View;
        }

        public AuthorizeForm View { get; set; }

        public void EnterAccount()
        {
            string Login = View.LoginTextBox.Text;
            User pUser;
            if (!Controller.CheckUserExists(Login))
                pUser = Controller.RegistrationUser(Login);
            pUser = Controller.GetUser(Login);
            View.Hide();
            AdminView.ViewTableForm Form = new AdminView.ViewTableForm(pUser.Id, Login);
            switch (pUser.IsAdmin)
            {
                case true:
                {
                    Form.Text += " (Администратор)";
                    Form.ShowDialog();
                    break;
                }

                case false:
                {
                    var PanelAdmin = (Panel) Form.Controls.Find("panel1", false).First();
                    PanelAdmin.Visible = false;
                    Form.Text += " (Пользователь)";
                    Form.ShowDialog();
                    break;
                }
            }
        }
    }
}
