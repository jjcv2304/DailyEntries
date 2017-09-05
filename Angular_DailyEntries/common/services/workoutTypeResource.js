(function () {
    "use strict";

    angular.module("common.services")
        .factory("workoutTypeResource", ["$resource", "appSettings", workoutTypeResource]);

    function workoutTypeResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "/api/workoutType/:workoutTypeId", null,{
            'update': { method:'PUT' }
        });
    }

}());
