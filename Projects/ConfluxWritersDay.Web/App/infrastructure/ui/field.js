// todo: why isn't _references.js working?
/// <reference path="/Scripts/angular.js" />

// original source http://plnkr.co/edit/3zMsNnpNfOFwExSqLj2I?p=preview which derived from https://github.com/angular-ui/angular-ui/pull/191.

'use strict';

var textfield = angular.module('field', ['services.humanizer'])

textfield.directive('field', function ($compile, $http, $templateCache, $interpolate, humanizer) {

    function findInputElement(element) {
        return angular.element(element.find('input')[0] || element.find('textarea')[0] || element.find('select')[0]);
    };

    function getLabelContent(element, ngModel) {

        if (element.attr('label')) {

            return element.attr('label');
        }
        if (element.find('label')[0]) {

            return element.find('label').html();
        }
        else {

            var fullModelName = ngModel;
            var fieldName = fullModelName.substring(fullModelName.indexOf(".") + 1);
            var humanized = humanizer.humanize(fieldName);

            return humanized;
        }

    };

    function getTemplate(element, attrs) {

        var template = attrs.template;

        if (template !== undefined) {
            return template;
        }

        if (attrs.type === 'textarea') {
            return 'field.textarea';
        }

        return 'field';
    }

    function tryRemoveAttribute(element, name) {

        var attribute = element.attr(name);

        if (attribute === undefined) {
            return;
        }

        element[0].removeAttribute(name);
    };

    return {
        restrict: 'E',
        priority: 100,        // We need this directive to happen before ng-model
        terminal: true,       // We are going to deal with this element
        require: '?^form',    // If we are in a form then we can access the ngModelController
        compile: function compile(element, attrs) {

            var labelContent = getLabelContent(element, attrs.ngModel);
            tryRemoveAttribute(element, 'label');

            // Find all the <validator> child elements and extract their validation message info
            var hasRequiredValidator = false;
            var validationMessages = [];

            angular.forEach(element.find('validator'),
                function (validatorElement) {

                    validatorElement = angular.element(validatorElement);

                    var key = validatorElement.attr('key');

                    if (key === 'required') {
                        hasRequiredValidator = true;
                    }

                    validationMessages.push({
                        key: key,
                        getMessage: $interpolate(validatorElement.text())
                    });
                }
            );

            if (!hasRequiredValidator && attrs.required !== undefined) {

                validationMessages.push({
                    key: "required",
                    getMessage: $interpolate(labelContent + " is required.")
                });
            }

            var template = getTemplate(element, attrs);
            var getFieldElement = $http.get('/App/infrastructure/ui/' + template + '.template.html', { cache: $templateCache })

                .then(function (response) {

                    var newElement = angular.element(response.data);
                    var inputElement = findInputElement(newElement);

                    // Copy over the attributes to the input element
                    // At least the ng-model attribute must be copied because we can't use interpolation in the template
                    angular.forEach(element[0].attributes, function (attribute) {
                        var value = attribute.value;
                        var key = attribute.name;
                        inputElement.attr(key, value);
                    });

                    // Add a default placeholder
                    if (inputElement.attr('placeholder') == undefined) {
                        inputElement.attr('placeholder', labelContent);
                    }

                    // Update the label's contents
                    var labelElement = newElement.find('label');
                    labelElement.html(labelContent);

                    
                    return newElement;
                });

            return function (scope, element, attrs, formController) {

                // We have to wait for the field element template to be loaded
                getFieldElement.then(function (newElement) {

                    // Our template will have its own child scope
                    var childScope = scope.$new();

                    // Generate an id for the input from the ng-model expression
                    // (we need to replace dots with something to work with browsers and also form scope)
                    // (We couldn't do this in the compile function as we need the scope to
                    // be able to calculate the unique id)
                    childScope.$modelId = attrs.ngModel.replace('.', '-');

                    // Wire up the input (id and name) and its label (for)
                    // (We need to set the input element's name here before we compile.
                    // If we leave it to interpolation, the formController doesn't pick it up)
                    var inputElement = findInputElement(newElement);

                    inputElement.attr('name', childScope.$modelId);
                    inputElement.attr('id', childScope.$modelId);


                    newElement.find('label').attr('for', childScope.$modelId);

                    // TODO: Consider moving this validator stuff into its own directive
                    // and use a directive controller to wire it all up
                    childScope.$validationMessages = {};

                    angular.forEach(validationMessages, function (validationMessage) {

                        // We need to watch in case it has interpolated values that need processing
                        scope.$watch(
                            validationMessage.getMessage,
                            function (message) {
                                childScope.$validationMessages[validationMessage.key] = message;
                            }
                        );
                    });

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
            };
        }
    };
});
