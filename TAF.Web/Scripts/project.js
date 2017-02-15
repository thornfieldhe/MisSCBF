Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#projectFormBody",
    data: function () {
        return {
            item: {
                id: 0,
                name: "",
                goal: "",
                taskItems: 0,
                schedule: "",
                isCompleted:false
            }
        };
    },
    events: {
        'onSaveItem': function () {
            var $this = this;
            abp.services.app.project.saveAsync(this.item)
            .done(function (m) {
                $this.done();
            })
            .fail(function (m) {
                $this.fail(m);
            });
        },
        'onGetItem': function (id) {
            this.editModel = true;
            var $this = this;
            abp.services.app.project.get(id)
                .done(function (m) {
                    $this.item = m;
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
            this.item.goal = "";
            this.item.taskItems = 0;
            this.item.schedule = "";
            this.item.isCompleted = false;
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        $("#searchIsCompleted").select2().on("change", function (e) { main.queryEntity.isCompleted = $("#searchIsCompleted").val(); });
    },
    data: {
        queryEntity: {
            name: "",
            isCompleted: ""
        }
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.name = "";
            this.queryEntity.isCompleted = "";
            $("#searchIsCompleted").select2().val("").trigger("change");
        }
    },
    methods: {
        excuteQuery: function ($this) {
            console.log(1);
            abp.services.app.project.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.project.delete(id)
                .done(function (m) {
                    $this.done();
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        }
    }
});

main.query(0);