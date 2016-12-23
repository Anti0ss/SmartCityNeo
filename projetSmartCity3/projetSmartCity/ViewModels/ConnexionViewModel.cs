using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using projetSmartCity.DAO;
using projetSmartCity.Error;
using projetSmartCity.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace projetSmartCity.ViewModels
{
    public class ConnexionViewModel : ViewModelBase, INotifyPropertyChanged

    {
        private ICommand _goToMainPageCommand;
        private ICommand _goToInscriptionCommand;

        private String _adresse_mail;
        public String Adresse_mail
        {
            get { return _adresse_mail; }
            set
            {
                _adresse_mail = value;
                RaisePropertyChanged("Adresse_mail");

            }
        }
        private String _password;
        public String Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged("Password");

            }
        }
        public string _token;
        public string Token
        {
            get { return _token; }
            set
            {
                _token = value;
                RaisePropertyChanged("Token");
            }
        }
        private INavigationService _navigationService;

        
        public ConnexionViewModel(INavigationService navigationService=null)
        {
            _navigationService = navigationService;
        }
        public ICommand GoToInscriptionCommand
        {
            get
            {
                if (_goToInscriptionCommand == null)
                    _goToInscriptionCommand = new RelayCommand(() => GoToInscription());
                return _goToInscriptionCommand;
            }
        }
        public void GoToInscription()
        {
            _navigationService.NavigateTo("InscriptionView");
        }
        public ICommand GoToMainPageCommand
        {
            get
            {
                if (_goToMainPageCommand == null)
                    _goToMainPageCommand = new RelayCommand(() => GoToMainPage());
                return _goToMainPageCommand;
            }
        }
        private void GoToMainPage()
        {
            if (Adresse_mail != null || Password != null)
            {


                GetToken(Adresse_mail, Password);



            }
        }
        public async Task GetToken(string Mail, string Mdp)
        {
            var service = new UtilisateurService();
            ApplicationError erreur = await service.GetToken(Mail, Mdp);
            if (erreur.ok)
            {
                var recup = service.GetUtilisateur();
                _navigationService.NavigateTo("MainPage", Token);
                 
            }
            else
            {
                var dialogue = new Windows.UI.Popups.MessageDialog("Message d'erreur de la requète: " + erreur.errorMessage);
                dialogue.ShowAsync();
            }
        }
    }
}
