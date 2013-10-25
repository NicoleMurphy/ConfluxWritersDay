// todo: why isn't _references.js working?
/// <reference path="/Scripts/angular.js" />

'use strict';

var app = angular.module('registrationApp', ['textfield']);

app.controller('RegistrationController', function ($scope) {

    $scope.Registration = {
        FirstName: "a",
        LastName: "",
        Suburb: "",
    }

    $scope.submit = function (model) {
        alert("todo: submit " + model);
    };
});

