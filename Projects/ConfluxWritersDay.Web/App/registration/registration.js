// todo: why isn't _references.js working?
/// <reference path="/Scripts/angular.js" />

'use strict';

var app = angular.module('registrationApp', ['field']);

app.controller('RegistrationController', function ($scope) {

    $scope.Registration = {
        MembershipOrganisation: ''
    };

    // todo: get from repository
    $scope.MembershipOrganisations = [
        {
            'id': '',
            'name': 'none'
        },
        {
            'id': 'Conflux9',
            'name': "Conflux 9 Member"
        },
        {
            'id': 'CSFG',
            'name': "CSFG Member"
        },
        {
            'id': 'ACTWritersCentre',
            'name': "ACT Writers Centre Member"
        }
    ];

    // todo: get from repository
    $scope.PaymentMethods = [
        {
            'id': '',
            'name': ''
        },
        {
            'id': 'Cheque',
            'name': "Cheque"
        },
        {
            'id': 'PayPal',
            'name': 'PayPal'
        },
        {
            'id': 'DirectDeposit',
            'name': 'Direct Deposit'
        }
    ];

    $scope.submit = function (model) {
        alert("todo: submit " + model);
    };
});

