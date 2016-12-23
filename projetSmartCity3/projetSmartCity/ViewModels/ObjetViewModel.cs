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
    public class ObjetViewModel : ViewModelBase, INotifyPropertyChanged
    {   
        private ICommand _validationCommand;
        private INavigationService _navigationService;

        public ICommand ValidationCommand
        {
            get
            {
                if (_validationCommand == null)
                {
                    _validationCommand = new RelayCommand(() => AjouterObjet());
                }
                return _validationCommand;
            }
        }

        private async Task AjouterObjet()
        {
            if ((NomObjet != null) && (EtatBox != null))
            {
                Annonce.NomObj = NomObjet;
                Annonce.Etat = EtatBox;
                Annonce.Commentaire = Commentaire;

                var annonceService = new AnnonceService();
                var post = await annonceService.PostAnnonce(Annonce);
                if (post.ok)
                {
                    _navigationService.NavigateTo("MainPage");
                }
                else
                {
                    var dialogue = new Windows.UI.Popups.MessageDialog("Message d'erreur de la requète: " + post.errorMessage);
                    dialogue.ShowAsync();
                }
            }
            else
            {
                var dialogue = new Windows.UI.Popups.MessageDialog("Il y a des champs qui sont vides");
                dialogue.ShowAsync();
            }
        }

        public ObjetViewModel(INavigationService navigationService)
        {
            EtatList = new ObservableCollection<string>() { "Neuf", "Très bon état", "bon état", "état moyen", "mauvais état" };
            _navigationService = navigationService;
          
            
        }

        private ObservableCollection<string> _etatList;
        public ObservableCollection<string> EtatList
        {
            get { return _etatList; }
            set
            {
                _etatList = value;
                RaisePropertyChanged("EtatList");
            }
        }
        
        private string _nomObjet;
        public string NomObjet
        {
            get { return _nomObjet; }
            set
            {
                _nomObjet = value;
                RaisePropertyChanged("NomObjet");
            }
        }

        private string _etatBox;
        public string EtatBox
        {
            get { return _etatBox; }
            set
            {
                _etatBox = value;
                RaisePropertyChanged("EtatBox");
            }
        }
        private string _commentaire;
        public string Commentaire
        {
            get { return _commentaire; }
            set
            {
                _commentaire = value;
                RaisePropertyChanged("Commentaire");
            }
        }
        private AnnonceCreateModel _annonce;
        public AnnonceCreateModel Annonce
        {
            get { return _annonce; }
            set
            {
                _annonce = value;
                RaisePropertyChanged("Annonce");
            }
        }
        public void OnNavigatedTo(NavigationEventArgs e)
        {
            Annonce = (AnnonceCreateModel)e.Parameter;
        }
        

        
    }
}
