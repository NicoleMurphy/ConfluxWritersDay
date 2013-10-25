var module = angular.module('services.humanizer', []);

module.factory("humanizer", function () {

    var service = {};

    // Inserts a space before each update case character in <text>.
    service.humanize = function (text) {

        var output = text.substring(0, 1);

        for (var i = 1; i < text.length; i++) {

            var character = text.charAt(i);
            var isLowerCase = character.toLowerCase() === character;

            if (isLowerCase) {
                output += character;

            }
            else {
                output += " " + character;
            }
        }

        return output;
    };

    return service;
});

