/// <reference path="Framework/knockout-3.3.0.debug.js" />
/// <reference path="Framework/jquery-1.10.2.intellisense.js" />


function ViewModel() {
    var self = this;

    self.FirstName = ko.observable();
    self.LastName = ko.observable();
    self.PresidentNumber = ko.observable();
    self.StartDate = ko.observable();
    self.EndDate = ko.observable();
    self.TermCount = ko.observable();
    self.SearchOperator = ko.observable();

    self.Search = function () {  };

    self.SearchResults = ko.observableArray();
}

$().ready(function () {
    var VM = new ViewModel();

    ko.applyBindings(VM);
});

