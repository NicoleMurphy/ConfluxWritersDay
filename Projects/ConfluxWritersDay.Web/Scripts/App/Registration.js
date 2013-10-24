'use strict';

var app = angular.module("RegistrationApp", []);

function RegistrationController($scope) {

    $scope.submitAttempted = false;

    $scope.Submit = function (model) {
        $scope.submitAttempted = true;
    };

    // todo: think this could/should be a directive.
    $scope.showValidationMessages = function (field) {
        return (field.$invalid)
    }
}
