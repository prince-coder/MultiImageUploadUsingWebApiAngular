angular.module('MyApp', [])
.controller('AdminController', function ($scope, $http, $window) {
    debugger;
    $scope.Login = function () {
        debugger;
        $http.post('http://localhost:50280/api/Admin', this.Admin).success(function (data) {
            debugger;
            alert("Login Successful");
            $window.location.href = "http://localhost:60847/ProductOwnerRequest/List";
        })
        .error(function (data) {
            debugger;
            alert($scope.error);
        });
    };
})

.controller('ProductOwnerRequestController', function ($scope, $http,$window) {
    $scope.submitForm = function () {
        $scope.submitted = true;
 
       if ($scope.AddData.$valid) {
           debugger;
           $scope.SaveData = function () {
               debugger;
               $http.post('http://localhost:50280/api/ProductOwnerRequestApi', this.ProductOwnerRequest).success(function (data) {
                   debugger;
                   alert('Data Submitted Successfully');

               })
               .error(function (data) {
                   debugger;
                   alert($scope.eror);
               });
           };
       }
       else {
        alert("Please correct errors!");
        }
    };
    //$scope.Approve = function () {
        //debugger;
        $http.get('http://localhost:50280/api/ProductOwnerRequestApi').success(function (data) {
            debugger;
            alert('success');
            $scope.ProductOwnerRequests = data;
        })
        .error(function (data) {
            debugger;
            alert($scope.error);
        });
        $scope.Approve = function () {
            debugger;
            $http.get('http://localhost:50280/api/ProductOwnerRequestApi/' + this.ProductOwnerRequest.Id).success(function (data) {
                debugger;
                alert('success');
                $scope.ProductOwnerRequests = data;
            })
            .error(function (data) {
                debugger;
                alert($scope.error);
            });

        };
        $scope.DisApprove = function () {
            debugger;
            
                if ($window.confirm("Are You Sure you want to Desapprove?")) {
                    var id = this.ProductOwnerRequest.Id;
                    $http.delete('http://localhost:50280/api/ProductOwnerRequestApi/' + id).success(function (data) {
                        debugger;
                        alert('Deleted Successfully');
                        $.each($scope.ProductOwnerRequests, function (i) {
                            if ($scope.ProductOwnerRequests[i].Id == id) {
                                $scope.ProductOwnerRequests.splice(i, 1);
                                return false;
                            }
                        });
                    })
                    .error(function (data) {
                        debugger;
                        $scope.error = "An Error Occured while deleting data" + data;
                    });
                }
            };  
});