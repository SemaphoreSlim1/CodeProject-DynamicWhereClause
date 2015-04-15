using Common;
using Extensions;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicWhereWpf.ViewModel
{
    public class SearchCriteriaViewModel : ViewModelBase
    {
        public SearchCriteriaViewModel()
        {
            SearchOperator = "ANY";
        }

        #region FirstName Property

        /// <summary>
        /// Private member backing variable for <see cref="FirstName" />
        /// </summary>
        private String _FirstName = null;

        /// <summary>
        /// Gets and sets the first name search criteria
        /// </summary>
        [SearchCriteria]
        public String FirstName
        {
            get
            {
                if (_FirstName == null)
                { _FirstName = String.Empty; }

                return _FirstName;
            }
            set { Set(() => FirstName, ref _FirstName, value); }
        }

        #endregion
        
        #region LastName Property

        /// <summary>
        /// Private member backing variable for <see cref="LastName" />
        /// </summary>
        private String _LastName = null;

        /// <summary>
        /// Gets and sets the last name search criteria
        /// </summary>
        [SearchCriteria]
        public String LastName
        {
            get
            {
                if (_LastName == null)
                { _LastName = String.Empty; }

                return _LastName;
            }
            set { Set(() => LastName, ref _LastName, value); }
        }

        #endregion
        
        #region PresidentNumber Property

        /// <summary>
        /// Private member backing variable for <see cref="PresidentNumber" />
        /// </summary>
        private String _PresidentNumber = null;

        /// <summary>
        /// Gets and sets the president number search criteria
        /// </summary>
        [SearchCriteria]
        public String PresidentNumber
        {
            get
            {
                if (_PresidentNumber == null)
                { _PresidentNumber = String.Empty; }

                return _PresidentNumber;
            }
            set { Set(() => PresidentNumber, ref _PresidentNumber, value); }
        }

        #endregion

        #region Party Property

        /// <summary>
        /// Private member backing variable for <see cref="Party" />
        /// </summary>
        private String _Party = null;

        /// <summary>
        /// Gets and sets the party search criteria
        /// </summary>
        [SearchCriteria]
        public String Party
        {
            get
            {
                if (_Party == null)
                { _Party = String.Empty; }

                return _Party;
            }
            set { Set(() => Party, ref _Party, value); }
        }

        #endregion
        
        #region StartDate Property

        /// <summary>
        /// Private member backing variable for <see cref="StartDate" />
        /// </summary>
        private Nullable<DateTime> _StartDate = null;

        /// <summary>
        /// Gets and sets the president's start date search criteria
        /// </summary>
        [SearchCriteria]
        public Nullable<DateTime> StartDate
        {
            get { return _StartDate; }
            set { Set(() => StartDate, ref _StartDate, value); }
        }

        #endregion

        #region EndDate Property

        /// <summary>
        /// Private member backing variable for <see cref="EndDate" />
        /// </summary>
        private Nullable<DateTime> _EndDate = null;

        /// <summary>
        /// Gets and sets the end date search criteria
        /// </summary>
        [SearchCriteria]
        public Nullable<DateTime> EndDate
        {
            get { return _EndDate; }
            set { Set(() => EndDate, ref _EndDate, value); }
        }

        #endregion


        #region LivingStatusOptions Property

        /// <summary>
        /// Private member backing variable for <see cref="LivingStatusOptions" />
        /// </summary>
        private Dictionary<String, String> _LivingStatusOptions = null;

        /// <summary>
        /// Gets and sets the options for living status
        /// </summary>
        public Dictionary<String, String> LivingStatusOptions
        {
            get
            {
                if (_LivingStatusOptions == null)
                { 
                    _LivingStatusOptions = new Dictionary<String, String>();
                    _LivingStatusOptions.Add("Select a living status", "");
                    _LivingStatusOptions.Add("Alive or deceased", "ANY");
                    _LivingStatusOptions.Add("Alive", "ALIVE");
                    _LivingStatusOptions.Add("Deceased", "DEAD");
                }

                return _LivingStatusOptions;
            }
            set { Set(() => LivingStatusOptions, ref _LivingStatusOptions, value); }
        }

        #endregion


        #region LivingStatus property

        /// <summary>
        /// private member backing variable for <see cref="LivingStatus" />
        /// </summary>
        private String _LivingStatus = null;

        /// <summary>
        /// Gets and sets the desired living status of the president
        /// </summary>
        [SearchCriteria]
        public String LivingStatus
        {
            get
            {
                if(_LivingStatus == null)
                { _LivingStatus = String.Empty; }

                return _LivingStatus;
            }
            set { Set(() => LivingStatus, ref _LivingStatus, value); }
        }

        #endregion

        #region TermCount Property

        /// <summary>
        /// Private member backing variable for <see cref="TermCount" />
        /// </summary>
        private String _TermCount = null;

        /// <summary>
        /// Gets and sets the search criteria for the number of terms
        /// </summary>
        [SearchCriteria]
        public String TermCount
        {
            get
            {
                if (_TermCount == null)
                { _TermCount = String.Empty; }

                return _TermCount;
            }
            set { Set(() => TermCount, ref _TermCount, value); }
        }

        #endregion
                        
        #region SearchOperator Property

        /// <summary>
        /// Private member backing variable for <see cref="SearchOperator" />
        /// </summary>
        private String _SearchOperator = null;

        /// <summary>
        /// Gets and sets the operator to use to append search criteria
        /// </summary>
        public String SearchOperator
        {
            get
            {
                if (_SearchOperator == null)
                { _SearchOperator = String.Empty; }

                return _SearchOperator;
            }
            set { Set(() => SearchOperator, ref _SearchOperator, value); }
        }

        #endregion

        /// <summary>
        /// Returns true, if this view model has criteria to search against
        /// </summary>        
        public Boolean HasCriteria()
        {
            //get the properites of this object
            var properties = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            var searchProperties = properties.Where(p => p.CustomAttributes.Select(a => a.AttributeType).Contains(typeof(SearchCriteriaAttribute)));

            return searchProperties.Where(sp => sp.GetValue(this).ToStringInstance().HasValue()).Any();
        }

        public Expression<Func<Model.President, Boolean>> ToExpression()
        {
            Expression<Func<Model.President, Boolean>> result = null;

            int presidentNumberIntValue = 0;
            if(PresidentNumber.HasValue() && Int32.TryParse(PresidentNumber, out presidentNumberIntValue) && presidentNumberIntValue > 0)
            {
                Expression<Func<Model.President, Boolean>> expr = model => model.PresidentNumber == presidentNumberIntValue;
                result = AppendExpression(result, expr);
            }

            if (FirstName.HasValue())
            {
                Expression<Func<Model.President, Boolean>> expr = model => model.FirstName.Like(FirstName);
                result = AppendExpression(result, expr);
            }

            if (LastName.HasValue())
            {
                Expression<Func<Model.President, Boolean>> expr = model => model.LastName.Like(LastName);
                result = AppendExpression(result, expr);
            }

            if(StartDate.HasValue)
            {
                Expression<Func<Model.President, Boolean>> expr = model => model.TookOffice >= StartDate;
                result = AppendExpression(result, expr);
            }

            if(EndDate.HasValue)
            {
                Expression<Func<Model.President, Boolean>> expr = model => model.LeftOffice <= EndDate;
                result = AppendExpression(result, expr);
            }

            if (LivingStatus.HasValue())
            {
                if (LivingStatus.ToUpper() == "ALIVE")
                {
                    Expression<Func<Model.President, Boolean>> expr = model => model.IsAlive == true;
                    result = AppendExpression(result, expr);
                }
                else if (LivingStatus.ToUpper() == "DEAD")
                {
                    Expression<Func<Model.President, Boolean>> expr = model => model.IsAlive == false;
                    result = AppendExpression(result, expr);
                }
                else
                {
                    Expression<Func<Model.President, Boolean>> expr = model => model.IsAlive == true || model.IsAlive == false;
                    result = AppendExpression(result, expr);
                }
            }

            var termCounntIntValue = 0;
            if(TermCount.HasValue() && Int32.TryParse(TermCount,out termCounntIntValue) && termCounntIntValue > 0 )
            {
                Expression<Func<Model.President, Boolean>> expr = model => model.Terms.Count() == termCounntIntValue;
                result = AppendExpression(result, expr);
            }
            

            return result;
        }

        private Expression<Func<Model.President, Boolean>> AppendExpression(Expression<Func<Model.President, Boolean>> left, Expression<Func<Model.President, Boolean>> right)
        {
            Expression<Func<Model.President, Boolean>> result;

            switch (SearchOperator)
            {
                case "ANY":

                    //the initial case starts off with a left epxression as null. If that's the case,
                    //then give the short-circuit operator something to trigger on for the right expression
                    if(left == null)
                    { left = model => false; }

                    result = ExpressionExtension<Model.President>.OrElse(left, right);
                    break;
                case "ALL":
                    
                    if(left == null)
                    { left = model => true; }

                    result = ExpressionExtension<Model.President>.AndAlso(left, right);
                    break;
                default:
                    throw new InvalidOperationException();
            }

            return result;
        
        }
    }
}
