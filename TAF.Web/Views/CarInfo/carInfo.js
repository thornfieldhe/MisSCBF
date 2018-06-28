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
        $("#octaneRatingId").select2().on("change", function (e) { $this.item.octaneRatingId = $("#octaneRatingId").val(); });
    },
    data: function () {
        return {
            item: {
                id: "",            
                clxh: "",
                cjh: "",
                fdjh: "",
                octaneRatingId: "",
                cph: "",
                jcgls: 0,
                zbsj: "",
                clzk: "",
                xszh: "",
                yxxe: 0,
                zbzl: "",
                driver: "",
                oilWearSummer: 0,
                oilWearWinter:0
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
                    $("#octaneRatingId").select2().val(m.octaneRatingId).trigger("change");
                })
            .fail(function (m) {
                $this.fail(m);
            });
        }
    },
    methods: {
        clearItem: function () {
            this.item.id = "";
            this.item.clxh= "";
            this.item.cjh= "";
            this.item.fdjh= "";
            this.item.octaneRatingId= "";
            this.item.cph= "";
            this.item.jcgls= 0;
            this.item.zbsj= "";
            this.item.clzk= "";
            this.item.xszh= "";
            this.item.zbzl= "";
            this.item.driver= "";
            this.item.yxxe= 0;
            this.item.oilWearSummer= 0;
            this.item.oilWearWinter = 0;
            $("#clzk").select2().val("").trigger("change");
            $("#driver").select2().val("").trigger("change");
            $("#octaneRatingId").select2().val("").trigger("change");
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
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
        },
        list4:[],
        selectId:"",
        modifyEntity: { modifyTitle: "" }
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
        },
        showAttachmentsDialog: function(name, id) {
            var $this = this;
            $this.modifyEntity.modifyTitle = name;
            $this.selectId = id;
            $("#attachmentsDialog").modal("show");
            $this.query4();

        },
        removeAttach: function(id) {
            var $this = this;
            abp.services.app.attachment.delete(id)
                .done(function(m) {
                    $this.query4();
                })
                .fail(function(m) {
                    $this.fail(m);
                });
        },
        query4: function() {
            var $this = this;

            abp.services.app.attachment.getAll($this.selectId)
                .done(function(r) {
                    $this.list4 = r;
                })
                .fail(function(r) {
                    $this.fail(r);
                });
        },
    }
});

main.query(0);


$(".fileUpload").liteUploader({
        script: defaultUrl + "ProcessManagement/Upload?modelId=" + main.selectId
    })
    .on("lu:success",
        function(e, response) {
            main.query4();
            taf.notify.success("附件上传成功");
        });

$(".fileUpload").change(function() {
    $(".fileUpload").data("liteUploader").options.script =
        defaultUrl + "ProcessManagement/Upload?modelId=" + main.selectId;
    $(this).data("liteUploader").startUpload();
});

