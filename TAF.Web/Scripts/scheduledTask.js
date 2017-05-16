Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#scheduledTaskFormBody",
    ready: function () {
        var $this = this;
    },
    data: function () {
        return {
            item: {
                id: "",            
                name: "",
                started: false,
                schedule: ""
            }
        };
    },
    events: {
        'onSaveItem': function (closeModal) {
            var $this = this;
            abp.services.app.scheduledTask.saveAsync($this.item)
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
            abp.services.app.scheduledTask.get(id)
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
            this.item.name= "";
            this.item.started= false;
            this.item.schedule= "";
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        $("#searchStarted").select2().on("change", function (e) { main.queryEntity.started = $("#searchStarted").val(); });
    },
    data: {
        queryEntity: {
            name:"", 
            started:false,        
            schedule:"" 
        }
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.name="";
            this.queryEntity.started=false;      
            this.queryEntity.schedule="";
            $("#searchStarted").select2().val("").trigger("change");
        }
    },
    methods: {
        excuteQuery: function ($this) {
            abp.services.app.scheduledTask.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.scheduledTask.delete(id)
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



