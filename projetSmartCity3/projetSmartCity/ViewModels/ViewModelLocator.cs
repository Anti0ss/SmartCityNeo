using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetSmartCity.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AnnonceViewModel>();
            SimpleIoc.Default.Register<CompteViewModel>();
            SimpleIoc.Default.Register<ConnexionViewModel>();
            SimpleIoc.Default.Register<InscriptionViewModel>();
            SimpleIoc.Default.Register<NouvelleOffreViewModel>();
            SimpleIoc.Default.Register<NouvelleDemandeViewModel>();
            SimpleIoc.Default.Register<DemandeVoisinViewModel>();
            SimpleIoc.Default.Register<ObjetViewModel>();
            NavigationService navigationPages = new NavigationService();
            SimpleIoc.Default.Unregister<INavigationService>();
            SimpleIoc.Default.Register<INavigationService>(() => navigationPages);

            navigationPages.Configure("AnnonceView", typeof(AnnonceView));
            navigationPages.Configure("CompteView", typeof(CompteView));
            navigationPages.Configure("ConnexionView", typeof(ConnexionView));
            navigationPages.Configure("InscriptionView", typeof(InscriptionView));
            navigationPages.Configure("MainPage", typeof(MainPage));
            navigationPages.Configure("NouvelleOffreView", typeof(NouvelleOffreView));
            navigationPages.Configure("NouvelleDemandeView", typeof(NouvelleDemandeView));
            navigationPages.Configure("DemandeVoisinView", typeof(DemandeVoisinView));
            navigationPages.Configure("ObjetView", typeof(ObjetView));

        }
        public MainViewModel MainPage
        {
            get
            {
                SimpleIoc.Default.Unregister<MainViewModel>();
                SimpleIoc.Default.Register<MainViewModel>();
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public AnnonceViewModel AnnonceView
        {
            get
            {
                SimpleIoc.Default.Unregister<AnnonceViewModel>();
                SimpleIoc.Default.Register<AnnonceViewModel>();
                return ServiceLocator.Current.GetInstance<AnnonceViewModel>();
            }
        }
        public CompteViewModel CompteView
        {
            get
            {
                SimpleIoc.Default.Unregister<CompteViewModel>();
                SimpleIoc.Default.Register<CompteViewModel>();
                return ServiceLocator.Current.GetInstance<CompteViewModel>();
            }
        }
        public ConnexionViewModel ConnexionView
        {
            get
            {
                SimpleIoc.Default.Unregister<ConnexionViewModel>();
                SimpleIoc.Default.Register<ConnexionViewModel>();
                return ServiceLocator.Current.GetInstance<ConnexionViewModel>();
            }
        }
        public InscriptionViewModel InscriptionView
        {
            get
            {
                SimpleIoc.Default.Unregister<InscriptionViewModel>();
                SimpleIoc.Default.Register<InscriptionViewModel>();
                return ServiceLocator.Current.GetInstance<InscriptionViewModel>();
            }
        }
        public NouvelleOffreViewModel NouvelleOffreView
        {
            get
            {
                SimpleIoc.Default.Unregister<NouvelleOffreViewModel>();
                SimpleIoc.Default.Register<NouvelleOffreViewModel>();
                return ServiceLocator.Current.GetInstance<NouvelleOffreViewModel>();
            }
        }
        public NouvelleDemandeViewModel NouvelleDemandeView
        {
            get
            {
                SimpleIoc.Default.Unregister<NouvelleDemandeViewModel>();
                SimpleIoc.Default.Register<NouvelleDemandeViewModel>();
                return ServiceLocator.Current.GetInstance<NouvelleDemandeViewModel>();
            }
        }
        public DemandeVoisinViewModel DemandeVoisinView
        {
            get
            {
                SimpleIoc.Default.Unregister<DemandeVoisinViewModel>();
                SimpleIoc.Default.Register<DemandeVoisinViewModel>();
                return ServiceLocator.Current.GetInstance<DemandeVoisinViewModel>();
            }
        }
        public ObjetViewModel ObjetView
        {
            get
            {
                SimpleIoc.Default.Unregister<ObjetViewModel>();
                SimpleIoc.Default.Register<ObjetViewModel>();
                return ServiceLocator.Current.GetInstance<ObjetViewModel>();
            }
        }

    }
}
