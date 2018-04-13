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
            var $this = this;
            abp.ajax({
                    url: abp.appPath + 'Account/Login',
                    type: 'POST',
                    data: JSON.stringify($this.entity),
                    useAbpMessage: false
                })
                .fail(function(data) {
                    $this.entity.failData = "用户名或密码不正确";
                });
        }
    }
});