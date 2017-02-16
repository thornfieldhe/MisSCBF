var main = new Vue({
    mixins: [indexMixin],
    data: {
        item: {
            userId: abp.session.userId
        }
    },
    methods: {
        saveItem: function () {
            var $this = this;
            abp.services.app.user.changePwd($this.item)
                .done(function() {
                    taf.notify.success("密码修改成功");
                })
                .fail(function (m) {
                    console.log(m, 1111);
                    $this.fail(m);
                });
        }
    }
});