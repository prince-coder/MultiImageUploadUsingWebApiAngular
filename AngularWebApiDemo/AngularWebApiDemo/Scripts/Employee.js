angular.module('MyApp', [])
    .controller('EmployeeController', function($scope, $http) {
        debugger;
        $http.get('http://localhost:61649/api/Employee/').success(function (data) {
            debugger;
            alert('Success');
            $scope.Employees = data;

        })

        .error(function () {
            debugger;
            $scope.error = "An error occured while loading data";

        });
        $scope.toggleEdit = function () {
            this.Employee.editMode = !this.Employee.editMode;
        };
        $scope.toggleAdd = function () {
            debugger;
            $scope.addMode = !$scope.addMode;
        };
        //For Adding New Record
        $scope.add = function () {
            debugger;
            $http.post('http://localhost:61649/api/Employee/', this.newEmployee).success(function (data) {
                debugger;
                alert('Data Added Successfully');
                $scope.addMode = false;
                $scope.Employees.push(data);
            })

            .error(function () {
                debugger;
                $scope.error = "An Error has Occured While Adding Employee" + data;
            });




        };
        $scope.save = function () {
            debugger;
            alert('Edit');
            
            $http.put('/api/Employee/', this.Employee).success(function (data) {
                debugger;
                alert("Saved Successfully");
                $scope.editMode = false;
            }).error(function (data) {
                debugger;
                $scope.error = "An eroor has occured while updating" + data;
            });
        };

        $scope.deleteEmployee = function () {
            debugger;
            var EmpId = this.Employee.EmpId;
            $http.delete('http://localhost:61649/api/Employee/' +EmpId).success(function (data) {
                debugger;
                alert("Deleted Successfully");
                $.each($scope.Employees, function (i) {
                    if ($scope.Employees[i].EmpId == EmpId) {
                        $scope.Employees.splice(i, 1);
                        return false;
                    }
                });

            }).error(function (data) {
                debugger;
                $scope.error = "An error occured while deleting employee" + data;
            });
            };

    });