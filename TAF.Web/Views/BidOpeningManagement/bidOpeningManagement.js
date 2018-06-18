var main = new Vue({
    el: "#main",
    mixins: [allMixin],
    ready: function() {
        var $this = this;
        $this.query(0);
        $("#searchCategory").select2()
            .on("change",
                function(e) {
                    $this.queryEntity.category = $("#searchCategory").val();
                });
        $("#searchMode").select2()
            .on("change",
                function(e) {
                    $this.queryEntity.mode = $("#searchMode").val();
                });
        $("#editPlanId").select2()
            .on("change",
                function(e) {
                    $this.item.planId = $("#editPlanId").val();
                    if ($this.item.planId !== "") {
                        abp.services.app.bidOpeningManagement.getTenders($this.item.planId)
                            .done(function(m) {
                                $this.tenders = m;
                            })
                            .fail(function(m) {
                                $this.fail(m);
                            });
                    }
                });

        var datePickerDate = $('#datePickerDate').datepicker({ format: 'yyyy-mm-dd' }).on('changeDate',
                function(ev) {
                    datePickerDate.hide();
                    $this.item.date = $("#datePickerDate").val();
                })
            .on('hide',
                function(event) {
                    event.preventDefault();
                    event.stopPropagation();
                })
            .data('datepicker');
        var datePickerDate2 = $('#datePickerDate2').datepicker({ format: 'yyyy-mm-dd' }).on('changeDate',
                function(ev) {
                    datePickerDate2.hide();
                    $this.performanceItem.date = $("#datePickerDate2").val();
                })
            .on('hide',
                function(event) {
                    event.preventDefault();
                    event.stopPropagation();
                })
            .data('datepicker');
    },
    data:
    {
        queryEntity: {
            category: "",
            mode:
                "",
            code:
                "",
            name:
                "",
            successfulTender:
                ""
        },
        list: {
            options: {
                num_edge_entries: 1, //边缘页数
                num_display_entries:
                    4, //主体页数
                items_per_page:
                    taf.defatulPageSize, //每页显示1项  
                callback:
                    function(index, jq) {
                        main.list.from = main.list.total === 0 ? 0 : main.list.pageSize * index + 1;
                        main.list.index = index;
                        main.list.to = main.list.pageSize * (index + 1) < main.list.total
                            ? main.list.pageSize * (index + 1)
                            : main.list.total;
                        main.queryEntity.skipCount = taf.defatulPageSize * index;
                    }
            }
        },
        item: {
            id: "",
            planId:
                "",
            expertName:
                "",
            price: "",
            date: "",
            expertId:
                "",
            hasPrint:
                0,
            mode:
                "",
            successfulTender:
                []
        },
        performanceItem: {
            id: "",
            planId: "",
            hasPrint: 0,
            marginAmount: 0,
            date: ""
        },
        performanceAmountDetails: [],
        tenders: [],
        list4:
            []
    },
    methods: {
        showDeleteDialog: function(id, name) {
            var $this = this;
            $("#deleteBiddingManagementDialog").modal("show");
            this.deleteEntity.id = id;
            this.deleteEntity.name = name;
        },
        delete:
            function(id) {
                var $this = this;
                abp.services.app.bidOpeningManagement.delete(id)
                    .done(function(m) {
                        $this.query(0);
                        $("#deleteBiddingManagementDialog").modal("hide");
                    })
                    .fail(function(m) {
                        $this.fail(m);
                    });
            },
        showModifyDialog: function(name, id) {
            var $this = this;
            $("#modifyBidOpeningManagementDialog").modal("show");
            $this.modifyEntity.modifyTitle = name;
            if (id !== null) {
                $this.modifyEntity.editModel = true;
                abp.services.app.bidOpeningManagement.get(id)
                    .done(function(m) {
                        abp.services.app.bidOpeningManagement.getTenders(m.planId)
                            .done(function(s) {
                                $this.tenders = s;
                                $this.item = m;
                                $("#editPlanId").select2().val(m.planId).trigger("change");

                            })
                            .fail(function(s) {
                                $this.fail(s);
                            });
                    })
                    .fail(function(m) {
                        $this.fail(m);
                    });
            } else {
                $this.modifyEntity.editModel = false;
                $this.clear();
            }
        },
        showModifyPerformanceDialog: function(name, id) {
            var $this = this;
            $("#modifyPerformanceDialog").modal("show");
            $this.modifyEntity.modifyTitle = name;
            $this.modifyEntity.editModel = true;
            abp.services.app.performanceManage.get(id)
                .done(function(m) {
                    $this.performanceItem = m;
                    if (m.id !== null) {
                        abp.services.app.performanceAmountDetail.getAll(m.id)
                            .done(function(m) {
                                $this.performanceAmountDetails = m;
                            })
                            .fail(function(m) {
                                $this.fail(m);
                            });
                    } else {
                        $this.performanceAmountDetails = [];
                    }
                
                })
                .fail(function(m) {
                    $this.fail(m);
                });

            
        },
        save: function() {
            var $this = this;
//            if (($this.item.model === "GkzbZhpff" || $this.item.model === "Bxcg") &&
//                $this.item.successfulTender.length < 3) {
//                taf.notify.danger("请选择3名候选中标人");
//            } else {
            abp.services.app.bidOpeningManagement.saveAsync($this.item)
                .done(function(m) {
                    $this.query(0);
                    $("#modifyBidOpeningManagementDialog").modal("hide");
                })
                .fail(function(m) {
                    $this.fail(m);
                });
//            }

        },
        save2: function() {
            var $this = this;
            abp.services.app.performanceManage.saveAsync($this.performanceItem)
                .done(function(m) {
                    $this.query(0);
                    $("#modifyPerformanceDialog").modal("hide");
                })
                .fail(function(m) {
                    $this.fail(m);
                });

        },
        clear: function() {
            this.item.id = "";
            $("#editPlanId").select2().val("").trigger("change");
            this.item.planId = "";
            this.item.successfulTender = [];
            this.item.expertName = "";
            this.item.date = "";
            this.item.price = "";
            this.item.expertId = "";
            this.item.hasPrint = 0;
        },
        query: function(index) {
            var $this = this;
            $this.queryEntity.skipCount = taf.defatulPageSize * index;
            abp.services.app.bidOpeningManagement.getAll($this.queryEntity)
                .done(function(r) {
                    $this.list.items = r.items;
                    $this.list.total = r.totalCount;
                    main.list.from = main.list.total === 0 ? 0 : main.list.pageSize * index + 1;
                    main.list.index = index;
                    main.list.to = main.list.pageSize * (index + 1) < main.list.total
                        ? main.list.pageSize * (index + 1)
                        : main.list.total;
                    $this.list.index = index;
                    $(".pagination").pagination(r.totalCount, $this.list.options);
                })
                .fail(function(r) {
                    $this.fail(r);
                });
        },
        resetSearch: function() {
            this.queryEntity.category = "";
            this.queryEntity.mode = "";
            this.queryEntity.code = "";
            this.queryEntity.name = "";
            this.queryEntity.successfulTender = "";
            $("#searchCategory").select2().val("").trigger("change");
            $("#searchMode").select2().val("").trigger("change");
        },
        getExpert: function() {
            var $this = this;
            abp.services.app.unitPool.getRandomItem("Purchase_Expert")
                .done(function(r) {
                    $this.item.expertId = r.key;
                    $this.item.expertName = r.value;
                });
        },
        export:
            function() {
                //Todo: 导出报告需要更新状态
                var $this = this;
                $this.item.hasPrint = 1;
                abp.services.app.bidOpeningManagement.saveAsync($this.item)
                    .done(function(m) {
                        var url = "/BiddingManagement/DownloadPlan/" + m;
                        taf.download(url);
                        $("#modifyBidOpeningManagementDialog").modal("hide");
                    })
                    .fail(function(m) {
                        $this.fail(m);
                    });
            },
        export2:
            function() {

                var $this = this;
                $this.item.hasPrint = 1;
                abp.services.app.bidOpeningManagement.saveAsync($this.item)
                    .done(function(m) {
                        var url = "/BidOpeningManagement/DownloadPlan2/" + m;
                        taf.download(url);
                        $("#modifyBidOpeningManagementDialog").modal("hide");
                    })
                    .fail(function(m) {
                        $this.fail(m);
                    });
            },
        export3:
            function() {
                var $this = this;
                $this.item.hasPrint = 1;
                abp.services.app.bidOpeningManagement.saveAsync($this.item)
                    .done(function(m) {
                        var url = "/BidOpeningManagement/DownloadPlan3/" + m;
                        taf.download(url);
                        $("#modifyBidOpeningManagementDialog").modal("hide");
                    })
                    .fail(function(m) {
                        $this.fail(m);
                    });
            },
        export4:
            function(id) {
                var $this = this;
                $this.item.hasPrint = 1;
                abp.services.app.bidOpeningManagement.saveAsync($this.item)
                    .done(function(m) {
                        var url = "/PerformanceAmountDetail/Download/" + m;
                        taf.download(url);
                        $("#modifyPerformanceDialog").modal("hide");
                    })
                    .fail(function(m) {
                        $this.fail(m);
                    });
            },
        showAttachmentsDialog: function(name, id) {
            var $this = this;
            $this.modifyEntity.modifyTitle = name;
            $this.item.id = id;
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

            abp.services.app.attachment.getAll($this.item.id)
                .done(function(r) {
                    $this.list4 = r;
                })
                .fail(function(r) {
                    $this.fail(r);
                });
        },
        addDetail: function() {
            var $this = this;
            var detail = {
                id: "",
                performanceManageId: $this.performanceItem.id,
                name: "",
                editStatus: true
            };
            $this.performanceAmountDetails.push(detail);
        },
        deleteDetail: function(id) {
            abp.services.app.performanceAmountDetail.delete(id)
                .done(function(m) {
                    abp.services.app.performanceAmountDetail.getAll($this.performanceItem.id)
                        .done(function(s) {
                            $this.performanceAmountDetails = s;
                        })
                        .fail(function(s) {
                            $this.fail(s);
                        });
                }).fail(function(m) {
                    $this.fail(m);
                });

        },
        saveDetail: function(item) {
            var $this = this;
            if (item.performanceManageId == null) {
                taf.notify.danger("请先保存履约保证金!");
            } else {
                abp.services.app.performanceAmountDetail.saveAsync(item)
                    .done(function(m) {
                        abp.services.app.performanceAmountDetail.getAll($this.performanceItem.id)
                            .done(function(s) {
                                $this.performanceAmountDetails = s;
                            })
                            .fail(function(s) {
                                $this.fail(s);
                            });
                    }).fail(function(m) {
                        $this.fail(m);
                    });
                
            }
            
        },
        editDetail: function(item) {
            item.editStatus = true;
        },
        cancelDetail: function(item) {
            abp.services.app.performanceAmountDetail.getAll($this.performanceItem.id)
                .done(function(s) {
                    $this.performanceAmountDetails = s;
                })
                .fail(function(s) {
                    $this.fail(s);
                });
        },
        export4: function(id) {
            var $this = this;
            $this.performanceItem.hasPrint=1;
            abp.services.app.performanceManage.saveAsync($this.performanceItem)
                .done(function (m) {
                    var url = "/PerformanceAmountDetail/Download/" + id;
                    taf.download(url);
                    $("#modifyBiddingManagementDialog").modal("hide");
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        }
    }
});


$(".fileUpload").liteUploader({
        script: defaultUrl + "ProcessManagement/Upload?modelId=" + main.item.id
    })
    .on("lu:success",
        function(e, response) {
            main.query4();
            taf.notify.success("附件上传成功");
        });

$(".fileUpload").change(function() {
    $(".fileUpload").data("liteUploader").options.script =
        defaultUrl + "ProcessManagement/Upload?modelId=" + main.item.id;
    $(this).data("liteUploader").startUpload();
});