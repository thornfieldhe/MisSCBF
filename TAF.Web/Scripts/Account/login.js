
var main = new Vue({
    el: "#form",
    data: {
        entity: {
            name: "",
            password: "",
            failData:""
        }},
    methods: {
        login:function() {
                abp.ajax({
                    url: abp.appPath + 'Account/Login',
                    type: 'POST',
                    data: JSON.stringify(this.entity),
                    useAbpMessage: false
                })
                .fail(function(data) {
                    main.entity.failData = data.details;
                });
        }
    }
});

