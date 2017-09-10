"use strict";

describe('Daily entry list controller', function () {
  var $controller, scope, $ctrl, mockDailyEntryResource, mockDailyEntry, rootScope;

  beforeEach(module('dailyEntryApp'));

  beforeEach(inject(function ($componentController, $rootScope) {
    //rootScope = $rootScope;
    //scope = $rootScope.$new();
    $controller = $componentController;
    mockDailyEntry = sinon.stub({
      $remove: function () {
      }
    });
    mockDailyEntryResource = sinon.stub({
      get: function () {
      }, save: function () {
      }, update: function () {
      }
    })
  }));

  it('should call the get function on initializing the controller', function () {
    // $ctrl = $controller('dailyEntryList', {}, {$scope: scope, dailyEntryResource: mockDailyEntryResource});
    $ctrl = $controller('dailyEntryList', { dailyEntryResource: mockDailyEntryResource}, {});
    expect(mockDailyEntryResource.get.calledOnce).toBeTruthy();
  });

});