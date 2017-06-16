Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#carInfoFormBody",
    ready: function () {
        var $this = this;
        var datePickerZbsj = $('#datePickerZbsj').datepicker({ format: 'yyyy-mm-dd' }).on('changeDate', function (ev) {
            datePickerZbsj.hide();
            $this.item.zbsj = $("#datePickerZbsj").val();
        })
        .on('hide', function (event) {
		        event.preventDefault();
		        event.stopPropagation();
	    })
            .data('datepicker');

        $("#clzk").select2().on("change", function (e) { $this.item.clzk = $("#clzk").val(); });
        $("#driver").select2().on("change", function (e) { $this.item.driver = $("#driver").val(); });
    },
    data: function () {
        return {
            item: {
                id: "",            
                clxh: "",
                cjh: "",
                fdjh: "",
                ylbh: "",
                cph: "",
                jcgls: 0,
                zbsj: "",
                clzk: "",
                xszh: "",
                yxxe: 0,
                zbzl: "",
                driver:""
            }
        };
    },
    events: {
        'onSaveItem': function (closeModal) {
            var $this = this;
            abp.services.app.carInfo.saveAsync($this.item)
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
            abp.services.app.carInfo.get(id)
                .done(function (m) {
                    $this.item = m;
                    $("#clzk").select2().val(m.clzk).trigger("change");
                    $("#driver").select2().val(m.driver).trigger("change");
                })
            .fail(function (m) {
                $this.fail(m);
            });
        }
    },
    methods: {
        clearItem: function () {
            this.item.id = "00000000-0000-0000-0000-000000000000";
            this.item.clxh= "";
            this.item.cjh= "";
            this.item.fdjh= "";
            this.item.ylbh= "";
            this.item.cph= "";
            this.item.jcgls= 0;
            this.item.zbsj= "";
            this.item.clzk= "";
            this.item.xszh= "";
            this.item.zbzl= "";
            this.item.driver= "";
            this.item.yxxe= 0;
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        var zbsjFrom = $('#zbsjFrom').datepicker({ format: 'yyyy-mm-dd' }).on('changeDate', function (ev) {
            zbsjFrom.hide();
            main.queryEntity.zbsjFrom = $("#zbsjFrom").val();
        }).data('datepicker');
        var zbsjTo = $('#zbsjTo').datepicker({ format: 'yyyy-mm-dd' }).on('changeDate', function (ev) {
            zbsjTo.hide();
            main.queryEntity.zbsjTo = $("#zbsjTo").val();
        }).data('datepicker');
        $("#searchClzk").select2().on("change", function (e) { main.queryEntity.clzk = $("#searchClzk").val(); });
        $("#searchDriver").select2().on("change", function (e) { main.queryEntity.driver = $("#searchDriver").val(); });
    },
    data: {
        queryEntity: {
            clxh:"", 
            cjh:"", 
            fdjh:"", 
            cph:"", 
            zbsjFrom:"", 
            zbsjTo:"", 
            clzk:"", 
            xszh: "",
            driver:""
        }
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.clxh="";
            this.queryEntity.driver="";
            this.queryEntity.cjh="";
            this.queryEntity.fdjh="";
            this.queryEntity.cph="";
            this.queryEntity.zbsjFrom=""; 
            this.queryEntity.zbsjTo="";
            this.queryEntity.clzk="";
            this.queryEntity.xszh = "";
            $("#searchClzk").select2().val("").trigger("change");
            $("#searchDriver").select2().val("").trigger("change");
        }
    },
    methods: {
        excuteQuery: function ($this) {
            abp.services.app.carInfo.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.carInfo.delete(id)
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



