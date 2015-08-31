(function () {
    angular.module('app.Employee', ['ngResource', 'ngCookies','ngRoute']).config(['$compileProvider', function ($compileProvider) {
        $compileProvider.debugInfoEnabled(false);
    }])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/employees', {
            templateUrl: 'employees.html',
            controller: 'AppController'

        });
        $locationProvider.html5Mode({ enable: true, requireBase: true });
    })
    .factory('data', ['$resource','$cookies', function ($resource,$cookies) {
        return $resource('/api/Employee/:id/:link', null, {
    
            'Getfilter': { method: 'get', isArray: true },
            'query': { method: 'get', isArray: true, headers: { Authorization: 'Bearer ' + $cookies.get('access_token') } }
    });
    }])
    .factory('UserService', [function () {
        var service = {};

        service.GetAll = GetAll;
        service.GetById = GetById;
        service.GetByUsername = GetByUsername;
        service.Create = Create;
        service.Update = Update;
        service.Delete = Delete;

        return service;

        function GetAll() {
            return $http.get('/api/users').then(handleSuccess, handleError('Error getting all users'));
        }

        function GetById(id) {
            return $http.get('/api/users/' + id).then(handleSuccess, handleError('Error getting user by id'));
        }

        function GetByUsername(username) {
            return $http.get('/api/users/' + username).then(handleSuccess, handleError('Error getting user by username'));
        }

        function Create(user) {
            return $http.post('/api/users', user).then(handleSuccess, handleError('Error creating user'));
        }

        function Update(user) {
            return $http.put('/api/users/' + user.id, user).then(handleSuccess, handleError('Error updating user'));
        }

        function Delete(id) {
            return $http.delete('/api/users/' + id).then(handleSuccess, handleError('Error deleting user'));
        }

        // private functions

        function handleSuccess(data) {
            return data;
        }

        function handleError(error) {
            return function () {
                return { success: false, message: error };
            };
        }


    }])
    .factory('AuthenticationService', ['$http', '$cookies', function ($http, $cookies) {
        var service = {};

        service.Login = Login;
        service.SetToken = SetToken;
     
        return service;
        function Login(username, password, callback) {
            $http({
                method: 'POST',
                url: '/token',
                data: 'grant_type=password&username=' + username + '&password=' + password,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            })
                .success(function (response) {
                    callback(response);
                });

        }
        function SetToken(token) {
            $cookies.put('access_token', token.access_token);
        }




    }])
    .controller('LoginController', ['AuthenticationService', '$scope','$location', function (AuthenticationService, $scope,$location) {
        $scope.username;
        $scope.password;
        $scope.submit = function () {
            AuthenticationService.Login($scope.username, $scope.password, function (response) {
                if (response) {
                    AuthenticationService.SetToken(response);
                    $location.path('/employees');
                }
                
            });
        }

    }])
    .controller('AppController', ['$scope', 'data', function ($scope, data) {
        $scope.employees = data.query();
    }])
    
})();
