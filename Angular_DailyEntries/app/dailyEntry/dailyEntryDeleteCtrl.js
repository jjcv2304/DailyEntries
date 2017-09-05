(function () {
  "use strict";

  angular
    .module("dailyEntryApp")
    .controller("DailyEntryDeleteCtrl", ["dailyEntry", "$filter", "$state", DailyEntryDeleteCtrl]);

  function DailyEntryDeleteCtrl(dailyEntry, $filter) {
    var vm = this;

    vm.dailyEntry = dailyEntry;

    var _date = $filter('date')(new Date(vm.dailyEntry.date), 'MMM dd yyyy');
    vm.title = "Confirm Delete entry: " + _date;

    vm.remove = function () {
      vm.dailyEntry.$remove(vm.dailyEntry,function (data) {
        toastr.success("Deleted Successful");
        $state.go('dailyEntryList');
      },function (err) {
        toastr.error(err.data.exceptionMessage,'Error deleting');
      });
    };

    vm.cancel = function () {
      $state.go('dailyEntryList');
    }
  }
}());
