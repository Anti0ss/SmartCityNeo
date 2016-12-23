using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using projetSmartCity.DAO;
using projetSmartCity.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;

namespace projetSmartCity.ViewModels
{
    public class NouvelleDemandeViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _goToMainPageCommand;
        private ICommand _goToObjetCommand;
        private INavigationService _navigationService;


        public NouvelleDemandeViewModel(INavigationService navigationService)
        {
            Date_de_debut = DateTime.Now;
            Date_de_fin = DateTime.Now;
            InitializeAsync();
            _navigationService = navigationService;
        }

        public async Task InitializeAsync()
        {
            var catService = new CategorieService();
            var cat = await catService.GetCategorie();
            var utilisateurService = new UtilisateurService();
            User = await utilisateurService.GetUtilisateur();
            CategorieList = new ObservableCollection<Categorie>(cat);
        }
        private ApplicationUser _user;
        public ApplicationUser User
        {
            get { return _user; }
            set
            {
                _user = value;
                RaisePropertyChanged("User");
            }
        }

        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set
            {
                _nom = value;
                RaisePropertyChanged("Nom");
            }
        }



        private ObservableCollection<Categorie> _categorieList;
        public ObservableCollection<Categorie> CategorieList
        {
            get { return _categorieList; }
            set
            {

                _categorieList = value;
                RaisePropertyChanged("CategorieList");
            }
        }
        private Categorie _categorie;
        public Categorie Categorie
        {
            get { return _categorie; }
            set
            {
                if (_categorie == value)
                {
                    return;
                }
                _categorie = value;
                RaisePropertyChanged("Categorie");
            }
        }

        private DateTimeOffset _date_de_debut;
        public DateTimeOffset Date_de_debut
        {
            get { return _date_de_debut; }
            set
            {
                _date_de_debut = value;
                RaisePropertyChanged("Date_de_debut");
            }
        }
        private DateTimeOffset _date_de_fin;
        public DateTimeOffset Date_de_fin
        {
            get { return _date_de_fin; }
            set
            {
                _date_de_fin = value;
                RaisePropertyChanged("Date_de_fin");
            }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged("Description");
            }
        }
        private AnnonceCreateModel _demande;
        public AnnonceCreateModel Demande
        {
            get { return _demande; }
            set
            {
                _demande = value;
                RaisePropertyChanged("Demande");
            }
        }

        private bool _urgence;
        public bool Urgence
        {
            get { return _urgence; }
            set
            {
                _urgence = value;
                RaisePropertyChanged("Urgence");
            }
        }

        public ICommand GoToObjetCommand
        {
            get
            {
                if (_goToObjetCommand == null)
                    _goToObjetCommand = new RelayCommand(() => GoToObjetView());
                return _goToObjetCommand;
            }
        }
        private void GoToObjetView()
        {
            if ((Nom != null) && (Categorie != null) && (Description != null) && (Date_de_debut != null) && (Date_de_fin != null))
            {
                AnnonceCreateModel Demande = new AnnonceCreateModel(User.Id, Categorie.IdCategorie, Nom, Description, Date_de_debut.DateTime, Date_de_fin.DateTime, Urgence, "Non disponible", "Demande");
                Ajouter(Demande);
            }else
            {
                var dialogue = new Windows.UI.Popups.MessageDialog("Il y a un champs qui n'a pas été remplis!!!");
                dialogue.ShowAsync();
            }
        }
        private async Task Ajouter(AnnonceCreateModel Demande)
        {
            int comparaison = Demande.Date_de_debut.CompareTo(Demande.Date_de_fin);
            if (comparaison >= 0)
            {
                var dialogue = new Windows.UI.Popups.MessageDialog("La date de début est ultérieur ou à la même valeur que la date de fin");
                dialogue.ShowAsync();
            }
            else
            {
                _navigationService.NavigateTo("ObjetView", Demande);
            }
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
            _navigationService.NavigateTo("MainPage");
        }
    }
}
