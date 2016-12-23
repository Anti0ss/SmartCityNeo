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
    public class AnnonceViewModel : ViewModelBase, INotifyPropertyChanged

    {
        private ICommand _goToMainPageCommand;
        private ICommand _goToAnnonceCommand;
        private INavigationService _navigationService;

        public AnnonceViewModel(INavigationService navigationService = null)
        {
            InitializeAsync();
            _navigationService = navigationService;   
             
        }
        public async Task InitializeAsync()
        {
            var utilisateurService = new UtilisateurService();
            var utilisateurCourant = await utilisateurService.GetUtilisateur(); 
            DateTime dateAjd = System.DateTime.Now;
            var catService = new CategorieService();
            var cat = await catService.GetCategorie();
            CategorieList = new ObservableCollection<Categorie>(cat);
            var annService = new AnnonceService();
            var ann = await annService.GetAnnonce();
            AnnonceList = new ObservableCollection<Annonce>(ann);
            AnnonceDefini = new ObservableCollection<Annonce>();
            ObservableCollection<int> listIndex = new ObservableCollection<int>();
            

            foreach(Annonce annoncePropo in AnnonceList)
            {
               
              
                        Annonce _annonceDefinitive = new Annonce(annoncePropo.Nom, annoncePropo.Description, annoncePropo.Date_de_debut, annoncePropo.Date_de_fin, annoncePropo.Urgence, annoncePropo.Disponibilite, annoncePropo.Type, annoncePropo.Utilisateur, annoncePropo.Categorie, annoncePropo.Objet);
                        AnnonceDefini.Add(_annonceDefinitive);
                    
                
            }

            for (int index = 0; index < AnnonceDefini.Count(); index++)
            {
             

                if ( (AnnonceDefini[index].Type == "Demande") || (AnnonceDefini[index].Disponibilite=="Non disponible")||(AnnonceDefini[index].Utilisateur.Id == utilisateurCourant.Id ))
                {
                    listIndex.Add(index);
                }
            }

            for (int indice = listIndex.Count() - 1; indice > -1; indice--)
            {
                AnnonceDefini.RemoveAt(listIndex[indice]);
            }

            if (Recherche != null) { 
                    if (Recherche.Categorie != null)
                    {
                        listIndex.Clear();
                        for (int indiceCat = 0; indiceCat < AnnonceDefini.Count(); indiceCat++)
                        {
                            if (!AnnonceDefini[indiceCat].Categorie.Libelle.Equals((string)Recherche.Categorie.Libelle))
                            {
                            listIndex.Add(indiceCat);
                            }
                        }
                        for (int indexCat = listIndex.Count - 1; indexCat > -1; indexCat--)
                        {
                        AnnonceDefini.RemoveAt(listIndex[indexCat]);
                        }

                    }
                    if (Recherche.Nom != null)
                    {
                        listIndex.Clear();
                        for (int indiceNom = 0; indiceNom < AnnonceDefini.Count(); indiceNom++)
                        {
                            if (!AnnonceDefini[indiceNom].Nom.Equals((string)Recherche.Nom) && !AnnonceDefini[indiceNom].Objet.Nom.Equals((string)Recherche.Nom))
                            {
                            listIndex.Add(indiceNom);
                            }
                        }
                        for(int indexNom=listIndex.Count()-1; indexNom>-1; indexNom--)
                        {
                        AnnonceDefini.RemoveAt(listIndex[indexNom]);
                        }
                    }

                    if (Recherche.Urgence == true)
                    {
                            listIndex.Clear();
                        for (int indiceUrgence = 0; indiceUrgence < AnnonceDefini.Count(); indiceUrgence++)
                        {
                            var comparaisonDateDeb = dateAjd.CompareTo(AnnonceDefini[indiceUrgence].Date_de_debut);
                            var comparaisonDateFin = dateAjd.CompareTo(AnnonceDefini[indiceUrgence].Date_de_fin);
                            if ((comparaisonDateDeb < 0) || (comparaisonDateFin > 0))
                            {
                            listIndex.Add(indiceUrgence);
                            }
                        }
                        for(int indexUrgence= listIndex.Count()-1;indexUrgence>-1; indexUrgence--)
                        {
                        AnnonceDefini.RemoveAt(listIndex[indexUrgence]);
                        }
                    }
                if (AnnonceDefini.Count() == 0)
                {
                    var dialogue = new Windows.UI.Popups.MessageDialog("Aucun résultat");
                    dialogue.ShowAsync();
                }
            }
        }
      
        private ObservableCollection<Annonce> _annonceDefini;
        public ObservableCollection<Annonce> AnnonceDefini
        {
            get { return _annonceDefini; }
            set
            {
                _annonceDefini = value;
                RaisePropertyChanged("AnnonceDefini");
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
        private ObservableCollection<Annonce> _annonceList;
        public ObservableCollection<Annonce> AnnonceList
        {
            get { return _annonceList; }
            set
            {

                _annonceList = value;
                RaisePropertyChanged("AnnonceList");
            }
        }
        private Recherche _recherche;
        public Recherche Recherche
        {
            get { return _recherche; }
            set
            {
                _recherche = value;
                if (_recherche != null)
                {
                    RaisePropertyChanged("Recherche");
                }
            }
        }
        private Categorie _categorie;
        public Categorie Categorie
        {
            get { return _categorie; }
            set
            {
               
                _categorie = value;
                RaisePropertyChanged("Categorie");
            }
        }
        private Annonce _annonce;
        public Annonce Annonce
        {
            get { return _annonce; }
            set
            {
               
                    _annonce = value;
                    RaisePropertyChanged("Annonce");
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
            Recherche = new Recherche(Nom, Urgence, "Disponible", Categorie);
            _navigationService.NavigateTo("AnnonceView",Recherche);
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
        public void OnNavigatedTo(NavigationEventArgs e)
        {
            Recherche = (Recherche)e.Parameter;
        }

    }
}
