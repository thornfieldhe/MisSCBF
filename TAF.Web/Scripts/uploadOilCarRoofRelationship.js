

var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        $("#month").select2().on("change", function (e) { main.queryEntity.month = $("#month").val(); });
    },
    data: {
        queryEntity: {
            month: "01"
        },
        item: {
            id: "",
            note: ""
        },
        list1:{},
        list2: {},
        selectOId: "",
        selectRId:""
    },
    methods: {
        query: function () {
            var $this = this;
            abp.services.app.oilCardProof.getAll($this.queryEntity.month)
                .done(function (r) {
                    $this.list = r;
                    $this.query1();
                    $this.query2();
                });
        },
        query1: function () {
            var $this = this;
            abp.services.app.oilCardProof.getApplicationForBunkerAList($this.queryEntity.month)
                .done(function (r) {
                    $this.list1 = r;
                });
        },
        query2: function () {
            var $this = this;
            abp.services.app.oilCardProof.getUploadOilCarRoof($this.queryEntity.month)
                .done(function (r) {
                    $this.list2 = r;
                });
        },
        get: function (id) {
            var $this = this;
            $("#modifyUploadOilCarRoofRelationship").modal("show");
            abp.services.app.oilCardProof.getNote(id)
                .done(function (m) {
                    $this.item.note = m;
                    $this.item.id = id;
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        },
        save: function () {
            var $this = this;
            abp.services.app.oilCardProof.saveNote({ Key: $this.item.id, Value: $this.item.note })
                .done(function (m) {
                    $("#modifyUploadOilCarRoofRelationship").modal("hide");
                    $this.query();
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        },
        showDelete: function () {
            $("#deleteUploadOilCarRoofRelationshipDialog").modal("show");
        },
        delete: function () {
            var $this = this;
            if ($this.selectOId == '') {
                taf.notify.danger("请选择加油申请单");
            } else {
                abp.services.app.applicationForBunkerA.delete($this.selectOId)
                    .done(function (m) {
                        $this.query1($this.queryEntity.month);
                        $("#deleteUploadOilCarRoofRelationshipDialog").modal("hide");
                        taf.notify.success("加油卡消耗凭证单删除成功");
                    });
            }
        },
        link: function (id1, id2) {
            var $this = this;
            if ($this.selectOId == '') {
                taf.notify.danger("请选择加油卡");
            } else if ($this.selectRId == '') {
                taf.notify.danger("请选择消耗凭证单");
            }else {
                abp.services.app.oilCardProof.link({ Key: $this.selectOId, Value: $this.selectRId, Item3: $this.queryEntity.month })
                    .done(function (m) {
                        $this.query();
                        $this.query1();
                        $this.query2();
                        taf.notify.success("消耗凭证单关联成功");
                    });
            }
        }
    }
});

$(".fileUpload").liteUploader({
    script: defaultUrl + "UploadOilCarRoofRelationship/Upload?month=" + main.queryEntity.month
    })
    .on("lu:success", function (e, response) {
        main.query();
        taf.notify.success("加油卡消耗凭证单导入成功");
    });

$(".fileUpload").change(function () {
    $(".fileUpload").data("liteUploader").options.script= defaultUrl + "UploadOilCarRoofRelationship/Upload?month=" + main.queryEntity.month;
    console.log($(this).data("liteUploader"));
    $(this).data("liteUploader").startUpload();
});