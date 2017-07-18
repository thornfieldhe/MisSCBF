Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#userFormBody",
    data: function () {
        return {
            item: {
                id: 0,
                name: "",
                userName: "",
                roles: []
            }
        };
    },
    events: {
        'onSaveItem': function (closeModal) {
            var $this = this;
            abp.services.app.user.saveAsync(this.item)
            .done(function (m) {
                $this.done(closeModal);
            })
            .fail(function (m) {
                $this.fail(m);
            });
        },
        'onGetItem': function (id) {
            this.editModel = true;
            var $this = this;
            abp.services.app.user.get(id)
                .done(function (m) {
                    $this.item.note = m;
                    $this.item.id = id;
                })
            .fail(function (m) {
                $this.fail(m);
            });
        }
    },
    methods: {
        clearItem: function () {
            this.item.id = "";
            this.item.name = "";
            this.item.userName = "";
            this.item.roles = [];
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        $("#searchRoleId").select2().on("change", function (e) { main.queryEntity.roleId = $("#searchRoleId").val(); });
    },
    data: {
        queryEntity: {
            userName: "",
            name:"",
            roleId: 0
        }
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.userName = "";
            this.queryEntity.name = "";
            this.queryEntity.roleId =0;
            $("#searchRoleId").select2().val("").trigger("change");
        }
    },
    methods: {
        excuteQuery: function ($this) {
            abp.services.app.user.getAllAsync(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        delete:function(id) {
            var $this = this;
            abp.services.app.user.delete(id)
                .done(function(m) {
                    $this.done();
                })
                .fail(function (m) {
                    $this.fail(m);
            });
        }
    }
});

main.query(0);