using GalaSoft.MvvmLight;
using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using System;

namespace DynamicWhereWpf.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            this.SearchCriteriaViewModel = new SearchCriteriaViewModel();
        }

        public SearchCriteriaViewModel SearchCriteriaViewModel { get; private set; }


        #region MatchOptions Property

        /// <summary>
        /// Private member backing variable for <see cref="MatchOptions" />
        /// </summary>
        private IEnumerable<SearchOperator> _MatchOptions = null;

        /// <summary>
        /// Gets and sets how to match the search criteria
        /// </summary>
        public IEnumerable<SearchOperator> MatchOptions
        {
            get
            {
                if (_MatchOptions == null)
                { _MatchOptions = new SearchOperator[] { 
                    new SearchOperator{ Description = "Match any criteria", Operator="ANY" }, 
                    new SearchOperator{ Description = "Match all criteria", Operator = "ALL"} }; 
                }

                return _MatchOptions;
            }
            set { Set(() => MatchOptions, ref _MatchOptions, value); }
        }

        #endregion

        
        #region Search Command

        /// <summary>
        /// Private member backing variable for <see cref="Search" />
        /// </summary>
        private RelayCommand _Search = null;

        /// <summary>
        /// Gets the command which executes the search
        /// </summary>
        public RelayCommand Search
        {
            get
            {
                if (_Search == null)
                { _Search = new RelayCommand(Search_Execute, Search_CanExecute); }

                return _Search;
            }
        }

        /// <summary>
        /// Implements the execution of <see cref="Search" />
        /// </summary>
        private void Search_Execute()
        {
            var presidents = PresidentRepository.GetAllPresidents();

            if(SearchCriteriaViewModel.HasCriteria())
            {
                presidents = presidents.Where(SearchCriteriaViewModel.ToExpression());
            }

            //force the IQueryable execution plan to execute
            var peopleResults = presidents.ToList();

            Application.Current.Dispatcher.Invoke(() => {
                SearchResults.Clear();
                
                foreach(var person in peopleResults.OrderBy(p => p.LastName))
                {
                    SearchResults.Add(person);
                }
            });
        }

        /// <summary>
        /// Determines if <see cref="Search" /> is allowed to execute
        /// </summary>
        private Boolean Search_CanExecute()
        {
            return true;
        }

        #endregion
        
        #region SearchResults Property

        /// <summary>
        /// Private member backing variable for <see cref="SearchResults" />
        /// </summary>
        private ICollection<President> _SearchResults = null;

        /// <summary>
        /// Gets and sets the people matching the search criteria
        /// </summary>
        public ICollection<President> SearchResults
        {
            get
            {
                if (_SearchResults == null)
                { _SearchResults = new ObservableCollection<President>(); }

                return _SearchResults;
            }
            set { Set(() => SearchResults, ref _SearchResults, value); }
        }

        #endregion

    }
}