// todo: why isn't _references.js working?
/// <reference path="/Scripts/angular.js" />

// References:
//      - http://plnkr.co/edit/3zMsNnpNfOFwExSqLj2I?p=preview
//      - https://github.com/angular-ui/angular-ui/pull/191

'use strict';

var textfield = angular.module('textfield', [])

textfield.directive('textfield', function ($compile, $http, $templateCache) {

    function getFieldNameFromNgModel(element) {

        var ngModel = element.attr('ng-model');

        if (ngModel === undefined) {
            throw new Error("ng-model attribute is required.");
        }

        // Example ng-model is Registration.Suburb.
        var dot = ngModel.indexOf(".");

        if (dot < 0) {
            throw new Error("ng-model must use dot notation. eg Model.FieldName")
        }

        return ngModel.substring(dot + 1);
    };

    return {
        restrict: 'E',

        // Next 3 settings from http://plnkr.co/edit/3zMsNnpNfOFwExSqLj2I?p=preview.
        // todo: research more about what they mean and do we need them.
        priority: 100,        // We need this directive to happen before ng-model
        terminal: true,       // We are going to deal with this element
        require: '?^form',    // If we are in a form then we can access the ngModelController

        compile: function compile(element, attrs) {

            var fieldName = getFieldNameFromNgModel(element);
            var labelContent = fieldName;
            
            var templateUrl = '/App/ui/textfield.template.html';

            var getFieldElement = $http.get(templateUrl, { cache: $templateCache })

                .then(function (response) {

                    var newElement = angular.element(response.data);
                    var inputElement = angular.element(element.find('input')[0]);

                    // Copy over the attributes to the input element
                    // At least the ng-model attribute must be copied because we can't use interpolation in the template
                    angular.forEach(element[0].attributes, function (attribute) {
                        var value = attribute.value;
                        var key = attribute.name;
                        inputElement.attr(key, value);
                    });

                    // Update the label's contents
                    var labelElement = newElement.find('label');
                    labelElement.html(labelContent);

                    return newElement;
                });

            return function (scope, element, attrs, formController) {

                console.log("start compile function");

                // When field element template has been loaded
                getFieldElement.then(function (newElement) {

                    // Our template will have its own child scope
                    var childScope = scope.$new();

                    // Generate an id for the input from the ng-model expression
                    // (we need to replace dots with something to work with browsers and also form scope)
                    // (We couldn't do this in the compile function as we need the scope to
                    // be able to calculate the unique id)
                    childScope.$modelId = attrs.ngModel.replace('.', '_').toLowerCase() + '_' + childScope.$id;

                    // Wire up the input (id and name) and its label (for)
                    // (We need to set the input element's name here before we compile.
                    // If we leave it to interpolation, the formController doesn't pick it up)
                    var inputElement = angular.element(element.find('input')[0]);
                    inputElement.attr('name', childScope.$modelId);
                    inputElement.attr('id', childScope.$modelId);
                    newElement.find('label').attr('for', childScope.$modelId);


                    // We must compile our new element in the postLink function rather than in the compile function
                    // (i.e. after any parent form element has been linked)
                    // otherwise the new input won't pick up the FormController
                    $compile(newElement)(childScope, function (clone) {
                        // Place our new element after the original element
                        element.after(clone);
                        // Remove our original element
                        element.remove();
                    });

                    // Only after the new element has been compiled do we have access to the ngModelController
                    // (i.e. formController[childScope.name])
                    if (formController) {
                        childScope.$form = formController;
                        childScope.$field = formController[childScope.$modelId];
                    }
                });

                console.log("finish compile function")
            };

        },

        todoDeleteThisPropertyWhenCodeIsComplete: null
    };
});
