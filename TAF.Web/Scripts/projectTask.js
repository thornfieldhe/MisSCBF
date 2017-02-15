Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#projectTaskFormBody",
    ready: function () {
        var $this = this;
        $("#searchEditProjectId").select2().on("change", function (e) { $this.item.projectId = $("#searchEditProjectId").val(); });
        var spinbox = $('#spinboxSchedule').spinbox('value', 0);
        $('#spinboxSchedule');
        spinbox.options.max = 100;
        spinbox.options.min = 0;

    },
    data: function () {
        return {
            item: {
                id: "",
                name: "",
                projectId: "",
                schedule: 0,
                note: ""
            }
        };
    },
    events: {
        'onSaveItem': function () {
            var $this = this;
            $this.item.schedule = $('#schedule').val();
            abp.services.app.projectTask.saveAsync(this.item)
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
            abp.services.app.projectTask.get(id)
                .done(function (m) {
                    $this.item = m;
                    $("#searchEditProjectId").select2().val($this.item.projectId).trigger("change");
                    $('#spinboxSchedule').spinbox('value',$this.item.schedule);
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
            this.item.projectId = "";
            this.item.note = "";
            this.item.schedule = 0;
            $('#spinboxSchedule').spinbox('value', 0);
            $("#searchEditProjectId").select2().val("").trigger("change");
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        $("#searchProjectId").select2().on("change", function (e) { main.queryEntity.projectId = $("#searchProjectId").val(); });
    },
    data: {
        queryEntity: {
            name: "",
            projectId: "",
            schedule: ""
        }
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.name = "";
            this.queryEntity.projectId = "";
            this.queryEntity.schedule = "";
            $("#searchProjectId").select2().val("").trigger("change");
        }
    },
    methods: {
        excuteQuery: function ($this) {
            console.log(1);
            abp.services.app.projectTask.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.projectTask.delete(id)
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



