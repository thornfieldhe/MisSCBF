var main = new Vue({
    el: "#main",
    mixins: [allMixin],
    ready: function () {
        var $this = this;
        $("#point1").select2().on("change", function (e) {$this.item.point1 = $("#point1").val();}); 
        $("#point2").select2().on("change", function (e) {$this.item.point2 = $("#point2").val();}); 
        $("#point3").select2().on("change", function (e) {$this.item.point3 = $("#point3").val();}); 
        $("#point4").select2().on("change", function (e) {$this.item.point4 = $("#point4").val();}); 
        $("#point5").select2().on("change", function (e) {$this.item.point5 = $("#point5").val();}); 
        $("#point6").select2().on("change", function (e) {$this.item.point6 = $("#point6").val();}); 
        $("#point7").select2().on("change", function (e) {$this.item.point7 = $("#point7").val();}); 
        $("#point8").select2().on("change", function (e) {$this.item.point8 = $("#point8").val();}); 
        $("#point9").select2().on("change", function (e) { $this.item.point9 = $("#point9").val();}); 
        $("#point10").select2().on("change", function (e) { $this.item.point10 = $("#point10").val();}); 
        $("#point11").select2().on("change", function (e) {$this.item.point11 = $("#point11").val();}); 
        $("#point12").select2().on("change", function (e) {$this.item.point12 = $("#point12").val();}); 
        $("#point13").select2().on("change", function (e) {$this.item.point13 = $("#point13").val();}); 
        $("#point14").select2().on("change", function (e) {$this.item.point14 = $("#point14").val();}); 
        $("#point15").select2().on("change", function (e) {$this.item.point15 = $("#point15").val();}); 
        $("#point16").select2().on("change", function (e) {$this.item.point16 = $("#point16").val();}); 
        $("#point17").select2().on("change", function (e) {$this.item.point17 = $("#point17").val();}); 
        $("#point18").select2().on("change", function (e) {$this.item.point18 = $("#point18").val();}); 
        $("#point19").select2().on("change", function (e) {$this.item.point19 = $("#point19").val();}); 
        $("#point20").select2().on("change", function (e) {$this.item.point20 = $("#point20").val();}); 
        $("#point21").select2().on("change", function (e) {$this.item.point21 = $("#point21").val();}); 
        $("#point22").select2().on("change", function (e) {$this.item.point22 = $("#point22").val();}); 
        $("#point23").select2().on("change", function (e) {$this.item.point23 = $("#point23").val();}); 
        $("#point24").select2().on("change", function (e) {$this.item.point24 = $("#point24").val();}); 
        $("#point25").select2().on("change", function (e) {$this.item.point25 = $("#point25").val();}); 
        $("#point26").select2().on("change", function (e) {$this.item.point26 = $("#point26").val();}); 
        $("#point27").select2().on("change", function (e) {$this.item.point27 = $("#point27").val();}); 
        $("#point28").select2().on("change", function (e) {$this.item.point28 = $("#point28").val();}); 
        $("#point29").select2().on("change", function (e) {$this.item.point29 = $("#point29").val();}); 
        $("#point30").select2().on("change", function (e) {$this.item.point30 = $("#point30").val();}); 
        $this.query(0);
    },
    data: {
        queryEntity: {
            code:"", 
            point1Note:"", 
            point2Note:"", 
            point3Note:"", 
            point4Note:"", 
            point5Note:"", 
            point6Note:"", 
            point7Note:"", 
            point8Note:"", 
            point9Note:"", 
            point10Note:"", 
            point11Note:"", 
            point12Note:"", 
            point13Note:"", 
            point14Note:"", 
            point15Note:"", 
            point16Note:"", 
            point17Note:"", 
            point18Note:"", 
            point19Note:"", 
            point20Note:"", 
            point21Note:"", 
            point22Note: "",
            point23Note: "",
            point24Note: "",
            point25Note: "",
            point26Note: "",
            point27Note: "",
            point28Note: "",
            point29Note: "",
            point30Note: ""
        },
        list: {
            options: {
                num_edge_entries: 1, //边缘页数
                num_display_entries: 4, //主体页数
                items_per_page: taf.defatulPageSize, //每页显示1项  
                callback: function (index, jq) {
                    main.list.from = main.list.total === 0 ? 0 : main.list.pageSize * index + 1;
                    main.list.index = index;
                    main.list.to = main.list.pageSize * (index + 1) < main.list.total ? main.list.pageSize * (index + 1) : main.list.total;
                    main.queryEntity.skipCount = taf.defatulPageSize * index;
                   
                }
            }
        },
        item: {
            id : "",
            code:"", 
            point1:0,
            point1Note:"", 
            point2:0,
            point2Note:"", 
            point3:0,
            point3Note:"", 
            point4:0,
            point4Note:"", 
            point5:0,
            point5Note:"", 
            point6:0,
            point6Note:"", 
            point7:0,
            point7Note:"", 
            point8:0,
            point8Note:"", 
            point9:0,
            point9Note:"", 
            point10:0,
            point10Note:"", 
            point11:0,
            point11Note:"" ,
            point12:0,
            point12Note:"", 
            point13:0,
            point13Note:"", 
            point14:0,
            point14Note:"", 
            point15:0,
            point15Note:"", 
            point16:0,
            point16Note:"", 
            point17:0,
            point17Note:"", 
            point18:0,
            point18Note:"", 
            point19:0,
            point19Note:"", 
            point20:0,
            point20Note:"", 
            point21:0,
            point21Note:"", 
            point22:0,
            point22Note: "", 
            point23: 0,
            point23Note: "",
            point24: 0,
            point24Note: "",
            point25: 0,
            point25Note: "",
            point26: 0,
            point26Note: "",
            point27: 0,
            point27Note: "",
            point28: 0,
            point28Note: "",
            point29: 0,
            point29Note: "",
            point30: 0,
            point30Note: "", 
        }
    },
    methods: {
        showDeleteDialog: function (id,name) {
            var $this = this;
            $("#deleteVoucherAuditDialog").modal("show");
            this.deleteEntity.id = id;
            this.deleteEntity.name = name;
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.voucherAudit.delete(id)
                .done(function (m) {
                    $this.query(0);
                    $("#deleteVoucherAuditDialog").modal("hide");
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        },
        showModifyDialog: function (name,id) {
            var $this = this;
            $("#modifyVoucherAuditDialog").modal("show");
            $this.modifyEntity.modifyTitle = name;
            if (id !==null) {
                $this.modifyEntity.editModel = true;
                abp.services.app.voucherAudit.get(id)
                    .done(function (m) {
                        $this.item = m;
                        $("#point1").select2().val($this.item.point1).trigger("change");
                        $("#point2").select2().val($this.item.point2).trigger("change");
                        $("#point3").select2().val($this.item.point3).trigger("change");
                        $("#point4").select2().val($this.item.point4).trigger("change");
                        $("#point5").select2().val($this.item.point5).trigger("change");
                        $("#point6").select2().val($this.item.point6).trigger("change");
                        $("#point7").select2().val($this.item.point7).trigger("change");
                        $("#point8").select2().val($this.item.point8).trigger("change");
                        $("#point9").select2().val($this.item.point9).trigger("change");
                        $("#point10").select2().val($this.item.point10).trigger("change");
                        $("#point11").select2().val($this.item.point11).trigger("change");
                        $("#point12").select2().val($this.item.point12).trigger("change");
                        $("#point13").select2().val($this.item.point13).trigger("change");
                        $("#point14").select2().val($this.item.point14).trigger("change");
                        $("#point15").select2().val($this.item.point15).trigger("change");
                        $("#point16").select2().val($this.item.point16).trigger("change");
                        $("#point17").select2().val($this.item.point17).trigger("change");
                        $("#point18").select2().val($this.item.point18).trigger("change");
                        $("#point19").select2().val($this.item.point19).trigger("change");
                        $("#point20").select2().val($this.item.point20).trigger("change");
                        $("#point21").select2().val($this.item.point21).trigger("change");
                        $("#point22").select2().val($this.item.point22).trigger("change");
                        $("#point23").select2().val($this.item.point23).trigger("change");
                        $("#point24").select2().val($this.item.point24).trigger("change");
                        $("#point25").select2().val($this.item.point25).trigger("change");
                        $("#point26").select2().val($this.item.point26).trigger("change");
                        $("#point27").select2().val($this.item.point27).trigger("change");
                        $("#point28").select2().val($this.item.point28).trigger("change");
                        $("#point29").select2().val($this.item.point29).trigger("change");
                        $("#point30").select2().val($this.item.point30).trigger("change");
                    })
                    .fail(function (m) {
                        $this.fail(m);
                    });
            }else {
                $this.modifyEntity.editModel = false;
                $this.clear();
            }
        },
        save:function() {
            var $this = this;
            abp.services.app.voucherAudit.saveAsync($this.item)
            .done(function (m) {
                $this.query(0);
                $("#modifyVoucherAuditDialog").modal("hide");
            })
            .fail(function (m) {
                $this.fail(m);
            });
        },
        saveNew:function() {
            var $this = this;
            abp.services.app.voucherAudit.saveAsync($this.item)
            .done(function (m) {
                $this.query(0);
                $this.clear();
            })
            .fail(function (m) {
                $this.fail(m);
            });
        },
        clear: function () {
            this.item.code = "";
            $("#point1").select2().val("").trigger("change");
            $("#point2").select2().val("").trigger("change");
            $("#point3").select2().val("").trigger("change");
            $("#point4").select2().val("").trigger("change");
            $("#point5").select2().val("").trigger("change");
            $("#point6").select2().val("").trigger("change");
            $("#point7").select2().val("").trigger("change");
            $("#point8").select2().val("").trigger("change");
            $("#point9").select2().val("").trigger("change");
            $("#point10").select2().val("").trigger("change");
            $("#point11").select2().val("").trigger("change");
            $("#point12").select2().val("").trigger("change");
            $("#point13").select2().val("").trigger("change");
            $("#point14").select2().val("").trigger("change");
            $("#point15").select2().val("").trigger("change");
            $("#point16").select2().val("").trigger("change");
            $("#point17").select2().val("").trigger("change");
            $("#point18").select2().val("").trigger("change");
            $("#point19").select2().val("").trigger("change");
            $("#point20").select2().val("").trigger("change");
            $("#point21").select2().val("").trigger("change");
            $("#point22").select2().val("").trigger("change");
            $("#point23").select2().val("").trigger("change");
            $("#point24").select2().val("").trigger("change");
            $("#point25").select2().val("").trigger("change");
            $("#point26").select2().val("").trigger("change");
            $("#point27").select2().val("").trigger("change");
            $("#point28").select2().val("").trigger("change");
            $("#point29").select2().val("").trigger("change");
            $("#point30").select2().val("").trigger("change");
        },
        query: function (index) {
            var $this = this;
            $this.queryEntity.skipCount = taf.defatulPageSize * index;
            abp.services.app.voucherAudit.getAll($this.queryEntity)
            .done(function (r) {
                $this.list.items = r.items;
                $this.list.total = r.totalCount;
                    main.list.from = main.list.total === 0 ? 0 : main.list.pageSize * index + 1;
                    main.list.index = index;
                    main.list.to = main.list.pageSize * (index + 1) < main.list.total ? main.list.pageSize * (index + 1) : main.list.total;
                    $this.list.index = index;
                $(".pagination").pagination(r.totalCount, $this.list.options);
            })
            .fail(function (r) {
                $this.fail(r);
            });
        },
        resetSearch: function () {
                this.queryEntity.code="";
        }
    }
});



