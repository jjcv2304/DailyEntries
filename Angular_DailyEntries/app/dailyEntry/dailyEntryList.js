(function () {
  "use strict";

  angular.module("dailyEntryApp")
    .component("dailyEntryList", {
      templateUrl: 'app/dailyEntry/dailyEntryListView.html',
      bindings: {},
     controller: ["dailyEntryResource", DailyEntryList]
});

  function DailyEntryList(dailyEntryResource) {
    var $ctrl = this;

    dailyEntryResource.get(function (data) {
      $ctrl.dailyEntries = data.dailyFeelingsVM;
    });

    $ctrl.delete = function (dailyEntry) {
      dailyEntry.$remove();
    }
  }

}());
