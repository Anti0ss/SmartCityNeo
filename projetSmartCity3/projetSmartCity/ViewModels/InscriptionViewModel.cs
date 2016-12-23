using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using projetSmartCity.DAO;
using projetSmartCity.Models;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace projetSmartCity.ViewModels
{
    public class InscriptionViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _goToMainPageCommand;
        private ICommand _goToConnexionCommand;
        private INavigationService _navigationService;

        private string _adresse_mail;
        public string Adresse_mail
        {
            get
            {
                return _adresse_mail;
            }
            set
            {
                _adresse_mail = value;
               RaisePropertyChanged("Email");
            }
        }
        private string _nom;
        public string Nom{
            get
            {
                return _nom;
            }
            set
            {
                _nom = value;
                RaisePropertyChanged("Nom");
            }
        }
        private string _prenom;
        public string Prenom
        {
            get
            {
                return _prenom;
            }
            set
            {
                _prenom = value;
                RaisePropertyChanged("Prenom");
            }
        }
        private DateTimeOffset _date_de_Naissance;
        public DateTimeOffset Date_de_Naissance
        {
            get
            {
                return _date_de_Naissance;
            }
            set
            {
                _date_de_Naissance = value;
                RaisePropertyChanged("Date_de_Naissance");
            }
        }
        private string _adr_Numero_de_rue;
        public string Adr_Numero_de_rue
        {
            get
            {
                return _adr_Numero_de_rue;
            }
            set
            {
                _adr_Numero_de_rue = value;
                RaisePropertyChanged("Adr_Numero_de_rue");
            }
        }
        private string _adr_Nom_de_Rue;
        public string Adr_Nom_de_Rue
        {
            get
            {
                return _adr_Nom_de_Rue;
            }
            set
            {
                _adr_Nom_de_Rue = value;
                RaisePropertyChanged("Adr_Nom_de_Rue");
            }
        }
        private int _adr_Code_Postal;
        public int Adr_Code_Postal
        {
            get
            {
                return _adr_Code_Postal;
            }
            set
            {
                _adr_Code_Postal = value;
                RaisePropertyChanged("Adr_Code_Postal");
            }
        }
        private string _adr_Localite;
        public string Adr_Localite
        {
            get
            {
                return _adr_Localite;
            }
            set
            {
                _adr_Localite = value;
                RaisePropertyChanged("Adr_Localite");
            }
        }
        private string _numero_de_Telephone;
        public string Numero_de_Telephone
        {
            get
            {
                return _numero_de_Telephone;
            }
            set
            {
                _numero_de_Telephone = value;
                RaisePropertyChanged("Numero_de_Telephone");
            }
                
        }
        private string _mot_de_passe;
        public string Password
        {
            get
            {
                return _mot_de_passe;
            }
            set
            {
                _mot_de_passe = value;
                RaisePropertyChanged("Password");
            }    
        }
        private string _mot_de_passe2;
        public string ConfirmPassword
        {
            get
            {
                return _mot_de_passe2;
            }
            set
            {
                _mot_de_passe2 = value;
                RaisePropertyChanged("ConfirmPassword");
            }
        }
        private int _nbPoints;
        private int NbPoints
        {
            get
            {
                return _nbPoints;
            }
            set
            {
                _nbPoints = value;
                RaisePropertyChanged("NbPoints");
            }
        }
        /*

        private Utilisateur _utilisateur;
        public Utilisateur Utilisateur
        {
            get
            {
                return _utilisateur;
            }
            set
            {
                if (_utilisateur == value)
                {
                    return;
                }
                _utilisateur = value;
                RaisePropertyChanged("Utilisateur");

            }
        }
        */
        
        public void OnNavigatedTo(NavigationEventArgs e)
        {

        }
        //[PreferredConstructor]
        public InscriptionViewModel(INavigationService navigationService = null)
        {
            Date_de_Naissance = DateTime.Now;
            _navigationService = navigationService;
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
        public ICommand GoToConnexionCommand
        {
            get
            {
                if (_goToConnexionCommand == null)
                    _goToConnexionCommand = new RelayCommand(() => GoToConnexionView());
                return _goToConnexionCommand;
            }
        }
        private void GoToConnexionView()
        {
            _navigationService.NavigateTo("ConnexionView");
        }
        
        private void GoToMainPage()
        {
            RegisterBindingModel util= new RegisterBindingModel(Adresse_mail, Nom,Prenom,Date_de_Naissance.DateTime, Adr_Numero_de_rue, Adr_Nom_de_Rue, Adr_Code_Postal, Adr_Localite, Numero_de_Telephone, Password,ConfirmPassword, NbPoints);
            utilisateurMessage(util);
        }
        private async Task utilisateurMessage(RegisterBindingModel u)
        {
            var service = new UtilisateurService();
            var x = await service.PostUtilisateur(u);

            if (x.ok)
            {
                var erreur = await service.GetToken(u.Email, u.Password);
                if (erreur.ok)
                {
                    _navigationService.NavigateTo("MainPage");
                }
                else
                {
                    var dialogue = new Windows.UI.Popups.MessageDialog("Message d'erreur de la requète: " + erreur.errorMessage);
                    dialogue.ShowAsync();
                    _navigationService.NavigateTo("ConnexionView");
                }
            }
            else
            {
                var dialogue = new Windows.UI.Popups.MessageDialog("Message d'erreur de la requète: " + x.errorMessage);
                dialogue.ShowAsync();
            }
        }
    }
}


