// todo: why isn't _references.js working?
/// <reference path="/Scripts/angular.js" />

'use strict';

var app = angular.module('registrationApp', []);

app.controller('RegistrationController', function ($scope) {

    $scope.Registration = {
        FirstName: "a",
        LastName: ""
    }

    $scope.submit = function (model) {
        alert("todo: submit " + model);
    };
});

