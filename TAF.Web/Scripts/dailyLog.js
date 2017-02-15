Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#dailyLogFormBody",
    ready: function () {
        var $this = this;
        $("#searchEditTaskId").select2().on("change", function (e) { $this.item.taskId = $("#searchEditTaskId").val(); });
        $("#searchEditProjectId")
            .select2()
            .on("change",
                function(e) {
                    $this.item.projectId = $("#searchEditProjectId").val();
                    
                    abp.services.app.projectTask.getSimpleList($("#searchEditProjectId").val())
                        .done(function (list) {
                            taf.successiveBindSelect($("#searchEditTaskId"), list);
                            $("#searchEditTaskId").select2().val($this.item.taskId).trigger("change");
                        });

                });
        var datePickerDate = $('#datePickerDate').datepicker({ format: 'yyyy-mm-dd' }).on('changeDate', function (ev) {
            datePickerDate.hide();
            $this.item.date = $("#datePickerDate").val();
        }).data('datepicker');
        var spinboxTimeConsuming = $('#spinboxTimeConsuming').spinbox('value', 0);
        spinboxTimeConsuming.options.max = 100;
        spinboxTimeConsuming.options.min = 0;
        var spinboxSchedule = $('#spinboxSchedule').spinbox('value', 0);
        spinboxSchedule.options.max = 100;
        spinboxSchedule.options.min = 0;
    },
    data: function () {
        return {
            item: {
                id: "",
                taskId: "",
                date: "",
                projectId: "",
                note: "",
                timeConsuming: 0,
                responsiblePersonId: abp.session.userId,
                schedule: 0
            }
        };
    },
    events: {
        'onSaveItem': function () {
            var $this = this;
            $this.item.schedule = $('#schedule').val();
            $this.item.timeConsuming = $('#timeConsuming').val();
            abp.services.app.dailyLog.saveAsync($this.item)
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

            abp.services.app.dailyLog.get(id)
                .done(function (m) {
                    $this.item = m;
                    $("#searchEditProjectId").select2().val($this.item.projectId).trigger("change");

                    $('#spinboxTimeConsuming').spinbox('value', $this.item.timeConsuming);
                    $('#spinboxSchedule').spinbox('value', $this.item.schedule);
                })
            .fail(function (m) {
                $this.fail(m);
            });
        }
    },
    methods: {
        clearItem: function () {
            this.item.id = "";
            this.item.taskId = "";
            $("#searchEditTaskId").select2().val("").trigger("change");
            this.item.date = "";
            this.item.projectId = "";
            $("#searchEditProjectId").select2().val("").trigger("change");
            this.item.note = "";
            this.item.timeConsuming = 0;
            $('#spinboxTimeConsuming').spinbox('value', 0);
            this.item.schedule = 0;
            $('#spinboxSchedule').spinbox('value', 0);
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        $("#searchTaskId").select2().on("change", function (e) { main.queryEntity.taskId = $("#searchTaskId").val(); });
        $("#searchProjectId").select2().on("change", function (e) { main.queryEntity.projectId = $("#searchProjectId").val(); });
        var dateFrom = $('#dateFrom').datepicker({ format: 'yyyy-mm-dd' }).on('changeDate', function (ev) {
            dateFrom.hide();
            main.queryEntity.dateFrom = $("#dateFrom").val();
        }).data('datepicker');

        var dateTo = $('#dateTo').datepicker({ format: 'yyyy-mm-dd' }).on('changeDate', function (ev) {
            dateTo.hide();
            main.queryEntity.dateTo = $("#dateTo").val();
        }).data('datepicker');
    },
    data: {
        queryEntity: {
            taskId: "",
            dateFrom: "",
            dateTo: "",
            projectId: "",
            note: "",
            responsiblePersonId: abp.session.userId
        }
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.taskId = "";
            this.queryEntity.dateFrom = "";
            this.queryEntity.dateTo = "";
            this.queryEntity.projectId = "";
            this.queryEntity.note = "";
            this.queryEntity.responsiblePersonId = "";
            $("#searchTaskId").select2().val("").trigger("change");
            $("#searchProjectId").select2().val("").trigger("change");
        }
    },
    methods: {
        excuteQuery: function ($this) {
            abp.services.app.dailyLog.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.dailyLog.delete(id)
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



