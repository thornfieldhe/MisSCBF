var App = App || {};
(function () {

    var appLocalizationSource = abp.localization.getSource('SCBF');
    App.localize = function () {
        return appLocalizationSource.apply(this, arguments);
    };

})(App);