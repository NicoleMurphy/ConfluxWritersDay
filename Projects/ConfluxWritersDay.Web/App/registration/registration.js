// todo: why isn't _references.js working?
/// <reference path="/Scripts/angular.js" />

'use strict';

var app = angular.module('registrationApp', ['field']);

app.controller('RegistrationController', function ($scope) {

    $scope.Registration = {
        MembershipOrganisation: ''
    };

    $scope.MembershipOrganisations = [
        {
            'id': '',
            'name': ""
        },
        {
            'id': '10005',
            'name': "Blort"
        },
        {
            'id': '10006',
            'name': "Two"
        },
        {
            'id': '10007',
            'name': "Three"
        }
    ];

    $scope.submit = function (model) {
        alert("todo: submit " + model);
    };
});

