// todo: why isn't _references.js working?
/// <reference path="/Scripts/angular.js" />

// References:
//      - http://plnkr.co/edit/3zMsNnpNfOFwExSqLj2I?p=preview
//      - https://github.com/angular-ui/angular-ui/pull/191

'use strict';

var textfield = angular.module('textfield', [])

textfield.directive('textfield', function () {
    return {
        restrict: 'E',

        templateUrl: '/App/ui/textfield.template.html'
    };
});
