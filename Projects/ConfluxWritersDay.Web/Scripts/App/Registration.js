// todo: why isn't _references.js working?
/// <reference path="../angular.js" />
/// <reference path="../angular-animate.js" />
/// <reference path="../angular-cookies.js" />
/// <reference path="../angular-loader.js" />
/// <reference path="../angular-mocks.js" />
/// <reference path="../angular-resource.js" />
/// <reference path="../angular-route.js" />
/// <reference path="../angular-sanitize.js" />
/// <reference path="../angular-scenario.js" />
/// <reference path="../angular-touch.js" />

'use strict';

var app = angular.module('registrationApp', []);

app.controller('RegistrationController', function ($scope) {

    $scope.Submit = function (model) {
        alert("todo: submit");
    };

    // todo: think this could/should be a directive.
    $scope.showValidationMessages = function (field) {
        return (field.$invalid);
    };
});