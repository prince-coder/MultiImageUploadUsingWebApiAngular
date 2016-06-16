angular.module('MyApp', [])
    .controller('EmployeeController', function($scope, $http) {
        debugger;
        $http.get('http://localhost:61649/api/Employee').success(function (data) {
            debugger;
            alert('Success');
            $scope.Employees = data;

        })

        .error(function () {
            debugger;
            $scope.error = "An error occured while loading data";

        });

    });