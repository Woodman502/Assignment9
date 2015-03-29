(function() {
  var app = angular.module('angApp', []);

  app.controller('AngularController', ['$http',function($http){
    var angular = this;
    angular.tutorials = [];
    $http.get('tutorials.json').success(function(data){
    	angular.tutorials = data;
    });
  }]);

})();
 
