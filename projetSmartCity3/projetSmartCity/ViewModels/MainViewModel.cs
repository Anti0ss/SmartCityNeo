using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace projetSmartCity.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        private ICommand _goToCompteCommand;
        private ICommand _goToAnnonceCommand;
        private ICommand _goToNouvelleOffreCommand;
        private ICommand _goToNouvelleDemandeCommand;
        private ICommand _goToDemandeVoisinCommand;
        private INavigationService _navigationService;

        [PreferredConstructor]
        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public ICommand GoToCompteCommand
        {
            get
            {
                if (_goToCompteCommand == null)
                    _goToCompteCommand = new RelayCommand(() => GoToCompteView());
                return _goToCompteCommand;
            }
        }
        private void GoToCompteView()
        {
            _navigationService.NavigateTo("CompteView");
        }
        public ICommand GoToAnnonceCommand
        {
            get
            {
                if (_goToAnnonceCommand == null)
                    _goToAnnonceCommand = new RelayCommand(() => GoToAnnonceView());
                return _goToAnnonceCommand;
            }
        }
        private void GoToAnnonceView()
        {
            _navigationService.NavigateTo("AnnonceView");
        }
        public ICommand GoToNouvelleOffreCommand
        {
            get
            {
                if (_goToNouvelleOffreCommand == null)
                    _goToNouvelleOffreCommand = new RelayCommand(() => GoToNouvelleOffreView());
                return _goToNouvelleOffreCommand;
            }
        }
        private void GoToNouvelleOffreView()
        {
            _navigationService.NavigateTo("NouvelleOffreView");
        }
        public ICommand GoToNouvelleDemandeCommand
        {
            get
            {
                if (_goToNouvelleDemandeCommand == null)
                    _goToNouvelleDemandeCommand = new RelayCommand(() => GoToNouvelleDemandeView());
                return _goToNouvelleDemandeCommand;
            }
        }
        private void GoToNouvelleDemandeView()
        {
            _navigationService.NavigateTo("NouvelleDemandeView");
        }
        public ICommand GoToDemandeVoisinCommand
        {
            get
            {
                if (_goToDemandeVoisinCommand == null)
                    _goToDemandeVoisinCommand = new RelayCommand(() => GoToDemandeVoisinView());
                return _goToDemandeVoisinCommand;
            }
        }
        private void GoToDemandeVoisinView()
        {
            _navigationService.NavigateTo("DemandeVoisinView");
        }
    }
}
